using FamilyBudget.Domain.Entities;
using FamilyBudget.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace FamilyBudget.UI.Menus
{
    public class SetBudgetMenu
    {
        private readonly IBudgetRepository _budgetRepository;

        public SetBudgetMenu(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task Show()
        {
            try
            {
                Console.WriteLine("Установка бюджета");

                Console.WriteLine("Введите общий бюджет на месяц:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal totalBudget))
                {
                    Console.WriteLine("Некорректный ввод суммы. Пожалуйста, введите число.");
                    return;
                }

                Console.WriteLine("Введите месяц и год для бюджета (формат: ГГГГ-ММ):");
                if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out DateTime month))
                {
                    Console.WriteLine("Некорректный ввод даты. Пожалуйста, введите дату в формате ГГГГ-ММ.");
                    return;
                }

                var existingBudget = await _budgetRepository.GetByMonthAsync(month);
                if (existingBudget != null)
                {
                    existingBudget.TotalBudget = totalBudget;
                    await _budgetRepository.UpdateAsync(existingBudget);
                }
                else
                {
                    var budget = new Budget(totalBudget, month);
                    await _budgetRepository.AddAsync(budget);
                }

                Console.WriteLine("Бюджет установлен успешно.");
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
