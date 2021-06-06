using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    [Table("Feedback")]
    public class FeedBack
    {
        [Key]
        public int ID_Feedback { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [ForeignKey("ID_Guest")]
        public virtual Guest Guests { get; set; }
        public int ID_Guest { get; set; }

        [ForeignKey("ID_Users")]
        public virtual User Users { get; set; }
        public int ID_Users { get; set; }

        [StringLength(50)]
        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created_At { get; set; }


    }
}