using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Variants")]
    public class Variant
    {
        [Key]
        public int? ID_Variant { get; set; }

        [ForeignKey("ID_Price")]
        public virtual Price Prices { get; set; }
        public int ID_Price { get; set; }

        [ForeignKey("ID_Product")]
        public virtual Product Products { get; set; }
        public int ID_Product { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }

    }
}