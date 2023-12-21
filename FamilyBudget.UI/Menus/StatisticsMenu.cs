using FamilyBudget.Domain.Enums;
using FamilyBudget.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyBudget.UI.Menus;


    public class StatisticsMenu
{
    private readonly ITransactionRepository _transactionRepository;

    public StatisticsMenu(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task ShowAsync()
    {
        try
        {
            Console.WriteLine("Статистика транзакций");

            Console.WriteLine("Введите начальную дату (формат: ГГГГ-ММ-ДД):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
            {
                Console.WriteLine("Некорректный формат даты.");
                return;
            }

            Console.WriteLine("Введите конечную дату (формат: ГГГГ-ММ-ДД):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
            {
                Console.WriteLine("Некорректный формат даты.");
                return;
            }

            var transactions = await _transactionRepository.GetByDateRangeAsync(startDate, endDate);

            if (!transactions.Any())
            {
                Console.WriteLine("Транзакции за указанный период отсутствуют.");
            }
            else
            {
                var incomeTotal = transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount);
                var expenseTotal = transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount);

                Console.WriteLine($"Общий доход: {incomeTotal:C2}");
                Console.WriteLine($"Общий расход: {expenseTotal:C2}");
                // Реализация визуализации распределения расходов по категориям
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