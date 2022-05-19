using Contract;
using FrenzyAPI.Helper;
using FrenzyAPI.Repository;
using FrenzyAPI.ServiceCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrenzyAPI
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IRequestHandler, RequestHandler>();
            services.AddScoped<IResturantRepository, ResturantRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }
    }
}
