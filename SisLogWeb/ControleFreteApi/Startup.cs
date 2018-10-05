using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFreteApi.Data;
using ControleFreteApi.Data.Interfaces;
using ControleFreteApi.Data.Repository;
using ControleFreteApi.Domain.Interface;
using ControleFreteApi.Domain.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace ControleFreteApi
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
            services.AddCors();

            services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("senhasupersecretaparaauth")),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });

            //services.AddScoped<IBaseFreteRepository, BaseFreteRepository>();
            //services.AddScoped<ICidadeRepository, CidadeRepository>();
            //services.AddScoped<IFreteClienteRepository, FreteClienteRepository>();
            //services.AddScoped<IOrigemDestinoRepository, OrigemDestinoRepository>();

            services.AddDbContext<SisLogFreteContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SisLogFreteConnection")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICidadeService, CidadeService>();
            services.AddTransient<ICotarFreteService, CotarFreteService>();

            // Registro do Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Controle de Frete API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
                  builder.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials());
            app.UseMvc();

           
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Controle de Frete API V1");
                c.RoutePrefix = "swagger";

            });

            app.UseMvc(routes =>
            {   
                routes.MapRoute(
                    name: "default",
                    template: "{controller=swagger}/{action=Index}");


            });
        }
    }
}
