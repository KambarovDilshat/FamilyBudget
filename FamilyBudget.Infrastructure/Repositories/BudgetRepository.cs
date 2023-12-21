using FamilyBudget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FamilyBudget.Infrastructure.Data;

namespace FamilyBudget.Infrastructure.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly AppDbContext _context;

        public BudgetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Budget>> GetAllAsync()
        {
            return await _context.Budgets.ToListAsync();
        }

        public async Task<Budget> GetByIdAsync(int id)
        {
            return await _context.Budgets.FindAsync(id);
        }

        public async Task<Budget> GetByMonthAsync(DateTime month)
        {
            return await _context.Budgets
                .SingleOrDefaultAsync(b => b.Month.Year == month.Year && b.Month.Month == month.Month);
        }

        public async Task AddAsync(Budget budget)
        {
            await _context.Budgets.AddAsync(budget);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Budget budget)
        {
            _context.Budgets.Update(budget);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var budget = await _context.Budgets.FindAsync(id);
            if (budget != null)
            {
                _context.Budgets.Remove(budget);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddOrUpdateAsync(Budget budget)
        {
            var existingBudget = await GetByMonthAsync(budget.Month);
            if (existingBudget != null)
            {
                // Обновление существующего бюджета
                existingBudget.TotalBudget = budget.TotalBudget;
                await UpdateAsync(existingBudget);
            }
            else
            {
                // AДобавить новый бюджет
                await AddAsync(budget);
            }
        }
    }
}
