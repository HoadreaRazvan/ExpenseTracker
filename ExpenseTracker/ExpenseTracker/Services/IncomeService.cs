using ExpenseTracker.Data;
using ExpenseTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services
{
    public class IncomeService
    {
        private readonly ExpenseTrackerContext _context;

        public IncomeService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public List<Income> GetAllIncomes()
        {
            return _context.Incomes.ToList();
        }

        public async Task AddIncomeAsync(Income income)
        {
            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();
        }

        public Income GetIncomeById(int id)
        {
            return _context.Incomes.FirstOrDefault(i => i.Id == id);
        }

        public Income UpdateIncome(Income income)
        {
            _context.Entry(income).State = EntityState.Modified;
            _context.SaveChanges();

            return income;
        }

        public void DeleteIncome(int id)
        {
            var income = _context.Incomes.Find(id);
            if (income != null)
            {
                _context.Incomes.Remove(income);
                _context.SaveChanges();
            }
        }
    }
}
