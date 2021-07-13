using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class Img
    {
        [Key]
        [ForeignKey("MyPageInfo")]
        public long Id { get; set; }
        [Required]
        public byte[] Data { get;  set; }

        public virtual Page MyPageInfo { get; set; }

        public Img(byte[] data)
        {
            Data = data;
        }
        public Img()
        {
    
        }

    }
}
