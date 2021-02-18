using System;
using MB.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MB.Shared;
using MB.API;

[assembly: HostingStartup(typeof(MB.Server.Areas.Identity.IdentityHostingStartup))]
namespace MB.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) =>
            //{

            //    services.AddIdentity<Gebruiker, IdentityRole>(options =>
            //    {
            //        options.User.RequireUniqueEmail = true;
            //        options.Password.RequireNonAlphanumeric = false;
            //        options.Password.RequireUppercase = false;

            //    })
            //    .AddDefaultTokenProviders()
            //    .AddDefaultUI()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            //    services.AddAuthorization();
            //    services.AddAuthentication();

            //});

        }
    }
}