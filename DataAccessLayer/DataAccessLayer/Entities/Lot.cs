using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Lot
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int StartPrice { get; set; }

        public int CurrPrice { get; set; }

        public int BuyNowPrice { get; set; }

       
        public bool IsOpen { get; set; }

       
        public bool IsAllowed { get; set; }
     
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
           

    }
}
