using Contract;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users
                .Include(x => x.PurchaseHistory)
                .ToListAsync();
        }
        public async Task<User>GetUserById(int id)
        {
            return await _context.Users.Include(x => x.PurchaseHistory).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool>SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void AddPurchaseHistory(int id, PurchaseHistory purchaseHistory)
        {
            _context.Users.SingleOrDefault(x => x.Id == id).PurchaseHistory.Add(purchaseHistory);
        }
    }
}
