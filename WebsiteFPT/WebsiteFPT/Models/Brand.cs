using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Brands")]
    public class Brand
    {

        [Key]
        public int ID_Brand { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string Image{ get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }

        public Brand()
        {
            Image = "~/Images/Brand/dong-ho-orient-ra-as0102s10b_1608172008.jpg";
        }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}