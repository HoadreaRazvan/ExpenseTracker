using ExpenseTracker.Data;
using ExpenseTracker.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services
{
    public class AuthService
    {
        private readonly ExpenseTrackerContext _context;

        public AuthService(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public List<User> GetUserDetails()
        {
            return _context.Users.ToList();
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return user;
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
                return user;
            throw new ArgumentNullException();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public User? GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public bool Register(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
                return false;
            var user = new User { Username = username, Password = password };
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public bool Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }
    }
}