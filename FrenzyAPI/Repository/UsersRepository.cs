using Contract;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
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
    }
}
