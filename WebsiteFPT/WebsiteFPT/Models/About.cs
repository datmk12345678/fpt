using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteFPT.Models
{
    [Table("Abouts")]
    public partial class About
    {
        [Key]
        public int ID_About { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn nhập tên bài viết")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn nhập mô tả bài viết")]
        [AllowHtml]
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public string Image { get; set; }
        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }


    }
}