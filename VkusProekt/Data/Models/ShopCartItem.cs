using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VkusProekt.Data.Models

{
    public class ShopCartItem  //эта модель описывает товар в корзине
    {
        public int id { get; set; }
        public Bludo bludo { get; set; }
        public int price { get; set; }
        public string ShopCartId { get; set; }
    }
}
