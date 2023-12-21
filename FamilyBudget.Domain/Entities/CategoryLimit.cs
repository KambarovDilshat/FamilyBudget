namespace FamilyBudget.Domain.Entities{
    public class CategoryLimit
    {
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public decimal Limit { get; set; }
    }

}
