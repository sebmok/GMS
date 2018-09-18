using MultitenantServer2016.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultitenantServer2016.CORE
{
    public class MultiTenantControllerAllowAttribute :
      ActionFilterAttribute
    {
        private readonly List<string> _tenantList;


        // VALIDATING TENANTS TO ALLOW
        public MultiTenantControllerAllowAttribute(string confArray)
        {
            _tenantList = confArray.ToLower().Split(',').ToList();
        }


        // IF TENANT IS ALLOWED 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = (MultiTenantMvcController)
                filterContext.Controller;

            // OR REDIRECT TO 404
            if (controller.Tenant == null || !_tenantList.Contains(controller.Tenant.Name.ToLower()))
            {
                throw new HttpException(404, "Tenant Not Found");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}