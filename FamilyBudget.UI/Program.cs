using FamilyBudget.Infrastructure.Data;
using FamilyBudget.Infrastructure.Services;
using FamilyBudget.UI.Menus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using FamilyBudget.Infrastructure.Repositories;

namespace FamilyBudget.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()   // Создание и настройка контейнера зависимостей с использованием библиотеки Microsoft.Extensions.DependencyInjection
                .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("FamilyBudget")) // Добавление DbContext для работы с базой данных в памяти
                .AddScoped<ITransactionRepository, TransactionRepository>()
                .AddScoped<IBudgetRepository, BudgetRepository>()
                .AddTransient<AuthenticationService>()
                .AddTransient<CurrencyConverterService>()
                .AddTransient<MainMenu>()
                .AddTransient<AddTransactionMenu>()
                .AddTransient<ViewTransactionsMenu>()
                .AddTransient<StatisticsMenu>()
                .AddTransient<SetBudgetMenu>()
                .BuildServiceProvider();

            var dbContext = serviceProvider.GetService<AppDbContext>();
            DbInitializer.Initialize(dbContext); // Раскомментируйте для инициализации базы данных

            var mainMenu = serviceProvider.GetService<MainMenu>();
            mainMenu.Show(); // Запуск главного меню
        }
    }
}

































//using FamilyBudget.Infrastructure.Data;
//using FamilyBudget.Infrastructure.Services;
//using FamilyBudget.UI.Menus;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using FamilyBudget.Infrastructure.Repositories;

//namespace FamilyBudget.UI
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            // Настройка зависимостей
//            var serviceProvider = new ServiceCollection()
//                .AddDbContext<AppDbContext>(options =>options.UseInMemoryDatabase("FamilyBudget")) // Используйте UseSqlServer или другой провайдер для реальной БД

//                .AddScoped<ITransactionRepository, TransactionRepository>()
//                .AddTransient<AuthenticationService>()
//                .AddTransient<CurrencyConverterService>()
//                // .AddHttpClient()

//                // Регистрация классов меню
//                .AddTransient<MainMenu>()
//                .AddTransient<AddTransactionMenu>()
//                .AddTransient<ViewTransactionsMenu>()
//                .AddTransient<StatisticsMenu>()
//                .AddTransient<SetBudgetMenu>()

//                .BuildServiceProvider();

//            // Инициализация базы данных
//            // var dbContext = serviceProvider.GetService<AppDbContext>();
//            // DbInitializer.Initialize(dbContext);

//            // Запуск основного цикла приложения
//            var mainMenu = serviceProvider.GetService<MainMenu>();
//            mainMenu.Show();

//        }
//    }
//}


////   // Настройка зависимостей
////  var serviceProvider = new ServiceCollection()
//// //      .AddDbContext<AppDbContext>(options =>
//////         options.UseInMemoryDatabase("FamilyBudget")) // Используйте UseSqlServer или другой провайдер для реальной БД
////       .AddScoped<ITransactionRepository, TransactionRepository>()
////       .AddTransient<AuthenticationService>()
////       .AddTransient<CurrencyConverterService>()
////  //     .AddHttpClient()
////       .BuildServiceProvider();

////  // Инициализация базы данных
////  //var dbContext = serviceProvider.GetService<AppDbContext>();
////  // DbInitializer.Initialize(dbContext);

////  // Запуск основного цикла приложения
////   var mainMenu = new MainMenu(serviceProvider);
////   mainMenu.Show();