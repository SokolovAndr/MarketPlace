using Microsoft.AspNetCore.Mvc;
using VkusProekt.Data.Interfaces;
using VkusProekt.ViewModels;

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
            ViewBag.Title = "Меню"; //для передачи данных внутрь html шаблона
            BludosListViewModel obj = new BludosListViewModel();
            obj.allBludos = _allBludos.Bludos;
            obj.currCategory = "Блюда";
            return View(obj);
        }
    }
}