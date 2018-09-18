﻿using MultitenantServer2016.Controllers;
using System.Diagnostics;
using System.Web.Mvc;

namespace MultitenantServer2016
{
        public class MultiTenantViewEngine : RazorViewEngine
        {
            public MultiTenantViewEngine()
            {
                AreaMasterLocationFormats = new[]
                {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };

                AreaPartialViewLocationFormats = new[]
                {   "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.vbhtml"
            };

                ViewLocationFormats = new[]
                {
                "~/Views/%1/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/%1/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

                MasterLocationFormats = new[]
                {
               "~/Views/%1/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/%1/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };


                AreaPartialViewLocationFormats = new[]
                {
               "~/Views/%1/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/%1/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
            }
            protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
            {
                var controller = controllerContext.Controller as MultiTenantMvcController;
                Debug.Assert(controller != null, "PassedController !=null");

                return base.CreatePartialView(controllerContext, partialPath.Replace("%1", controller.Tenant.Name));
            }

            protected override IView CreateView(ControllerContext controllerContext,
                string viewPath, string masterPath)
            {
                var controller = controllerContext.Controller as MultiTenantMvcController;
                Debug.Assert(controller != null, "PassedController != null");

                return base.CreateView(controllerContext,
                    viewPath.Replace("%1", controller.Tenant.Name),
                    masterPath.Replace("%1", controller.Tenant.Name));
            }

            protected override bool FileExists(ControllerContext controllerContext,
                string virtualPath)
            {
                var controller = controllerContext.Controller as MultiTenantMvcController;
                Debug.Assert(controller != null, "PassedController !=null");

                return base.FileExists(controllerContext, virtualPath.Replace("%1", controller.Tenant.Name));
            }
        }
    }
   