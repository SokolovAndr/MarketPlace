using System.Collections.Generic;

namespace VkusProekt.Data.Models
{
    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string desc { get; set; }   // описание категории
        public List <Bludo> bludos { get; set; } //у каждой категории есть много блюд

    }
}
