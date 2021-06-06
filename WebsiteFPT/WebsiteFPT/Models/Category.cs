using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Categorys")]
    public class Category
    {
        [Key]
        public int ID_Category { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }


    }
}