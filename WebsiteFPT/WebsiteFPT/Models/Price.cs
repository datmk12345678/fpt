using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Prices")]
    public class Price
    {
        [Key]
        public int ID_Price { get; set; }
        public int Prices { get; set; }
        public int PromotionPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }
    }
}