﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository;
using AppServices.Services;

namespace Registrar
{
    namespace Registrar
    {
        public static class CongratulatorRegister
        {
            public static IServiceCollection AddServices(this IServiceCollection services)
            {
                services.AddCors();

                services.AddSingleton<DbContextOptionsConfigurator<CongratulatorContext>, DbContextOptionsConfiguration>();

                services.AddDbContext<CongratulatorContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
                    ((sp, dbOptions) => sp.GetRequiredService<DbContextOptionsConfigurator<CongratulatorContext>>()
                    .Configure((DbContextOptionsBuilder<CongratulatorContext>)dbOptions)));

                services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<CongratulatorContext>()));

                services.AddScoped(typeof(IListBirthdayRepository), typeof(ListBirthdayRepository));

                services.AddTransient<IListBirthdayService, ListBirthdayService>();
                services.AddTransient<IListBirthdayRepository, ListBirthdayRepository>();

                return services;
            }
        }
    }
}
