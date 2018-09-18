using System;
using System.Collections.Generic;

namespace DataLayer.ViewModels
{
    public interface IUserDetailsVM
    {
        string lName { get; set; }
        bool mDefault { get; set; }
        Guid mmid { get; set; }
        string mmsn { get; set; }
        int? SortOrder { get; set; }
        List<DashboardViewModels.UserDetailsVM> userDetailsList { get; set; }
    }
}