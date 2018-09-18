using System;
using System.Collections.Generic;

namespace DataLayer.ViewModels
{
    public interface IActionBarVM1
    {
        List<DashboardViewModels.ActionBarVM> actionBarList { get; set; }
        string gClass { get; set; }
        int gluid { get; set; }
        string gName { get; set; }
        string gToolTip { get; set; }
        Guid mmurid { get; set; }
        Guid muurid { get; set; }
    }
}