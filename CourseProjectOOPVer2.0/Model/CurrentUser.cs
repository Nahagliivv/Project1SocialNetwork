using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectOOPVer2._0.Model
{
    public class CurrentUser
    {
        public static long CurrentUserID { get; set; } ///////////не трогать руками
        public static User Current { get; set; }
        public static ViewModel.MasterViewModel MasterRef {get;set;}
    }
}
