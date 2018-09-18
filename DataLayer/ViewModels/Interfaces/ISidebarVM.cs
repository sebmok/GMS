using System;
using System.Linq;

namespace DataLayer.ViewModels
{
    public interface ISidebarVM
    {
        string glClass { get; set; }
        string glName { get; set; }
        int? Glyph { get; set; }
        Guid mmrid { get; set; }
        Guid mmurid { get; set; }
        int muncui { get; set; }
        int munide { get; set; }
        string NavAction { get; set; }
        string NavClass { get; set; }
        string NavController { get; set; }
        string NavName { get; set; }
        int? Parent { get; set; }
        IQueryable<DashboardViewModels.SidebarVM> SidebarList { get; set; }
    }
}