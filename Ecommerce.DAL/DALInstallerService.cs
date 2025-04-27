using Ecommerce.DAL.Context;
using Ecommerce.DAL.IUO;
using Ecommerce.DAL.Repositories.Implementations;
using Ecommerce.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.DAL
{
    public static class DALInstallerService
    {
        public static void DALInstaller(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<EcommerceDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("Deploy"));
            });

            #region Repositories
            services.AddScoped(typeof(ICommandRepo<>), typeof(CommandRepo<>));
            services.AddScoped(typeof(IQueryRepo<>), typeof(QueryRepo<>));
            services.AddScoped<IProductRepo,ProductRepo>();
            services.AddScoped<IUnitOfWorks,UnitOfWorks>();
            #endregion

        }
    }
}
