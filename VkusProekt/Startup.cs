using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
using VkusProekt.Data;
using VkusProekt.Data.Interfaces;
using VkusProekt.Data.mocks;
using Microsoft.EntityFrameworkCore;
using VkusProekt.Data.Repositry;

namespace VkusProekt
{
    public class Startup
    {
        private IConfigurationRoot _confstring;

        public Startup(IHostingEnvironment hostEnv) {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllBludos, BludoRepository>();
            //для объединения интерфейса и класса который реализует интерфейс
            //интерфейс IAllBludos реализуется в классe MockBludos

            services.AddTransient<IBludosCategory, CategoryRepository>();
            //интерфейс IBludosCategory реализуется в классe MockBludos

            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }           
        }
    }
}
