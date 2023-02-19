using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VkusProekt.Data.Interfaces;
using VkusProekt.Data.Models;
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
        [Route("Bludos/List")]
        [Route("Bludos/List/{category}")]
        public ViewResult List(string category) //для возврата html страницы
        {
            string _category = category;
            IEnumerable<Bludo> bludos = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                bludos = _allBludos.Bludos.OrderBy(i => i.id);
            }
            else
            {
                if(string.Equals("hotfood", category, StringComparison.OrdinalIgnoreCase)) //Горячие блюда
                {
                    bludos = _allBludos.Bludos.Where(i => i.Category.categoryName.Equals("Горячие блюда")).OrderBy(i => i.id);
                    currCategory = "Горячие блюда";
                }
                else if (string.Equals("deserts", category, StringComparison.OrdinalIgnoreCase)) 
                { 
                    bludos = _allBludos.Bludos.Where(i => i.Category.categoryName.Equals("Дессерты")).OrderBy(i => i.id);
                    currCategory = "Дессерты";
                }
                //currCategory = _category;
               
            }
            var bludoObj = new BludosListViewModel
            {
                allBludos = bludos,
                currCategory = currCategory
            };

            ViewBag.Title = "Меню"; //для передачи данных внутрь html шаблона
            //BludosListViewModel obj = new BludosListViewModel();
            //obj.allBludos = _allBludos.Bludos;
            //obj.currCategory = "Блюда";
            return View(bludoObj);
        }
    }
}