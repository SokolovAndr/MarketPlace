using System.Collections.Generic;
using VkusProekt.Data.Models;

namespace VkusProekt.Data.Interfaces
{
    public interface IBludosCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
