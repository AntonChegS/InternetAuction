using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
   public interface ISearchService
    {
        IEnumerable<LotDTO> FindByPrice(decimal price);
        IEnumerable<LotDTO> FindByWord(string word);
        IEnumerable<LotDTO> FindByCategory(int category);
        IEnumerable<LotDTO> GetAll();
        LotDTO Get(int? id);
    }
}
