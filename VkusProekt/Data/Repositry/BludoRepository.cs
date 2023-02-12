using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VkusProekt.Data.Interfaces;
using VkusProekt.Data.Models;

namespace VkusProekt.Data.Repositry
{
    public class BludoRepository : IAllBludos
    {
        private readonly AppDBContent appDBContent;

        public BludoRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Bludo> Bludos => appDBContent.Bludo.Include(c => c.Category);  //получаем все данные по определенной категории

        public IEnumerable<Bludo> getFaveBludos => appDBContent.Bludo.Where(p => p.isFavourite).Include(c => c.Category);

        public Bludo getObjectBludo(int bludoId) => appDBContent.Bludo.FirstOrDefault(p => p.id == bludoId);
    }
}
