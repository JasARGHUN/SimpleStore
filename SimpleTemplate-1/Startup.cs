using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SimpleTemplate_1.Models;
using Microsoft.AspNetCore.Identity;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Http;

namespace SimpleTemplate_1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:SimpleTemplate:ConnectionString"]));//получаем данные конфигурации из appsettings.json.
            services.AddDbContext<AppIdentityDbContext>(options => 
                options.UseSqlServer(Configuration["Data:SimpleTemplateIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IProductRepository, EFProductRepository>(); //интерфейс получает экземпл€р класса FakeProductRepository.
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<IInfoRepository, EFInfoRepository>();
            services.AddMvc();
            services.AddPaging(options => {
                options.ViewName = "Bootstrap4";
                options.HtmlIndicatorDown = " <span>&darr;</span>";
                options.HtmlIndicatorUp = " <span>&uarr;</span>";
            });
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseHsts();
            }
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
            ApplicationNameRepository.SeedData(app);
        }
    }
}
