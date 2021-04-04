using e_commerce_sample.Core.Interface;
using e_commerce_sample.Infra.DBContext;
using e_commerce_sample.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce_sample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(
                option => option.UseSqlServer(
                    Configuration.GetConnectionString("DB_EntityString"),
                    x=>x.MigrationsAssembly("e-commerce-sample.Database")
                    ), 
                ServiceLifetime.Transient
                );

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(180);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddScoped<IUsers, UserRepo>();
            services.AddScoped(typeof(ICategory<>),typeof(CategoryRepo<>));
            services.AddScoped(typeof(ICarts<>), typeof(CartsRepo<>));
            services.AddScoped(typeof(IProduct<>), typeof(ProductRepo<>));
            services.AddScoped(typeof(IOrder), typeof(OrderRepo));
            services.AddScoped(typeof(ICustomerOrder<>), typeof(CustomerOrderRepo<>));
            services.AddScoped(typeof(IOrderManagement), typeof(OrderManagementRepo));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Accounts}/{action=Login}/{id?}");
            });
        }

        private static void UpdateDatabase(IApplicationBuilder app) {
            using (var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DBContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
