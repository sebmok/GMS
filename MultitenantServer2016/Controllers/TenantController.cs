using MultitenantServer2016.CORE;
using System.Linq;
using System.Web.Mvc;

namespace MultitenantServer2016.Controllers
{
    public class TenantController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new MultiTenantContext())
            {
                var tenants = context.Tenant.ToList();

                return View("Index", tenants);

            }
        }
    }
}
