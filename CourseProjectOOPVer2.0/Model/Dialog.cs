using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class Dialog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public DateTime DateSendLastMessage {get;set;}
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }

        public virtual List<Message> Messages { get; set; }
        public Dialog()
        {
            Messages = new List<Message>();
        }

    }
}
