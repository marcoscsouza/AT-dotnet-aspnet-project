using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMVC.Areas.Identity.Data;
using WebMVC.Data;

[assembly: HostingStartup(typeof(WebMVC.Areas.Identity.IdentityHostingStartup))]
namespace WebMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityATContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityATContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityATContext>();
            });
        }
    }
}