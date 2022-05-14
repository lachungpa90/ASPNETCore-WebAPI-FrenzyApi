using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IRequestHandler
    {
        Task<List<Restaurant>> GetResturants();  
    }
}
