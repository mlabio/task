using CRUD.Project.BLL.Interfaces;
using CRUD.Project.BLL.Services;
using CRUD.Project.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Project.Configs
{
    public static class DInjectionConfigService
    {

        public static IServiceCollection RegisterDInjection(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<DatabaseContext>();

            return services;
        }
    }
}
