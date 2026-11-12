# Project_template

Это шаблон для решения проектной работы. Структура этого файла повторяет структуру заданий. Заполняйте его по мере работы над решением.

# Задание 1. Анализ и планирование

<aside>Чтобы составить документ с описанием текущей архитектуры приложения, можно часть информации взять из описания компании и условия задания. Это нормально.</aside

### 1. Описание функциональности монолитного приложения

**Управление отоплением:**

- Пользователи могут удалённо включать/выключать отопление в своих домах.
- Система поддерживает:  CRUD + постоянное хранение + собственные показания

**Мониторинг температуры:**

- Пользователи могут просматривать текущую температуру в своих домах через веб-интерфейс.
- Система поддерживает: Только получение информации.

### 2. Анализ архитектуры монолитного приложения

Перечислите здесь основные особенности текущего приложения: какой язык программирования используется, какая база данных, как организовано взаимодействие между компонентами и так далее.

- Язык программирования: Go
- База данных: PostgreSQL
- Архитектура: Монолитная, все компоненты системы (обработка запросов, бизнес-логика, работа с данными) находятся в рамках одного приложения.
- Взаимодействие: Синхронное, запросы обрабатываются последовательно.
- Масштабируемость: Ограничена, так как монолит сложно масштабировать по частям.
- Развертывание: Требует остановки всего приложения.

### 3. Определение доменов и границы контекстов

- Домен: Умный дом.
- Поддомен: Управление отоплением.-- Контекст: Работа с реестром датчиков.
- Поддомен: Просмотр текущей температуры.-- Контекст: Получение текущей температуры.

### **4. Проблемы монолитного решения**

- Архитектура: Монолитная, все компоненты системы (обработка запросов, бизнес-логика, работа с данными) находятся в рамках одного приложения.
- Взаимодействие: Синхронное, запросы обрабатываются последовательно.
- Масштабируемость: Ограничена, так как монолит сложно масштабировать по частям.
- Развертывание: Требует остановки всего приложения.

### 5. Визуализация контекста системы — диаграмма С4

[Диаграмма контекста в модели C4, уровень 1](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/context/warmhouse_monolith_Context.puml)

# Задание 2. Проектирование микросервисной архитектуры

В этом задании вам нужно предоставить только диаграммы в модели C4. Мы не просим вас отдельно описывать получившиеся микросервисы и то, как вы определили взаимодействия между компонентами To-Be системы. Если вы правильно подготовите диаграммы C4, они и так это покажут.

**Диаграмма контейнеров (Containers)**

[Диаграмма контекста в модели C4, уровень 2](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/container/warmhouse_microservices_Container.puml)

**Диаграмма компонентов (Components)**

[Подключение устройств партнёров](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/component/warmhouse_microservices_Connecting_partner_devices_Component.puml)

[Управление устройствами](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/component/warmhouse_microservices_Device_managment_Component.puml)

[Cервис IAM(Identity and Access Management (управление идентификацией и доступом))](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/component/warmhouse_microservices_IAM_Component.puml)

[Комплекты устройств](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/component/warmhouse_microservices_Kits_Component.puml)

[Клиентский интерфейс умного дома](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/component/warmhouse_microservices_User_Interface_Component.puml)

**Диаграмма кода (Code)**

[Компонент «Каталог комплектов»](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/code/warmhouse_Kits_Code.puml)

# Задание 3. Разработка ER-диаграммы

[IAM DB (Пользователи и доступ)](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/ER_DB/IAMDB.puml)

[Kits DB (Комплекты устройств)](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/ER_DB/KitsDB.puml)

[Control DB (Управление устройствами)](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/schemas/ER_DB/ControlDB.puml)

# Задание 4. Создание и документирование API

### 1. Тип API

Выбираю REST API. Простота реализации, отладки, тестирования. Семантически лучше подходит к работе с устройствами, командами, показаниями. Сервисы старался разграничить, чтобы они представляли свой домен, REST поможет подчеркнуть зону ответственности каждого из них. В .net как и в большинстве других языков есть midleware или его аналоги, с нашим выбранным способом верификации запросов - думаю удачный выбор. И в конце концов выбор другого типа апи может серьезно осложнить старт работы над микросервисами, имеет смысл усложнять когда в этом будет необходимость.

### 2. Документация API

Клиентский интерфейс умного дома. На данном этапе не имеет своего апи, но согласно ТЗ образует точку входа пользователя и является инструментом домовладельца по управлению устройствами умного дома.

[API сервиса управления устройствами](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/apps/docs/device-control-api.yaml)

[API шлюза подключения устройств](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/apps/docs/device-gateway-api.yaml)

[API сервиса аутентификации и управления доступом](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/apps/docs/IAM-api.yaml)

[API сервиса комплектов устройств](https://github.com/dmi-viktor/architecture-warmhouse/blob/warmhouse/apps/docs/kits-api.yaml)

# Задание 5. Работа с docker и docker-compose

Перейдите в apps.

Там находится приложение-монолит для работы с датчиками температуры. В README.md описано как запустить решение.

Вам нужно:

1. сделать простое приложение temperature-api на любом удобном для вас языке программирования, которое при запросе /temperature?location= будет отдавать рандомное значение температуры.


Locations - название комнаты, sensorId - идентификатор названия комнаты

```
    // If no location is provided, use a default based on sensor ID                                        
    if location == "" {                                        
        switch sensorID {                                        
        case "1":                                        
            location = "Living Room"                                        
        case "2":                                        
            location = "Bedroom"                                        
        case "3":                                        
            location = "Kitchen"                                        
        default:                                        
            location = "Unknown"                                        
        }                                        
    }                                        
                                        
    // If no sensor ID is provided, generate one based on location                                        
    if sensorID == "" {                                        
        switch location {                                        
        case "с Room":                                        
            sensorID = "1"                                        
        case "Bedroom":                                        
            sensorID = "2"                                        
        case "Kitchen":                                        
            sensorID = "3"                                        
        default:                                        
            sensorID = "0"                                        
        }                                        
    }
```

1. Приложение следует упаковать в Docker и добавить в docker-compose. Порт по умолчанию должен быть 8081
2. Кроме того для smart_home приложения требуется база данных - добавьте в docker-compose файл настройки для запуска postgres с указанием скрипта инициализации ./smart_home/init.sql


Для проверки можно использовать Postman коллекцию smarthome-api.postman_collection.json и вызвать:

- Create Sensor
- Get All Sensors

Должно при каждом вызове отображаться разное значение температуры

Ревьюер будет проверять точно так же.

 
