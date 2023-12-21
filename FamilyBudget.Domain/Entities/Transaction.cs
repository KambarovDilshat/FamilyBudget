using System;
using FamilyBudget.Domain.Enums;

namespace FamilyBudget.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        private decimal _amount;
        public decimal Amount
        {
            get => _amount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Сумма транзакции не может быть отрицательной.");
                _amount = value;
            }
        }
        public Category Category { get; set; }
        public TransactionType Type { get; set; }
        public string Comment { get; set; }

        // Публичный конструктор по умолчанию
        public Transaction() {}

        public Transaction(DateTime date, decimal amount, Category category, TransactionType type, string comment = "")
        {
            Date = date;
            Amount = amount;
            Category = category ?? throw new ArgumentNullException(nameof(category), "Категория не может быть null.");
            Type = type;
            Comment = comment;
        }

        public override string ToString()
        {
            return $"Дата: {Date}, Сумма: {Amount}, Категория: {Category.Name}, Тип: {Type}, Комментарий: {Comment}";
        }
    }
}
