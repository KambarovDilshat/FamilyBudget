using FamilyBudget.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudget.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<CategoryLimit> CategoryLimits { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Настройка сущности Transaction
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey("CategoryId");

            // Настройка сущности Category
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Настройка сущности Budget
            modelBuilder.Entity<Budget>()
                .Property(b => b.TotalBudget)
                .HasColumnType("decimal(18,2)");

            // Настройка сущности CategoryLimit
            modelBuilder.Entity<CategoryLimit>()
                .HasKey(cl => new { cl.BudgetId, cl.CategoryId });

            modelBuilder.Entity<CategoryLimit>()
                .HasOne(cl => cl.Budget)
                .WithMany(b => b.CategoryLimits)
                .HasForeignKey(cl => cl.BudgetId);

            modelBuilder.Entity<CategoryLimit>()
                .HasOne(cl => cl.Category)
                .WithMany()
                .HasForeignKey(cl => cl.CategoryId);

            modelBuilder.Entity<CategoryLimit>()
                .Property(cl => cl.Limit)
                .HasColumnType("decimal(18,2)");
        }
    }
}
