using System.Web;
using System.Web.Optimization;
using Tras.Web.App_Start;

namespace Tras.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/themes/base/all.css",
                      "~/Content/animate.css",
                      "~/Content/style.css",
                      "~/Content/site.css",
                      "~/Content/site-content.css"
                ));

            bundles.Add(new StyleBundle("~/Content/fancybox").Include(
                "~/Content/jquery.fancybox.css"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery-ui-1.10.4.min.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-select.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/fancybox").Include(
                      "~/Scripts/jquery.mousewheel-3.0.6.pack.js",
                      "~/Scripts/jquery.fancybox.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/twbsPagination").Include(
                      "~/Scripts/jquery.twbsPagination.js",
                      "~/Scripts/jquery.fancybox.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/file-upload").Include(
                      "~/Scripts/file-upload/jquery.fileupload.js",
                      "~/Scripts/file-upload/jquery.fileupload-ui.js",
                      "~/Scripts/file-upload/jquery.iframe-transport.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/tras").Include(
                      "~/Scripts/tras.global.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/lookup")
                .Include("~/Scripts/app/tras.lookup.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/person")
                .Include("~/Scripts/app/tras.person.js")
                );


            bundles.Add(new ScriptBundle("~/bundles/dispersion")
                .Include("~/Scripts/app/tras.dispersion.js")
                );
            
            bundles.Add(new ScriptBundle("~/bundles/mess-dispersion")
                .Include("~/Scripts/app/tras.mess-dispersion.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/battalionperson")
                .Include("~/Scripts/app/tras.battalionperson.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/packageitem")
              .Include("~/Scripts/app/tras.package.js")
              );
            InispiniaBundle.Register(bundles);

            BundleTable.EnableOptimizations = false;
        }
    }
}
