using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("warehouses")]
    public class warehouse
    {
        [Key]
        public int ID_warehouse { get; set; }

        [ForeignKey("ID_Product")]
        public virtual Product Products { get; set; }
        public int ID_Product { get; set; }

        public int Code { get; set; }

        public int Quantity { get; set; }
    }
}