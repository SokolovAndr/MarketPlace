using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using VkusProekt.Data.Models;

namespace VkusProekt.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content) //эта функция каждый раз будет добавлять объекты в БД
        {
            
            

            if (!content.Category.Any())  //если объекта нет, то добавляем
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Bludo.Any()) {
                content.AddRange(
                    new Bludo
                    {
                        name = "Рагу",
                        shortDesc = "Домашнее",
                        longDesc = "Вкусное, сытное, мясное",
                        img = "/img/ragu.jpg",
                        price = 500,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Горячие блюда"]
                    },
                    new Bludo
                    {
                        name = "Круассан",
                        shortDesc = "Изысканный",
                        longDesc = "Вкус французского завтра",
                        img = "/img/cruasan.jpg",
                        price = 100,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Эклер",
                        shortDesc = "Нежный",
                        longDesc = "Классический",
                        img = "/img/ekler.jpg",
                        price = 90,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Дессерты"]
                    }
                );
            }

            content.SaveChanges(); 

        }
            private static Dictionary<string, Category> category;
            public static Dictionary <string, Category> Categories
            {
            get {
                if (category == null)
                {
                    var list = new Category[]
                    {
                    new Category{categoryName = "Горячие блюда", desc = "Вкусные горячие блюда от нашего шеф-повара!"},
                    new Category{categoryName = "Дессерты", desc = "Вкуснешие дессерты!"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }

    }
}

