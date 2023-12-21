using FamilyBudget.Domain.Entities;
using FamilyBudget.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyBudget.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public async Task TestAddTransaction()
        {
            var repository = new MockTransactionRepository();
            var transaction = new Transaction(DateTime.Now, 100, new Category("Test"), Domain.Enums.TransactionType.Expense, "Test transaction");

            await repository.AddAsync(transaction);

            Assert.IsTrue(repository.Transactions.Any(t => t.Comment == "Test transaction"));
        }

        [TestMethod]
        public void TestCalculateTotalExpenses()
        {
            var transactions = new[]
            {
                new Transaction(DateTime.Now, 50, new Category("Groceries"), Domain.Enums.TransactionType.Expense, ""),
                new Transaction(DateTime.Now, 150, new Category("Utilities"), Domain.Enums.TransactionType.Expense, "")
            };

            var totalExpenses = transactions.Sum(t => t.Amount);

            Assert.AreEqual(200, totalExpenses);
        }


        // Пример мок-класса для тестирования
        private class MockTransactionRepository : ITransactionRepository
        {
            public List<Transaction> Transactions = new List<Transaction>();

            public async Task<IEnumerable<Transaction>> GetAllAsync()
            {
                return await Task.FromResult(Transactions);
            }

            public async Task<Transaction> GetByIdAsync(int id)
            {
                var transaction = Transactions.FirstOrDefault(t => t.Id == id);
                return await Task.FromResult(transaction);
            }

            public async Task<IEnumerable<Transaction>> GetByDateRangeAsync(DateTime start, DateTime end)
            {
                var transactionsInRange = Transactions.Where(t => t.Date >= start && t.Date <= end);
                return await Task.FromResult(transactionsInRange);
            }

            public async Task AddAsync(Transaction transaction)
            {
                Transactions.Add(transaction);
                await Task.CompletedTask;
            }

            public async Task UpdateAsync(Transaction transaction)
            {
                var index = Transactions.FindIndex(t => t.Id == transaction.Id);
                if (index != -1)
                {
                    Transactions[index] = transaction;
                }
                await Task.CompletedTask;
            }

            public async Task DeleteAsync(int id)
            {
                var transaction = Transactions.FirstOrDefault(t => t.Id == id);
                if (transaction != null)
                {
                    Transactions.Remove(transaction);
                }
                await Task.CompletedTask;
            }

            
        }

    }
}
