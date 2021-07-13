using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Text { get; set; }
        [ForeignKey("MyPageInfo")]
        [Required]
        public long WallID { get; set; }
        [Required]
        public DateTime PublicDate { get; set; }
        [Required]
        public string UserFullName { get; set; }
        public virtual Page MyPageInfo { get; set; }
        public virtual List<Like> Likes { get; set; }
        public virtual List<Comment> Comment { get; set; }
        public Post()
        {
            Likes = new List<Like>();
            Comment = new List<Comment>();
        }
    }
}
