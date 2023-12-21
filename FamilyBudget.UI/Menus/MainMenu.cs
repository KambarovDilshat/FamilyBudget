using System;

namespace FamilyBudget.UI.Menus
{
    public class MainMenu
    {
        private readonly IServiceProvider _serviceProvider;

        public MainMenu(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Show()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Добавить транзакцию");
                Console.WriteLine("2. Просмотр транзакций");
                Console.WriteLine("3. Статистика");
                Console.WriteLine("4. Установить бюджет");
                Console.WriteLine("5. Выход");
                Console.Write("-> ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        var addTransactionMenu = _serviceProvider.GetService(typeof(AddTransactionMenu)) as AddTransactionMenu;
                        if (addTransactionMenu == null)
                        {
                            Console.WriteLine("Ошибка: AddTransactionMenu не найден. Проверьте регистрацию в DI контейнере.");
                        }
                        else
                        {
                            await addTransactionMenu.Show();
                        }
                        break;
                    case 2:
                        var viewTransactionsMenu = _serviceProvider.GetService(typeof(ViewTransactionsMenu)) as ViewTransactionsMenu;
                        if (viewTransactionsMenu == null)
                        {
                            Console.WriteLine("Ошибка: ViewTransactionsMenu не найден. Проверьте регистрацию в DI контейнере.");
                        }
                        else
                        {
                            await viewTransactionsMenu.Show();
                            

                        }
                        break;

                    case 3:
                        var statisticsMenu = _serviceProvider.GetService(typeof(StatisticsMenu)) as StatisticsMenu;
                        if (statisticsMenu == null)
                        {
                            Console.WriteLine("Ошибка: StatisticsMenu не найден. Проверьте регистрацию в DI контейнере.");
                        }
                        else
                        {
                            await statisticsMenu.ShowAsync();
                        }
                        break;

                    case 4:
                        var setBudgetMenu = _serviceProvider.GetService(typeof(SetBudgetMenu)) as SetBudgetMenu;
                        if (setBudgetMenu == null)
                        {
                            Console.WriteLine("Ошибка: SetBudgetMenu не найден. Проверьте регистрацию в DI контейнере.");
                        }
                        else
                        {
                            setBudgetMenu.Show();
                        }
                        break;

                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
