using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModels
{
    public class DashboardViewModels
    {

        // =====================
        // // Sp_getUserSidebarByLoggedUserId
        // =======================
        public class SidebarVM : ISidebarVM
        {
          
            public Guid mmrid { get; set; }
            public Guid mmurid { get; set; }
            public int muncui { get; set; }
            public int munide { get; set; } // NavItem Id
            public int? Parent { get; set; }
            public int? DisplayOrder { get; set; }
            public string NavName { get; set; }
            public string NavController { get; set; }
            public string NavAction { get; set; }
            public string NavClass { get; set; }
            public int? Glyph { get; set; }
            public string glName { get; set; }
            public string glClass { get; set; }



            public IQueryable<SidebarVM> SidebarList { get; set; }
        }


        // =====================
        // // Sp_GetActionBarByUserId
        // =======================
        public class ActionBarVM : IActionBarVM
        {
            public Guid mmurid { get; set; }
            public Guid muurid { get; set; }
            public int gluid { get; set; }
            public int? DisplayOrder { get; set; }
            public string gName { get; set; }
            public string gToolTip { get; set; }
            public string gClass { get; set; }
            public List<ActionBarVM> actionBarList { get; set; }
        }


        // =====================
        // // Sp_GetUserInformationByUserId
        // =======================
        public class UserDetailsVM : IUserDetailsVM// Model for Procedure: 
        {
            public string lName { get; set; }
            public string mmsn { get; set; }
            public Guid mmid { get; set; }
            public bool mDefault { get; set; }
            public int? SortOrder { get; set; }
            public List<UserDetailsVM> userDetailsList { get; set; }
        }


        // =====================
        // // Sp_GetUserMembersByUserId
        // =======================
        public class MembersVM : IMembersVM
        {
            public string lName { get; set; }
            public string mmsn { get; set; }
            public Guid mmid { get; set; } // MemberId - RefKey
            public int mDefault { get; set; }            
            public string SortOrder { get; set; } // SortOrder for Members (not default)

            public List<MembersVM> MemberList { get; set; }

        }
    }
}
