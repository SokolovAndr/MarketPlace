using System;
using System.Collections.Generic;
using System.Linq;
using VkusProekt.Data.Interfaces;
using VkusProekt.Data.Models;

namespace VkusProekt.Data.mocks
{
    public class MockBludos : IAllBludos
    {
        private readonly IBludosCategory _categoryBludos = new MockCategory();  //переменная для того, чтобы указывать к какой категории относится объект


        public IEnumerable<Bludo> Bludos
        {
            get
            {
                return new List<Bludo>
                {
                    new Bludo {
                        name = "Суп",
                        shortDesc = "Домашний",
                        longDesc = "Вкусный, сытный, мясной", 
                        //img = "https://e3.edimdoma.ru/data/posts/0002/1924/21924-ed4_wide.jpg?1631188925",
                        img = "",
                        price = 500,
                        isFavourite = true,
                        available = true,
                        Category = _categoryBludos.AllCategories.First()
                    },
                    new Bludo {
                        name = "Цезарь",
                        shortDesc = "Изысканный",
                        longDesc = "Популярное блюдо американской кухни",
                        //img = "https://static.1000.menu/res/640/img/content-v2/eb/79/19516/salat-cezar-klassicheskii-s-kuricei_1611309331_16_max.jpg",
                        img = "",
                        price = 450,
                        isFavourite = true,
                        available = true,
                        Category = _categoryBludos.AllCategories.Last()
                    },
                    new Bludo {
                        name = "Крабовый",
                        shortDesc = "один из самых популярных салатов",
                        longDesc = "Классический крабовый салат с огурцом",
                        //img = "https://eda.ru/img/eda/c620x415/s1.eda.ru/StaticContent/Photos/150116162013/150122200907/p_O.jpg.webp",
                        img = "",
                        price = 400,
                        isFavourite = true,
                        available = true,
                        Category = _categoryBludos.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Bludo> getFaveBludos { get; set; }

        public Bludo getObjectBludo(int bludoId)
        {
            throw new NotImplementedException();
        }
    }
}
