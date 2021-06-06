using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Sliders")]
    public class Slider
    {
        [Key]
        public int ID_Slider { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int DisplayOrder { get; set; }

        [StringLength(50)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }

    }
}
