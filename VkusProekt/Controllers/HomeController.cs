using Microsoft.AspNetCore.Mvc;
using VkusProekt.Data.Interfaces;
using VkusProekt.ViewModels;

namespace VkusProekt.Controllers
{
	public class HomeController : Controller
	{
        private IAllBludos _bludoRep;
        
        public HomeController(IAllBludos bludoRep)
        {
            _bludoRep = bludoRep;
        }

        public ViewResult Index()
        {
            var homeBludos = new HomeViewModel
            {
                favBludos = _bludoRep.getFaveBludos
            };
            return View(homeBludos);
        }
    }
}
