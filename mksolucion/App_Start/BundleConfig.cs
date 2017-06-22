using System.Web;
using System.Web.Optimization;

namespace mksolucion
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/assets").Include(
                      "~/Content/assets/web/assets/jquery/jquery.min.js",
                      "~/Content/assets/tether/tether.min.js",
                      "~/Content/assets/bootstrap/js/bootstrap.min.js",
                      "~/Content/assets/smooth-scroll/smooth-scroll.js",
                      "~/Content/assets/dropdown/js/script.min.js",
                      "~/Content/assets/touch-swipe/jquery.touch-swipe.min.js",
                      "~/Content/assets/viewport-checker/jquery.viewportchecker.js",
                      "~/Content/assets/bootstrap-carousel-swipe/bootstrap-carousel-swipe.js",
                      "~/Content/assets/jquery-mb-ytplayer/jquery.mb.ytplayer.min.js",
                      "~/Content/assets/jarallax/jarallax.js",
                      "~/Content/assets/theme/js/script.js",
                      "~/Content/assets/mobirise-slider-video/script.js",
                      "~/Content/assets/formoid/formoid.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/assets").Include(
                      "~/Content/assets/bootstrap-material-design-font/css/material.css",
                      "~/Content/assets/et-line-font-plugin/style.css",
                      "~/Content/assets/tether/tether.min.css",
                      "~/Content/assets/bootstrap/css/bootstrap.min.css",
                      "~/Content/assets/dropdown/css/style.css",
                      "~/Content/assets/animate.css/animate.min.css",
                      "~/Content/assets/socicon/css/styles.css",
                      "~/Content/assets/theme/css/style.css",
                      "~/Content/assets/mobirise/css/mbr-additional.css"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
