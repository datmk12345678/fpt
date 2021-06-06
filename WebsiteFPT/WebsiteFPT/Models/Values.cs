using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    public class Values
    {
        [Key]
        public int? ID_Values { get; set; }

        public string Value { get; set; }

        [ForeignKey("ID_altribute")]
        public virtual altribute altributes { get; set; }
        public int ID_altribute { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }
    }
}