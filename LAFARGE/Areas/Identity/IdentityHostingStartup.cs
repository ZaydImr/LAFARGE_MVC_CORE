using System;
using LAFARGE.Areas.Identity.Data;
using LAFARGE.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LAFARGE.Areas.Identity.IdentityHostingStartup))]
namespace LAFARGE.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LAFARGEContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("LAFARGEContextConnection")));

                services.AddDefaultIdentity<LAFARGEOperator>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LAFARGEContext>();
            });
        }
    }
}