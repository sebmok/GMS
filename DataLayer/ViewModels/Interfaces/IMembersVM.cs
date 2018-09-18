using System;
using System.Collections.Generic;

namespace DataLayer.ViewModels
{
    public interface IMembersVM
    {
        string lName { get; set; }
        int mDefault { get; set; }
        List<DashboardViewModels.MembersVM> MemberList { get; set; }
        Guid mmid { get; set; }
        string mmsn { get; set; }
        string SortOrder { get; set; }
    }
}