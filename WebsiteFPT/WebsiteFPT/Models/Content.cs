using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Content")]
    public class Content
    {
        [Key]
        public int ID_Content { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [ForeignKey("ID_Category")]
        public virtual Category Category { get; set; }
        public int ID_Category { get; set; }
        

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int Guarantee { get; set; }

        public bool? Status { get; set; }

        public DateTime TopHot { get; set; }

        public int ViewCount { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }


    }
}