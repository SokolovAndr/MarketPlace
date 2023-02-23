using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using VkusProekt.Data.Models;

namespace VkusProekt.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content) //эта функция каждый раз будет добавлять объекты в БД
        {            
            if (!content.Category.Any())  //если объекта нет, то добавляем
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Bludo.Any())
            {
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
                        name = "Круассан шоколадный",
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
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Кулич",
                        shortDesc = "Пасхальный",
                        longDesc = "Классический пасхальный",
                        img = "/img/kulich.jpg",
                        price = 50,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Торт шоколадный",
                        shortDesc = "Шоколадный",
                        longDesc = "Изысканный вкус",
                        img = "/img/chokotort.jpg",
                        price = 700,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Торт черничный",
                        shortDesc = "Черничный",
                        longDesc = "Изысканный вкус",
                        img = "/img/chernika.jpg",
                        price = 750,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Картошка запеченая",
                        shortDesc = "Запеченая",
                        longDesc = "Только из печи",
                        img = "/img/kartoshka.jpg",
                        price = 350,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Горячие блюда"]
                    },
                    new Bludo
                    {
                        name = "Котлета",
                        shortDesc = "Мясная",
                        longDesc = "Сытная мясная котлета",
                        img = "/img/kotleta.jpg",
                        price = 250,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Горячие блюда"]
                    },
                    new Bludo
                    {
                        name = "Курица запеченая",
                        shortDesc = "Курица запеченая",
                        longDesc = "Большой сытный кусок",
                        img = "/img/kurica.jpg",
                        price = 200,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Горячие блюда"]
                    },
                    new Bludo
                    {
                        name = "Сосиска в тесте",
                        shortDesc = "Сосиска в тесте",
                        longDesc = "Сочная сосиска в тесте",
                        img = "/img/sosiska.jpg",
                        price = 70,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Луковые колечки",
                        shortDesc = "Луковые колечки",
                        longDesc = "Вкусные дуковые колечки",
                        img = "/img/kolechki.jpg",
                        price = 120,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Горячие блюда"]
                    },
                    new Bludo
                    {
                        name = "Торт ореховый",
                        shortDesc = "Ореховый",
                        longDesc = "Изысканный вкус",
                        img = "/img/orehtort.jpg",
                        price = 690,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Зефир 9 шт.",
                        shortDesc = "Набор зефира",
                        longDesc = "Неповторимый вкус",
                        img = "/img/zefir.jpg",
                        price = 250,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Круассан воздушный",
                        shortDesc = "Изысканный",
                        longDesc = "Вкус французского завтра",
                        img = "/img/cruasan2.jpg",
                        price = 80,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Дессерт авторский",
                        shortDesc = "Авторский",
                        longDesc = "Загадка",
                        img = "/img/avtor.jpg",
                        price = 105,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дессерты"]
                    }
                    );
            }
            content.SaveChanges();

        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[] {
                        new Category { categoryName = "Горячие блюда", desc = "Вкусные горячие блюда от нашего шеф-повара!" },
                        new Category { categoryName = "Дессерты", desc = "Вкуснейшие дессерты!" }
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
