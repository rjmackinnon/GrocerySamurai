﻿namespace MagicHamster.GrocerySamurai.ServiceLayer
{
    using BusinessLayer.Interfaces;
    using BusinessLayer.Processes;
    using DataAccess.Interfaces;
    using DataAccess.Repositories;
    using DataAccess.UnitsOfWork;
    using JetBrains.Annotations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Model;
    using Model.Common;
    using Model.Entities;

    [UsedImplicitly]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [UsedImplicitly]
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = Configuration.GetConnectionString("GroceryContext");
            services.AddEntityFrameworkNpgsql().AddDbContext<GroceryContext>(options => options.UseNpgsql(connectionString));

            // Register application services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, GroceryContext>();
            registerUserFilterServices<Aisle, BaseUserFilterProcess<Aisle>>(services);
            registerServices<GroceryListItem, BaseProcess<GroceryListItem>>(services);
            registerServices<GroceryList, GroceryListProcess>(services);
            registerUserFilterServices<Item, BaseUserFilterProcess<Item>>(services);
            registerServices<StoreItem, BaseProcess<StoreItem>>(services);
            registerUserFilterServices<Store, BaseUserFilterProcess<Store>>(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private static void registerServices<T, TProcess>(IServiceCollection services)
            where T : Entity
            where TProcess : class, IBaseProcess<T>
        {
            services.AddScoped<IRepository<T>, Repository<T>>();
            services.AddScoped<IBaseProcess<T>, TProcess>();
        }

        private static void registerUserFilterServices<T, TProcess>(IServiceCollection services)
            where T : UserFilter
            where TProcess : class, IBaseUserFilterProcess<T>
        {
            services.AddScoped<IRepository<T>, Repository<T>>();
            services.AddScoped<IBaseUserFilterProcess<T>, TProcess>();
        }
    }
}
