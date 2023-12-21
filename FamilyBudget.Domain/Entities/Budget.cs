using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyBudget.Domain.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        private decimal _totalBudget;
        public decimal TotalBudget
        {
            get => _totalBudget;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Limit cannot be negative.");
                _totalBudget = value;
            }
        }

        public ICollection<CategoryLimit> CategoryLimits { get; set; }
        public DateTime Month { get; set; }

        public Budget(decimal totalBudget, DateTime month)
        {
            TotalBudget = totalBudget;
            Month = month;
            CategoryLimits = new List<CategoryLimit>();
        }

        public void SetCategoryLimit(Category category, decimal limit)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Category cannot be null.");

            if (limit < 0)
                throw new ArgumentException("Limit cannot be negative.");

            var existingLimit = CategoryLimits.FirstOrDefault(cl => cl.CategoryId == category.Id);
            if (existingLimit != null)
            {
                existingLimit.Limit = limit;
            }
            else
            {
                CategoryLimits.Add(new CategoryLimit { CategoryId = category.Id, Limit = limit, BudgetId = this.Id });
            }
        }

        public decimal GetCategoryLimit(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Category cannot be null.");

            var categoryLimit = CategoryLimits.FirstOrDefault(cl => cl.CategoryId == category.Id);
            return categoryLimit?.Limit ?? 0;
        }
    }
}
