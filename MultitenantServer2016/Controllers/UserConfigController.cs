using DataLayer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using static DataLayer.ViewModels.DashboardViewModels;

namespace MultitenantServer2016.Controllers
{
    [RoutePrefix("rest/dashboard")]
    [Authorize]
    public class UserConfigController : MultiTenantWebApiController
    {
        private DashboardRepository _repo = new DashboardRepository();

       
        [Route("getMembers")]
        public async Task<IEnumerable<MembersVM>> GetMembers(string ulpid)
        {           
            return await _repo.GetMembers(ulpid);
        }

       
        [Route("getSidebars")]
        public async Task<IEnumerable<SidebarVM>> GetSidebars(string ulpid)
        {
            return await _repo.GetSidebars(ulpid);
        }

       
        [Route("getActionBars")]
        public async Task<IEnumerable<ActionBarVM>> GetActionBars(string ulpid)
        {
            return await _repo.GetActionBars(ulpid);
        }

    }
}
