using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Application.Services;
using WebApp.Application.Services.IServices;

namespace WebApp.Application
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IPetService,PetService>();

            services.AddValidatorsFromAssembly(typeof(DependencyRegistration).Assembly);

            return services;
        }

    }
}
