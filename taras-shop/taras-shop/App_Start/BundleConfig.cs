﻿using System.Web;
using System.Web.Optimization;
using System.Web.Optimization.React;

namespace taras_shop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/js/jquery-1.10.2.min.js",
                "~/Scripts/js/bootstrap.min.js",
                "~/Scripts/js/lightslider.min.js",
                "~/Scripts/js/jQueryForm.js",
                "~/Scripts/js/main.js",
                "~/Scripts/js/slick.min.js",
                "~/Scripts/js/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/js/Lodash.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                "~/Content/css/fontello.css",
                "~/Content/css/main.css",
                "~/Content/css/jquery-ui.css",
                "~/Content/css/bootstrap.css",
                "~/Content/css/slick.css",
                "~/Content/css/slick-theme.css",
                "~/Content/css/lightslider.min.css"
            ));
        }
    }
}
