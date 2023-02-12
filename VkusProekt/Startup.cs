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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllBludos, BludoRepository>();
            //для объединения интерфейса и класса который реализует интерфейс
            //интерфейс IAllBludos реализуется в классe MockBludos

            services.AddTransient<IBludosCategory, CategoryRepository>();
            //интерфейс IBludosCategory реализуется в классe MockBludos

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            DBObjects.Initial(app);
        }
    }
}
