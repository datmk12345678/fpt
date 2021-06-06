using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("altributes")]
    public class altribute
    {
        [Key]
        public int ID_altribute { get; set; }

        public string name { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; } = System.DateTime.Now;
    }
}