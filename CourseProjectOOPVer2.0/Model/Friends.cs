using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class Friends
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        //[Required]
        //[Display(Name = "User1")]
        //[ForeignKey("U1")]
        public virtual User User1 { get; set; }
        //[Required]
        //[Display(Name = "User2")]
        //[ForeignKey("U2")]
        public virtual User User2 { get; set; }

        //public virtual User U1 { get; set; }
        //public virtual User U2 { get; set; }

    }
}
