# PrintHub API

PrintHub API — это веб-сервис, предназначенный для управления устройствами печати, филиалами, установками устройств и заданиями печати для крупной компании. Этот проект реализован на платформе .NET с использованием C# и MS SQL Server в качестве базы данных.

## Техническое задание

Целью проекта является создание Backend-функционала для Frontend-разработчиков клиента, предоставляя HTTP API для управления и учета устройств печати в филиалах компании.

## Технологии

- net8.0
- C# 12
- MS SQL Server
- Entity Framework
- Swagger

## Установка и запуск

1. **Клонируйте репозиторий:**
    ```sh
    git clone https://github.com/AntiToxicic/PrintHubApi.git
    ```

2. **Настройте строку подключения к базе данных в `appsettings.json`:**
    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=PrintHubDb;User Id=your_username;Password=your_password;"
    }
    ```

3. **Запустите приложение:**
    ```sh
    dotnet run
    ```

Приложение будет доступно по адресу `http://localhost:23456`.

## Контакты

- тел. 7-908-787-01-89
- telegram: [antitoxicic](http://t.me/antitoxic_work)
- почта: trukhin.alex.work@gmail.ru
