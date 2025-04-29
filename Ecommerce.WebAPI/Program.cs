using Amazon.S3;
using Ecommerce.Business;
using Ecommerce.Core.Entities;
using Ecommerce.DAL;
using Ecommerce.WebAPI.Middlewares;
using Microsoft.AspNetCore.Identity;
using Stripe;

namespace Ecommerce.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            WebAPIInstallerService.WebAPIInstaller(builder.Services,builder.Configuration);
            DALInstallerService.DALInstaller(builder.Services,builder.Configuration);
            BusinessInstallerService.BusinessInstaller(builder.Services,builder.Configuration);
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

            var app = builder.Build();
            #region SeedDataForRole
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await BusinessInstallerService.SeedRoleAsync(services);
            }
            #endregion
            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseMiddleware<GlobalHandleException>();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
