using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class LotView
    {
        public int? Id { get; set; }

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