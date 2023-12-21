using System;

namespace FamilyBudget.UI.Utils
{
    public static class InputUtil
    {
        public static string PromptString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        public static bool TryPromptDecimal(string prompt, out decimal result)
        {
            Console.WriteLine(prompt);
            return decimal.TryParse(Console.ReadLine(), out result);
        }

        public static bool TryPromptInt(string prompt, out int result)
        {
            Console.WriteLine(prompt);
            return int.TryParse(Console.ReadLine(), out result);
        }

        public static bool TryPromptDate(string prompt, out DateTime result)
        {
            Console.WriteLine(prompt);
            return DateTime.TryParse(Console.ReadLine(), out result);
        }

        
    }
}
