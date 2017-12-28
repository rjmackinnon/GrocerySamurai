using MagicHamster.GrocerySamurai.BusinessLayer.Interfaces;
using MagicHamster.GrocerySamurai.BusinessLayer.Processes;
using MagicHamster.GrocerySamurai.DataAccess.Interfaces;
using MagicHamster.GrocerySamurai.DataAccess.Repositories;
using MagicHamster.GrocerySamurai.DataAccess.UnitsOfWork;
using MagicHamster.GrocerySamurai.Model;
using MagicHamster.GrocerySamurai.Model.Common;
using MagicHamster.GrocerySamurai.Model.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MagicHamster.GrocerySamurai.ServiceLayer
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
            services.AddMvc();

            var connectionString = Configuration.GetConnectionString("GroceryContext");
            services.AddEntityFrameworkNpgsql().AddDbContext<GroceryContext>(options => options.UseNpgsql(connectionString));

            // Register application services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, GroceryContext>();
            registerServices<Aisle, BaseProcess<Aisle>>(services);
            registerServices<AppUser, BaseProcess<AppUser>>(services);
            registerServices<GroceryListItem, BaseProcess<GroceryListItem>>(services);
            registerServices<GroceryList, BaseProcess<GroceryList>>(services);
            registerServices<Item, BaseProcess<Item>>(services);
            registerServices<StoreItem, BaseProcess<StoreItem>>(services);
            registerServices<Store, BaseProcess<Store>>(services);
        }

        private void registerServices<T, TProcess>(IServiceCollection services)
            where T : Entity
            where TProcess : class, IBaseProcess<T>
        {
            services.AddScoped<IRepository<T>, Repository<T>>();
            services.AddScoped<IBaseProcess<T>, TProcess>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
