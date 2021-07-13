using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class FriendsRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Request_Id { get; set; }
        //[Required]
        //[ForeignKey("User1")]

        public virtual User SenderUser { get; set; }
        //[Required]
        //[ForeignKey("User2")]
        public virtual User RecieverUser { get; set; }

        //public virtual User User1 { get; set; }
        //public virtual User User2 { get; set; }
    }
}
