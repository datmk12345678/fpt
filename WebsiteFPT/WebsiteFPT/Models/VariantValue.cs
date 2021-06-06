using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    public class VariantValue
    {
        [Key]
        public int ID_VariantValue { get; set; }

        public int ID_Variant { get; set; }

        public int ID_Values { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }

        public virtual Values Values { get; set; }
        public virtual Variant Variants { get; set; }
    }
}