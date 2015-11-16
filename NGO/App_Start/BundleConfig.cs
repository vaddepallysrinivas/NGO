using System.Web;
using System.Web.Optimization;
namespace NGO
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            //ignoring the bundle list


            //including all the libraries used in our app such as angular
            bundles.Add(
                  new ScriptBundle("~/scripts/lib")
                                    .Include("~/scripts/jquery.min.js")
                                    .Include("~/scripts/angular/angular.min.js")
                                    .Include("~/scripts/angular/angular-ui-router.min.js")
                                    .Include("~/scripts/angular/angular-touch.js")
                                    .Include("~/scripts/angular/angular-animate.js")
                                    .Include("~/scripts/angular/ui-grid.js")
                                    .Include("~/scripts/bootstrapJs/bootstrap.min.js")
                                    .Include("~/scripts/bootstrapJs/moment.js")
                                    .Include("~/scripts/bootstrapJs/bootstrap-datetimepicker.js")
                                    .Include("~/scripts/bootstrapJs/ui-bootstrap-tpls-0.11.2.js")

                );


            //styles
            bundles.Add(
                        new StyleBundle("~/content/css")
                        .Include("~/content/bootstrapCss/bootstrap.min.css")
                        .Include("~/content/bootstrapCss/bootstrap-datetimepicker.min.css")
                        .Include("~/content/bootstrapCss/bootstrap-theme.css")
                        .Include("~/content/angularCss/ui-grid.css")
                        .Include("~/content/bootstrapCss/app.css")
                );


            //including the javascript files in our app
            bundles.Add(
                new ScriptBundle("~/scripts/app")
                    .Include("~/app/app.js")
                    .IncludeDirectory("~/app", "*.js", true)

                );

        }
    }
}