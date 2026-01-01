using Blog.Application.Interfaces;
using Blog.Domain.Repositories;
using Blog.Infra.Persistence.Context;
using Blog.Infra.Persistence.Repositories;
using Blog.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ICookieAuthenticationService,CookieAuthenticationService>();

            return services;
        }
    }
}
