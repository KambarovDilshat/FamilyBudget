FamilyBudget
============

FamilyBudget - это приложение для управления семейным бюджетом, позволяющее пользователям отслеживать доходы, расходы, устанавливать бюджетные ограничения и просматривать статистику финансов.

Структура Проекта
-----------------

Проект разделен на несколько основных модулей:

### FamilyBudget.Domain

*   `Entities`: Определяет основные бизнес-сущности.
    *   `Transaction.cs`: Финансовые транзакции.
    *   `Category.cs`: Категории доходов и расходов.
    *   `Budget.cs`: Общий бюджет.
*   `Enums`: Перечисления для различения типов данных.
    *   `TransactionType.cs`: Типы транзакций (доход/расход).

### FamilyBudget.Infrastructure

*   `Data`: Управление базой данных.
    *   `AppDbContext.cs`: Контекст базы данных.
    *   `DbInitializer.cs`: Инициализация начальных данных.
*   `Repositories`: Работа с данными.
    *   `ITransactionRepository.cs`: Интерфейс репозитория транзакций.
    *   `TransactionRepository.cs`: Реализация репозитория.
*   `Services`: Вспомогательные сервисы.
    *   `AuthenticationService.cs`: Аутентификация пользователей.
    *   `CurrencyConverterService.cs`: Конвертация валют.

### FamilyBudget.UI

*   `Program.cs`: Точка входа приложения.
*   `Menus`: Пользовательские интерфейсы для взаимодействия.
*   `Utils`: Вспомогательные утилиты.

### FamilyBudget.Tests

*   `UnitTests.cs`: Модульные тесты для проверки функциональности.

 ### Инструкция по запуску :
* git clone https://github.com/KambarovDilshat/FamilyBudget.git
* cd FamilyBudget 
* cd FamilyBudget.UI
* dotnet run
