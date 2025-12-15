using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using FluentValidation;
//using Microsoft.Extensions.DependencyInjection;
//using System.Reflection;
namespace Blog.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
         
            services.AddMediatR(assembly);


            services.AddValidatorsFromAssembly(assembly);
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}
