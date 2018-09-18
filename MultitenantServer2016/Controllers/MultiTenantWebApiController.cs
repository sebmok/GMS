using ResourceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MultitenantServer2016.Controllers
{
    public class MultiTenantWebApiController : ApiController
    {
        public Tenant Tenant
        {
            get
            {
                object multiTenant;
                if (!HttpContext.Current.GetOwinContext().Environment.TryGetValue("MultiTenant",
                    out multiTenant))
                {
                    throw new ApplicationException();

                }
                return (Tenant)multiTenant;
            }
        }
    }
}
