using System.Collections.Generic;
using VkusProekt.Data.Models;

namespace VkusProekt.ViewModels
{
    public class BludosListViewModel
    {
        public IEnumerable <Bludo> allBludos { get; set; }
        public string currCategory { get; set; } //Curr - сокр. от current - текущий. В нее помещаем категорию, с которой будем работать в тек. момент.
    }
}
