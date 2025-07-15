using ExpenseTracker.Data;
using ExpenseTracker.Data.Models;
using ExpenseTracker.Pages;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services
{
    public class ExpenseService
    {
        private readonly ExpenseTrackerContext _context;

        public ExpenseService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public List<Expense> GetAllExpenses()
        {
            return _context.Expenses.Include(e => e.Category).ToList();
        }

        public async Task AddExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }


        public Expense GetExpenseById(int id)
        {
            return _context.Expenses
                           .Include(e => e.Category)
                           .FirstOrDefault(e => e.Id == id);
        }

        public Expense UpdateExpense(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
            _context.SaveChanges();

            return expense;
        }

        public void DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
        }

        public List<Expense> GetExpensesByCategory(int categoryId)
        {
            return _context.Expenses
                           .Where(e => e.CategoryId == categoryId)
                           .Include(e => e.Category)
                           .ToList();
        }


    }
}
