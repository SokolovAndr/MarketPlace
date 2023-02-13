//using VkusProekt.Data.Repositry;
using VkusProekt.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VkusProekt.ViewModels;
using System.Linq;
using VkusProekt.Data.Interfaces;

namespace VkusProekt.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllBludos _bludoRep;
        private readonly ShopCart _shopCart;

        public ShopCartController (IAllBludos bludoRep, ShopCart shopCart)
        {
            _bludoRep = bludoRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _bludoRep.Bludos.FirstOrDefault(i => i.id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");  //переадресация на старничку с корзиной
        }

    }
}
