using Data;
using Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.Interfaces.Repositories;
using Model.Interfaces.Services;
using Service.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crosscutting.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BandaATContext>(o => o.UseSqlServer(configuration.GetConnectionString("BandaATContext")));


            services.AddTransient<IBandaService, BandaService>();
            services.AddTransient<IBandaRepository, BandaRepository>();

            services.AddTransient<IMusicoService, MusicoService>();
            services.AddTransient<IMusicoRepository, MusicoRepository>();
        }
    }
}
