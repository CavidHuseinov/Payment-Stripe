
using Ecommerce.Business.Helpers.Mapper;
using Ecommerce.Business.Seeder;
using Ecommerce.Business.Services.Implementations;
using Ecommerce.Business.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Business
{
    public static class BusinessInstallerService
    {
        public static void BusinessInstaller(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            #region Services
            services.AddScoped<IUserService,UserService>();
            #endregion
        }

        public static async Task SeedRoleAsync(IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await RoleSeedAsync.SeedRoleAsync(roleManager);
        }
    }
}
