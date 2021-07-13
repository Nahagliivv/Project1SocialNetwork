using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model.DB
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
            : base("EFBDConnection")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Page> PageInfo { get; set; }
        public DbSet<Img> Imgs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<FriendsRequest> FriendsRequests { get; set; }
        public DbSet<Dialog> Dialogs { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
