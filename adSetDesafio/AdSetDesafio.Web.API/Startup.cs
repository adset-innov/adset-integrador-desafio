using System;
using System.Reflection;
using System.Text;
using AdSetDesafio.Domain.Common.Repositories;
using AdSetDesafio.Infrastructure.Sql.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace AdSetDesafio.Web.API
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
            services.AddMvc()
                .AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddControllers();
            //services.AddSession();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProgramaInovacoes.Web.API", Version = "v1" });
            });
            services.AddCors((b) =>
            {
                b.AddPolicy("policy", (p) =>
                {
                    p.WithOrigins(Configuration["AllowedHosts"].Split(','))
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                });
            });
            services.AddScoped(typeof(IVeiculoRepository), typeof(VeiculoRepository));
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdSetDesafio.Web.API v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("policy");

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}