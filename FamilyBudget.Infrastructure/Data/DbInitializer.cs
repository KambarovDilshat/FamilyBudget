using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Enums;
using System;
using System.Linq;

namespace FamilyBudget.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Проверяем, пуста ли база данных
            if (context.Transactions.Any())
            {
                return; // База данных уже инициализирована
            }

            // Инициализация категорий
            var categories = new Category[]
            {
                new Category("Продукты"),
                new Category("Транспорт"),
                new Category("Развлечения")
                // Добавить другие категории по мере необходимости
            };

            foreach (var c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            // Инициализация транзакций
            var transactions = new Transaction[]
            {
                new Transaction(DateTime.Now, 100, categories[0], TransactionType.Expense, "Покупка в супермаркете"),
                new Transaction(DateTime.Now.AddDays(-1), 50, categories[1], TransactionType.Expense, "Билет на автобус")
                // Добавить другие транзакции по мере необходимости
            };

            foreach (var t in transactions)
            {
                context.Transactions.Add(t);
            }
            context.SaveChanges();

            // Инициализация бюджетов
            var budgets = new Budget[]
            {
                new Budget(5000, new DateTime(2023, 1, 1)),
                new Budget(3000, new DateTime(2023, 2, 1))
                // Добавить другие бюджеты по мере необходимости
            };

            foreach (var b in budgets)
            {
                context.Budgets.Add(b);
            }
            context.SaveChanges();
        }
    }
}
