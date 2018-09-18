using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultitenantServer2016.Controllers
{
    public class DashboardController : MultiTenantMvcController
    {

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

    }
}