using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Template_NetCoreApi_DDD
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<Infra.Context.AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AppDbContext")));

            services.AddScoped<Service.Services.BankAccountService>();
            services.AddScoped<Service.Services.BankAccountLaunchesService>();
            services.AddScoped<Service.Services.TransactionsService>();

            services.AddScoped<Service.Validators.BankAccountLaunchesValidator>();
            services.AddScoped<Service.Validators.BankAccountValidator>();

            services.AddScoped<Infra.Repository.BankAccountRepository>();
            services.AddScoped<Infra.Repository.BankAccountLaunchesRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Template Net Core API (DDD)", Version = "V1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Template .Net Core API (DDD)"));

        }
    }
}
