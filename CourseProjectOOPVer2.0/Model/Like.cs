using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class Like
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public long User_ID { get; set; }
        [Required]
        [ForeignKey("Post")]
        public long Post_ID { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
