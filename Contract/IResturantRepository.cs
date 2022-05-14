using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contract
{
    public interface  IResturantRepository
    {
        Task<IEnumerable<Restaurant>> GetResturantsAsync();
    }
}
