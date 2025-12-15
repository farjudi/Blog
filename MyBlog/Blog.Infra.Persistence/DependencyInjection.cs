using Blog.Domain.Repositories;
using Blog.Infra.Persistence.Context;
using Blog.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")

            ));

            services.AddScoped<IUserRepository,UserRepository>();


            return services;
        }
    }
}
