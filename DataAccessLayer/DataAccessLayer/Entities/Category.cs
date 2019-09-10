using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
   public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int? ParrentCategoryId { get; set; }

        public virtual Category ParrentCategory { get; set; }


        public virtual List<Category> Categories { get; set; }


    }
}
