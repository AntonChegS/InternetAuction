using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public class LotDTO
    {
       
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal StartPrice { get; set; }

        public decimal CurrPrice { get; set; }

        public decimal BuyNowPrice { get; set; }

        
        public bool IsOpen { get; set; }

       
        public bool IsAllowed { get; set; }

        public string CategoryName { get; set; }
       
    }
}
