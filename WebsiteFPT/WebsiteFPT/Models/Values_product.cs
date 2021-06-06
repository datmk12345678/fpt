using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Values_products")]
    public class Values_product
    {
        [Key]
        public int ID_Values_product { get; set; }

        [ForeignKey("ID_Values")]
        public virtual Values Values { get; set; }
        public int ID_Values { get; set; }

        [ForeignKey("ID_Product")]
        public virtual Product Products { get; set; }
        public int ID_Product { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }
    }
}