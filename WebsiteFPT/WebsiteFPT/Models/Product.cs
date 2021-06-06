using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteFPT.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ID_Product { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [AllowHtml]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Image1 { get; set; }

        [StringLength(250)]
        public string Image2 { get; set; }

        [StringLength(250)]
        public string Image3 { get; set; }

       

        [ForeignKey("ID_Price")]
        public virtual Price Prices { get; set; }
        public int ID_Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("ID_Brand")]
        public virtual Brand Brands { get; set; }
        public int ID_Brand { get; set; }

        [ForeignKey("ID_Category")]
        public virtual Category Categories { get; set; }
        public int ID_Category { get; set; }

        [AllowHtml]
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [AllowHtml]
        [Column(TypeName = "ntext")]
        public string Guarantee { get; set; }

        public bool Hot { get; set; }

        public bool Gioitinh { get; set; }

        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }
        public object Values_products { get; internal set; }
    }
 
}