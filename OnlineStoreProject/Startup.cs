using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineStoreProject.Data;
using OnlineStoreProject.Data.DAL;
using OnlineStoreProject.Data.DAL.Interfaces;
using OnlineStoreProject.Models;
using System;

namespace OnlineStoreProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            
            services.AddDbContext<OnlineStoreContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("LocalSQLServer"))
            );
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            });

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = "Cart";

            }
            );


            services.AddScoped<UnitOfWork>();          
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<Discount>, DiscountRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IRepository<ShopBasketRow>, ShopBasketRowRepository>();
            services.AddScoped<IRepository<ShopBasket>, ShopBasketRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IShopBasketRowRepository, ShopBasketRowRepository>();
            services.AddScoped<IShopBasketRepository, ShopBasketRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddHttpContextAccessor();

            // TODO: Check options to use in Identity: 
            // https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-configuration?view=aspnetcore-5.0#identity-options
            services.AddIdentityCore<OnlineStoreUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<OnlineStoreContext>();

/*            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            services.AddAuth(jwtSettings);

            services.AddAutoMapper(typeof(Startup));*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Development");

            app.UseSession();

            //app.UseAuth();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
