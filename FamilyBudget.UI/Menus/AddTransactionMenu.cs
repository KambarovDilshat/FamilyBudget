using FamilyBudget.Domain.Entities;
using FamilyBudget.Domain.Enums;
using FamilyBudget.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace FamilyBudget.UI.Menus
{
    public class AddTransactionMenu
    {
        private readonly ITransactionRepository _transactionRepository;

        public AddTransactionMenu(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Show()
        {
            try
            {
                Console.WriteLine("Добавление новой транзакции");

                // Получение данных от пользователя
                Console.WriteLine("Введите сумму:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Некорректный ввод суммы.");
                    return;
                }

                Console.WriteLine("Выберите тип транзакции: 1 - Доход, 2 - Расход");
                if (!int.TryParse(Console.ReadLine(), out int transactionTypeInput) || (transactionTypeInput != 1 && transactionTypeInput != 2))
                {
                    Console.WriteLine("Некорректный выбор типа транзакции.");
                    return;
                }
                TransactionType type = (TransactionType)(transactionTypeInput - 1);

                // Здесь должна быть логика выбора категории из списка
                Console.WriteLine("Введите категорию:");
                string categoryName = Console.ReadLine(); // Предполагаем, что категория уже существует

                Console.WriteLine("Введите комментарий (необязательно):");
                string comment = Console.ReadLine();

                // Создание и сохранение транзакции
                var transaction = new Transaction(DateTime.Now, amount, new Category(categoryName), type, comment);
                await _transactionRepository.AddAsync(transaction);

                Console.WriteLine("Транзакция добавлена успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
