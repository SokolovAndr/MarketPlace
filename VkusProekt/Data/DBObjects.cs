using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace VkusProekt.Data
{
    public class DBObjects
    {
        public static void Initial(IApplicationBuilder app) //эта функция каждый раз будет добавлять объекты в БД
        {
            AppDBContent content = app.ApplicationServices.GetRequiredService<AppDBContent>();
        
            if(!content.Category.Any())  //если объекта нет, то добавляем
            {

            }
        }
    }
}
