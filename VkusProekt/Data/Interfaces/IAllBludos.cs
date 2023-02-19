using System.Collections.Generic;
using VkusProekt.Data.Models;

namespace VkusProekt.Data.Interfaces
{
    public interface IAllBludos
    {
        IEnumerable<Bludo> Bludos { get; }
        IEnumerable<Bludo> getFaveBludos { get; }
        Bludo getObjectBludo(int bludoId);
    }
}
