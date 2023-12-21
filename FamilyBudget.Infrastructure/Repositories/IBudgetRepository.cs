using FamilyBudget.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyBudget.Infrastructure.Repositories
{
    public interface IBudgetRepository
    {
        Task<IEnumerable<Budget>> GetAllAsync();
        Task<Budget> GetByIdAsync(int id);
        Task<Budget> GetByMonthAsync(DateTime month);
        Task AddAsync(Budget budget);
        Task UpdateAsync(Budget budget);
        Task DeleteAsync(int id);
        Task AddOrUpdateAsync(Budget budget);
        
    }
}
