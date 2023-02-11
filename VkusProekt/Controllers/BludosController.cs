using Microsoft.AspNetCore.Mvc;
using VkusProekt.Data.Interfaces;

namespace VkusProekt.Controllers
{
    public class BludosController : Controller
    {
        //здесь будут функции при вызове которых будет возврщаться тип данных ViewResult (результат в виде html страницы)

        private readonly IAllBludos _allBludos;
        private readonly IBludosCategory _allCategories;

        public BludosController(IAllBludos iAllBludos, IBludosCategory iBludosCat)
        {
            _allBludos = iAllBludos;
            _allCategories = iBludosCat;
        }

        public ViewResult List() //для возврата html страницы
        {
            var bludos = _allBludos.Bludos;
            return View(bludos);
        }
    }
}