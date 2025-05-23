﻿using Amazon.S3;
using Ecommerce.Business.Helpers.Mapper;
using Ecommerce.Business.Seeder;
using Ecommerce.Business.Services.Implementations;
using Ecommerce.Business.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

namespace Ecommerce.Business
{
    public static class BusinessInstallerService
    {
        public static void BusinessInstaller(IServiceCollection services, IConfiguration config)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddDefaultAWSOptions(config.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();


            #region Services
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAWSImageService,AWSImageService>();
            services.AddScoped<IAWSVideoService,AWSVideoService>();
            services.AddScoped<IProductService,ProductServicee>();
            services.AddScoped<ICartItemService,CartItemService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IPaymentService, PaymentService>();
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
