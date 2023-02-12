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
                        name = "Рагу",
                        shortDesc = "Домашнее",
                        longDesc = "Вкусное, сытное, мясное", 
                        img = "/img/ragu.jpg",
                        price = 500,
                        isFavourite = true,
                        available = true,
                        Category = _categoryBludos.AllCategories.First()
                    },
                    new Bludo {
                        name = "Круассан",
                        shortDesc = "Изысканный",
                        longDesc = "Вкус французского завтра",
                        img = "/img/cruasan.jpg",
                        price = 100,
                        isFavourite = true,
                        available = true,
                        Category = _categoryBludos.AllCategories.Last()
                    },
                    new Bludo {
                        name = "Эклер",
                        shortDesc = "Нежный",
                        longDesc = "Классический",
                        img = "/img/ekler.jpg",
                        price = 90,
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
