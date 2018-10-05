using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogWeb.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SegurancaAPI.Data;
using SegurancaAPI.Models;
using SegurancaAPI.Services;

namespace LogWeb
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

            services.AddMemoryCache();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ITokenCache, TokenCache>();

            services.AddAuthorization(o =>
            {
                string cliente = PerfisDeAcesso.Perfis.Cliente.ToString();
                string parceiro = PerfisDeAcesso.Perfis.Parceiro.ToString();
                string admin = PerfisDeAcesso.Perfis.Admin.ToString();
                string colaborador = PerfisDeAcesso.Perfis.Colaborador.ToString();

                o.AddPolicy(parceiro, p => p.RequireClaim("perfil", parceiro));
                o.AddPolicy(cliente, p => p.RequireClaim("perfil", cliente));
                o.AddPolicy(admin, p => p.RequireClaim("perfil",admin));
                o.AddPolicy(colaborador, p => p.RequireClaim("perfil", colaborador));
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "areas",
                 template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");


            });


        }
    }
}

