using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int ID_Contact { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }


    }
}