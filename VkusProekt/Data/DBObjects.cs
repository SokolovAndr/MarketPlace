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
                        name = "Рагу домашнее",
                        shortDesc = "Щедрая порция ароматного рагу с картофелем и сочной курицей",
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
                        shortDesc = "Хрустящий слоёный десерт с большой порцией шоколадной начинки",
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
                        shortDesc = "Воздушные эклеры с нежной сливочной начинкой в яркой глазури",
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
                        shortDesc = "Традиционный пасхальный кулич в густой глазури с аккуратным золотым декором",
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
                        shortDesc = "Бисквитный торт насыщенным шоколадным вкусом, орехами и свежей голубикой",
                        longDesc = "Изысканный вкус",
                        img = "/img/chokotort.jpg",
                        price = 700,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Торт из голубики",
                        shortDesc = "Пышный десерт с творожным кремом и свежей голубикой",
                        longDesc = "Изысканный вкус",
                        img = "/img/chernika.jpg",
                        price = 750,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Печеный картофель",
                        shortDesc = "Большая порция печеной картошки с душистыми специями на гарнир",
                        longDesc = "Только из печи",
                        img = "/img/kartoshka.jpg",
                        price = 350,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Горячие блюда"]
                    },
                    new Bludo
                    {
                        name = "Зразы с грибами",
                        shortDesc = "Сочные котлеты из рубленого фарша с ароматным грибами",
                        longDesc = "Сытная мясная котлета",
                        img = "/img/kotleta.jpg",
                        price = 250,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Горячие блюда"]
                    },
                    new Bludo
                    {
                        name = "Филе куры",
                        shortDesc = "Сочное куриное филе с золотистой хрустящей корочкой",
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
                        shortDesc = "Сытная выпечка из слоёного теста с домашней сосиской",
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
                        shortDesc = "Хрустящие снеки, обжаренные в масле",
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
                        shortDesc = "Богатый кремовый торт на сочных коржах, щедро украшенный орехами и карамельными иголочками",
                        longDesc = "Изысканный вкус",
                        img = "/img/orehtort.jpg",
                        price = 690,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Макаронс",
                        shortDesc = "Порция нежных белковых пирожных с прослойкой ароматной начинки",
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
                        shortDesc = "Хрустящий слоёный десерт с большой порцией сливочной начинки",
                        longDesc = "Вкус французского завтра",
                        img = "/img/cruasan2.jpg",
                        price = 80,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Дессерты"]
                    },
                    new Bludo
                    {
                        name = "Пирожное мандарин",
                        shortDesc = "Сочный десерт с ярким цитрусовым вкусом в форме любимого фрукта",
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
