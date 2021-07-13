using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CourseProjectOOPVer2._0.Logic
{
    public class ClearJournal
    {
        public static Frame CurrentMainFrame { get; set; }
        public static void CleanJournal()
        {
            while (CurrentMainFrame.CanGoBack)
            {
                CurrentMainFrame.RemoveBackEntry();
            }
        }
    }
}
