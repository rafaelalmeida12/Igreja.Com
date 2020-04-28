using Igreja.Com.Aplicacao.EntidadesApp;
using Igreja.Com.Aplicacao.InterfaceApp;
using Igreja.Com.Dominio.Interface;
using Igreja.Com.Infra.Configuracao;
using Igreja.Com.Infra.Repositorio;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Igreja.Com.Web
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
            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddRazorPages();

            //Dominio & Repositorio
            services.AddSingleton(typeof(InterfaceBase<>), typeof(RepositorioBase<>));
            services.AddSingleton<InterfaceDizimo, RepositorioDizimo>();
            services.AddSingleton<InterfaceMembro, RepositorioMembro>();
            services.AddSingleton<InterfaceCargo, RepositorioCargo>();
            services.AddSingleton<InterfaceCulto, RepositorioCulto>();


            //Aplica��o & Aplica��o
            services.AddSingleton<InterfaceDizimoApp, DizimoApp>();
            services.AddSingleton<InterfaceMembroApp, MembroApp>();
            services.AddSingleton<InterfaceCargoApp, CargoApp>();
            services.AddSingleton<InterfaceCultoApp, CultoApp>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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