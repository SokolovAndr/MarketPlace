using System.Collections.Generic;
using VkusProekt.Data.Interfaces;
using VkusProekt.Data.Models;


namespace VkusProekt.Data.mocks
{
    public class MockCategory : IBludosCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{categoryName = "Горячие блюда", desc = "Вкусные горячие блюда от нашего шеф-повара!"},
                    new Category{categoryName = "Салаты", desc = "Свежайшие салаты!"}
                };
            }
        }
    }
}