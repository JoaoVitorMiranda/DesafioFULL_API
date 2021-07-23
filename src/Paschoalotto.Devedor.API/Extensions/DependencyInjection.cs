using Paschoalotto.Devedor.Domain.Models;
using Paschoalotto.Devedor.Domain.Models.Devedor;
using Paschoalotto.Devedor.Domain.Models.Parcela;
using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Paschoalotto.Devedor.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Paschoalotto.Devedor.Domain.Interfaces.UoW;
using Paschoalotto.Devedor.Infra.UoW;
using System.Data.SqlClient;
using Paschoalotto.Devedor.API.Services;
using Paschoalotto.Devedor.Domain.Interfaces.Services;
using Paschoalotto.Devedor.Infra.Repository;
using Paschoalotto.Devedor.Domain.Interfaces.Repository;
using Paschoalotto.Devedor.Domain.Interfaces.Notifications;
using Paschoalotto.Devedor.Domain.Notifications;

namespace Paschoalotto.Devedor.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {

        public static void ConfigureIoC(
            this IServiceCollection services,
            IConfiguration Configuration)
        {
            AddInfraConfigurations(services, Configuration);
            AddServices(services);
            AddRepositories(services);
        }

        private static void AddInfraConfigurations(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<EntityContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("db")));

            services.AddTransient<IDbConnection>(conn => new SqlConnection(Configuration.GetConnectionString("db")));
            services.AddScoped<DapperContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IDevedorService, DevedorService>();
            services.AddScoped<IParcelaService, ParcelaService>();
            services.AddScoped<IDomainNotification, DomainNotification>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IParcelaRepository, ParcelaRepository>();
            services.AddScoped<IDevedorRepository, DevedorRepository>();
        }
    }
}
