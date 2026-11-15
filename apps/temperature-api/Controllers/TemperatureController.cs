using Microsoft.AspNetCore.Mvc;

namespace temperature_api.Controllers
{
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private static readonly Random _random = Random.Shared;

        private static double GenerateTemp()
        {
            const Double min = -10;
            const Double max = 27;

            Double randomDouble = _random.NextDouble() * (max - min) + (Double)min;

            return Math.Round(randomDouble, 1);
        }

        [HttpGet("/temperature/{id:int}")]
        public IActionResult GetTemperatureById(int id)
        {
            return Ok(new
            {
                value = GenerateTemp(),
                status = "active",
                timestamp = DateTime.UtcNow
            });
        }

        [HttpGet("/temperature")]
        public IActionResult GetTemperature([FromQuery] string? id, [FromQuery] string? location)
        {
            var key = id ?? location ?? "default";
            return Ok(new
            {
                value = GenerateTemp(),
                status = "active",
                timestamp = DateTime.UtcNow
            });
        }
    }
}
