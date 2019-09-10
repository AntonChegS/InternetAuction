using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class LotCreatingModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal StartPrice { get; set; }

        public decimal BuyNowPrice { get; set; }
    }
}