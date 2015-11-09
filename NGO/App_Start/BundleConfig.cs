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
                .Include("~/scripts/js/jquery-2.1.1.min.js")
                .Include("~/scripts/js/jquery.migrate.js")
                .Include("~/scripts/js/modernizrr.js")
                .Include("~/scripts/js/bootstrap.min.js")
                .Include("~/scripts/js/jquery.fitvids.js")
                .Include("~/scripts/js/owl.carousel.min.js")
                .Include("~/scripts/js/nivo-lightbox.min.js")
                .Include("~/scripts/js/jquery.isotope.min.js")
                .Include("~/scripts/js/jquery.appear.js")
                .Include("~/scripts/js/count-to.js")
                .Include("~/scripts/js/jquery.textillate.js")
                .Include("~/scripts/js/jquery.lettering.js")
                .Include("~/scripts/js/jquery.easypiechart.min.js")
                .Include("~/scripts/js/jquery.nicescroll.min.js")
                .Include("~/scripts/js/jquery.parallax.js")
                .Include("~/scripts/js/jquery.themepunch.plugins.min.js")
                .Include("~/scripts/js/jquery.themepunch.revolution.min.js")
                .Include("~/scripts/js/script.js")

                );


            //including all the css used in our app
            bundles.Add(
                new StyleBundle("~/content/css")
                 .Include("~/content/asset/css/bootstrap.min.css")
                    .Include("~/content/css/font-awesome.min.css")
                    .Include("~/content/css/settings.css")
                    .Include("~/content/css/responsive.css")
                    .Include("~/content/css/animate.css")
                    .Include("~/content/css/colors/blue.css")
                    .Include("~/content/css/style.css")
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