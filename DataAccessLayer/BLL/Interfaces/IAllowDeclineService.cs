using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
   public interface IAllowDeclineService
    {
        void AllowLot(int id);
        void DeclineLot(int id);
    }
}
