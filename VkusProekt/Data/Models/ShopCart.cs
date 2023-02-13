using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text;


namespace VkusProekt.Data.Models
{
    public class ShopCart  //модель которая описывает всю корзину
    {
        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }
    
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;  //создали сессию
            var context = services.GetServices<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();//если не существует cartId, то будем создавать новый идентификатор
            
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };  //так не работает, пошли дальше (16.30)
            
            //return new ShopCart((AppDBContent)context) { ShopCartId = shopCartId }; //так тоже не работает
        }

        public void AddToCart(Bludo bludo)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                bludo = bludo,
                price = bludo.price
            });
            appDBContent.SaveChanges();
        }

        public List <ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.bludo).ToList();
        }

    }
}
