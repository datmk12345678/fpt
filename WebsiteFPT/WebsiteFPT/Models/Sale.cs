using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Sales")]
    public class Sale
    {
        [Key]
        public int ID_Sale { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [ForeignKey("ID_Product")]
        public virtual Product Products { get; set; }
        public int ID_Product { get; set; }

        [StringLength(250)]
        public string Color { get; set; }

        [StringLength(250)]
        public string Size { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }

    }
}