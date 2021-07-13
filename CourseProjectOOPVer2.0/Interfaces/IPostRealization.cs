using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.Interfaces
{
    interface IPostRealization
    {
        ICommand Comments { get; }
        ICommand Like { get; }
        ICommand DelPost { get; }
    }
}
