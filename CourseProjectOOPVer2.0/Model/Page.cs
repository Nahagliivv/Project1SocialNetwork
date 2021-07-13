using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CourseProjectOOPVer2._0.Model
{
    public class Page
    {
        [Key]
        [ForeignKey("User")]
        public long Id { get; set; }
        public string Sex { get; set; }
        public Nullable<DateTime> BirthDay { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string AboutMyself { get; set; }

        ////////////////////////Внешняя зависимость от User
        public virtual User User { get; set; }
        ///////////////////////////////////////////////////
        public virtual Img  Img { get; set; }
        //////////////////////////////////////////////////
        public virtual List<Post> Posts { get;set; }

        public Page()
        {
            BirthDay = new DateTime();
            Posts = new List<Post>();
        }
        public Page(Page mpi) //для копирования объекта текущего класса
        {
            BirthDay = new DateTime();
            Id = mpi.Id;
            Sex = mpi.Sex;
            BirthDay = mpi.BirthDay;
            City = mpi.City;
            Country = mpi.Country;
            AboutMyself = mpi.AboutMyself;
            Posts = new List<Post>();
        }
    }
}
