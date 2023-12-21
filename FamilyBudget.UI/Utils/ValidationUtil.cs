using System;
using System.Text.RegularExpressions;

namespace FamilyBudget.UI.Utils
{
    public static class ValidationUtil
    {
        public static bool IsValidDecimal(string input)
        {
            return decimal.TryParse(input, out _);
        }

        public static bool IsValidInt(string input)
        {
            return int.TryParse(input, out _);
        }

        public static bool IsValidDate(string input)
        {
            return DateTime.TryParse(input, out _);
        }

        public static bool IsValidEmail(string input)
        {
            return Regex.IsMatch(input, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }

        // Дополнительные методы валидации по требованию
    }
}
