using System.Collections.Generic;
using VkusProekt.Data.Interfaces;
using VkusProekt.Data.Models;

namespace VkusProekt.Data.Repositry
{
    public class CategoryRepository : IBludosCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
