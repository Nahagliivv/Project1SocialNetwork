using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsActivate { get; set; } = false;

        /////////////////////Навигационные св-ва
        public virtual Page PageInfo { get; set; }
        public virtual List<Like> Likes { get; set; }
        public virtual List<Post> Posts { get; set; }
        [InverseProperty("User1")]
        public virtual List<Friends> Friends { get; set; }
        [InverseProperty("User2")]
        public virtual List<Friends> Friends2 { get; set; }
        [InverseProperty("SenderUser")]
        public virtual List<FriendsRequest> FriendsRequests { get; set; }
        [InverseProperty("RecieverUser")]
        public virtual List<FriendsRequest> FriendsRequests2 { get; set; }
        [InverseProperty("User1")]
        public virtual List<Dialog> Dialog1 { get; set; }
        [InverseProperty("User2")]
        public virtual List<Dialog> Dialog2 { get; set; }
        public virtual List<Message> Messages { get; set; }
        public User()
        {
            Likes = new List<Like>();
            Posts = new List<Post>();
           Friends = new List<Friends>();
           FriendsRequests = new List<FriendsRequest>();
           Friends2 = new List<Friends>();
           FriendsRequests2 = new List<FriendsRequest>();
            Dialog2 = new List<Dialog>();
            Dialog1 = new List<Dialog>();
            Messages = new List<Message>();
        }
    }
}
