
using Ecommerce.DAL.Context;
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
                opt.UseSqlServer(config.GetConnectionString("Default"));
            });
        }
    }
}
