using AutoMapper;
using Models;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI.Helper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<Menu, MenuDto>();
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<PurchaseHistory, PurchaseHistoryDto>();
            CreateMap<OpeningHour, OpeningHourDto>();
        }
    }
}
