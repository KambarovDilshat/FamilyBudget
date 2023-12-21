using FamilyBudget.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace FamilyBudget.UI.Menus
{
    public class ViewTransactionsMenu
    {
        private readonly ITransactionRepository _transactionRepository;

        public ViewTransactionsMenu(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Show()
        {
            try
            {
                Console.WriteLine("История транзакций");

                var transactions = await _transactionRepository.GetAllAsync();

                if (transactions.Any())
                {
                    foreach (var transaction in transactions)
                    {
                        Console.WriteLine($"Дата: {transaction.Date:yyyy-MM-dd}, Сумма: {transaction.Amount:C2}, Категория: {transaction.Category.Name}, Тип: {transaction.Type}, Комментарий: {transaction.Comment}");
                    }
                }
                else
                {
                    Console.WriteLine("Транзакции отсутствуют.");
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в главное меню.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}