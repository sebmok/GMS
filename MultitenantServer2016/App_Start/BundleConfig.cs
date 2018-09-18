using System.Web;
using System.Web.Optimization;

namespace MultitenantServer2016
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            #region SystemOld

            bundles.Add(new ScriptBundle("~/bundles/system/scripts").Include(
                            "~/Scripts/angular.js",
                            "~/Scripts/angular-animate.js",
                            "~/Scripts/angular-route.js",
                            "~/Scripts/angular-gridster.min.js"                        

                             ));

           bundles.Add(new ScriptBundle("~/bundles/SYSTEM/framework/scripts").Include(                 
                
             "~/Content/SYSTEM/ext-modules/psDashboard/psDashboardModule.js",
             "~/Content/SYSTEM/ext-modules/psFramework/psFrameworkModule.js",
             "~/Content/SYSTEM/ext-modules/psMenu/psMenuModule.js",

             "~/Content/SYSTEM/ext-modules/psDashboard/psDashboardDirective.js",             
             "~/Content/SYSTEM/ext-modules/psDashboard/psWidgetBodyDirective.js",
             "~/Content/SYSTEM/ext-modules/psFramework/psFrameworkDirective.js",
             "~/Content/SYSTEM/ext-modules/psMenu/psMenuDirective.js",
             "~/Content/SYSTEM/ext-modules/psMenu/psMenuGroupDirective.js",
             "~/Content/SYSTEM/ext-modules/psMenu/psMenuItemDirective.js",

             "~/Content/SYSTEM/ext-modules/psFramework/psFrameworkController.js",            
             "~/Content/SYSTEM/ext-modules/psMenu/psMenuController.js",               
                       
             
             "~/Content/SYSTEM/app/app.js",
             "~/Content/SYSTEM/app/login/loginCtrl.js",
             "~/Content/SYSTEM/directives/dashboardDirective.js",
             "~/Content/SYSTEM/widgets/Customers/widgetCustomersDirective.js",
             "~/Content/SYSTEM/common/services/dataService.js",
             "~/Content/SYSTEM/common/common.core.js",
             "~/Content/SYSTEM/common/common.ui.js",
             "~/Content/SYSTEM/common/configuration.js"
             
             ));                         

            bundles.Add(new StyleBundle("~/bundles/system/core/styles").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/angular-gridster.min.css",
                    "~/Content/font-awesome.css"

                   ));           

            bundles.Add(new StyleBundle("~/bundles/system/app/styles").Include(
                "~/Content/SYSTEM/app/app.css",
                "~/Content/SYSTEM/ext-modules/psMenu/psMenu.css",
                "~/Content/SYSTEM/ext-modules/psDashboard/psDashboard.css",
                "~/Content/SYSTEM/ext-modules/psFramework/psFramework.css",
                "~/Content/SYSTEM/widgets/Customers/widgetCustomers.css"
                  ));

            #endregion

            bundles.Add(new ScriptBundle("~/bundles/systemv2/core/scripts").Include(
                  "~/Scripts/jquery-{version}.js",
               "~/Scripts/angular.js",
              "~/Scripts/angular-route.js",
              "~/Scripts/bootstrap.js",
               "~/Scripts/angular-ui/ui-bootstrap.js",
              "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/systemv2/scripts").Include(
                "~/Content/SYSTEM/app/app.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/systemv2/app/styles").Include(
                "~/Content/SYSTEM/css/site.css"
               
                ));


            bundles.Add(new StyleBundle("~/bundles/systemv2/core/styles").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/angular-gridster.min.css",
                  "~/Content/font-awesome.css"
                  ));

            bundles.Add(new StyleBundle("~/Content/systemv2/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
