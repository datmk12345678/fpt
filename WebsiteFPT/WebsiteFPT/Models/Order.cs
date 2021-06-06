using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    public class Order
    {
        [Key]
        public int ID_Order { get; set; }

        [StringLength(250)]
        public string Note { get; set; }
        public decimal Total_Price { get; set; }

        [ForeignKey("ID_Guest")]
        public virtual Guest Guests { get; set; }
        public int ID_Guest { get; set; }

        public int Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }


    }
}