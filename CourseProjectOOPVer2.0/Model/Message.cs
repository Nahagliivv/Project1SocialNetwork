using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public long UserId { get; set; }
        [Required]
        [ForeignKey("Dialog")]
        public long DialogId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime SendDate { get; set; }
        [Required]
        public string Username { get; set; }

        public virtual User User { get; set; }
        public virtual Dialog Dialog { get; set; }
        public Message()
        {
            SendDate = new DateTime();
        }

    }
}
