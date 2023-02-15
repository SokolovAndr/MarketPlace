using Microsoft.AspNetCore.Mvc;
using VkusProekt.Data.Interfaces;
using VkusProekt.ViewModels;

namespace VkusProekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllBludos _bludoRep;

        public HomeController(IAllBludos bludoRep)
        {
            _bludoRep = bludoRep;

        }

        public ViewResult index()
        {
            var homeBludos = new HomeViewModel
            {
                favBludos = _bludoRep.getFaveBludos
            };
            return View(homeBludos);
        }

    }
}
