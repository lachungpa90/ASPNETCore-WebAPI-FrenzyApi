using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        void Update(User user);
        Task<bool> SaveAllAsync();
        Task<User> GetUserById(int id);
        void AddPurchaseHistory(int id, PurchaseHistory purchaseHistory);

    }
}
