using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("Post")]
        [Required]
        public long Post_Id { get; set; }
        [ForeignKey("User")]
        [Required]
        public long User_Id { get; set; }
        [Required]
        public string UserFullName { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime PublicDate { get; set; }

        public Comment()
        {
            PublicDate = new DateTime();
        }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
