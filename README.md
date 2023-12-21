Структура Проекта
Проект разделен на несколько основных модулей:
FamilyBudget
|-- FamilyBudget.Domain
|   |-- Entities  : Определяет основные бизнес-сущности.
|   |   |-- Transaction.cs : Финансовые транзакции.
|   |   |-- Category.cs : Категории доходов и расходов.
|   |   |-- Budget.cs : Общий бюджет. 
|   |   |-- CategoryLimit.cs :Лимиты бюджетов
|   |-- Enums : Перечисления для различения типов данных.
|   |   |-- TransactionType.cs : Типы транзакций (доход/расход)
|-- FamilyBudget.Infrastructure
|   |-- Data : Управление базой данных.
|   |   |-- AppDbContext.cs  : Контекст базы данных.
|   |   |-- DbInitializer.cs  : Инициализация начальных данных.
|   |-- Repositories  : Работа с данными.
|   |   |-- ITransactionRepository.cs : Интерфейс репозитория транзакций.
|   |   |-- TransactionRepository.cs    : Реализация репозитория.
|   |-- Services                        
|   |   |-- AuthenticationService.cs    : Аутентификация пользователей.
|   |   |-- CurrencyConverterService.cs : Конвертация валют.
|-- FamilyBudget.UI
|   |-- Program.cs  :Главный файл.
|   |-- Menus : Пользовательские интерфейсы для взаимодействия.
|   |   |-- MainMenu.cs
|   |   |-- AddTransactionMenu.cs
|   |   |-- ViewTransactionsMenu.cs
|   |   |-- StatisticsMenu.cs
|   |   |-- SetBudgetMenu.cs
|   |-- Utils             : Вспомогательные утилиты.
|   |   |-- InputUtil.cs
|   |   |-- DateUtil.cs
|   |   |-- ValidationUtil.cs
|-- FamilyBudget.Tests
|   |-- UnitTests.cs      : Модульные тесты для проверки функциональности.

Инструкция по запуску :
git clone https://github.com/KambarovDilshat/FamilyBudget.git
cd FamilyBudget 
cd FamilyBudget.UI
dotnet run
