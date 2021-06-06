using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("attr_orders")]
    public class attr_order
    {
        [Key]
        public int ID_attr_order { get; set; }

        [StringLength(250)]
        public string Color { get; set; }

        [StringLength(250)]
        public string Size { get; set; }

        public int Status { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ID_Order")]
        public virtual Order Orders { get; set; }
        public int ID_Order { get; set; }

        [ForeignKey("ID_Product")]
        public virtual Product Products { get; set; }
        public int ID_Product { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }


    }
}