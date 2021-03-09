using Business;
using Business.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.DataAccessObject;
using DataAccessLayer.DataAccessObject.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Data;

namespace WebApp
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

            services.AddDbContext<PetPlanetContext>(options =>
                       options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            services.AddScoped<PetPlanetContext>();
            services.AddScoped<IClientDataAccessObject, ClientDataAccessObject>();
            services.AddScoped<IClientBusinessObject, ClientBusinessObject>();

            services.AddScoped<IEmployeeDataAccessObject, EmployeeDataAccessObject>();
            services.AddScoped<IEmployeeBusinessObject, EmployeeBusinessObject>();

            services.AddScoped<IPetDataAccessObject, PetDataAccessObject>();
            services.AddScoped<IPetBusinessObject, PetBusinessObject>();

            services.AddScoped<IProductDataAccessObject, ProductDataAccessObject>();
            services.AddScoped<IProductBusinessObject, ProductBusinessObject>();

            services.AddScoped<IStoreDataAccessObject, StoreDataAccessObject>();
            services.AddScoped<IStoreBusinessObject, StoreBusinessObject>();

            services.AddScoped<IServiceDataAccessObject, ServiceDataAccessObject>();
            services.AddScoped<IServiceBusinessObject, ServiceBusinessObject>();          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            
        }
    }
}
