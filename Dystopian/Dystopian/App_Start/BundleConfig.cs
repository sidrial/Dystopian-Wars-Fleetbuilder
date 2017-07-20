using System.Web;
using System.Web.Optimization;

namespace Dystopian
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            bundles.Add(new ScriptBundle("~/bundles/boilerplate").IncludeDirectory("~/Scripts/Boilerplate", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/plugins").IncludeDirectory("~/Scripts/Plugins", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include("~/Scripts/inspinia.js"));

            bundles.Add(new ScriptBundle("~/bundles/fleetbuilder").Include("~/Scripts/fleetbuilder.js"));

            bundles.Add(new StyleBundle("~/Content/boilerplate").IncludeDirectory("~/Content", "*.css", true));

            bundles.Add(new StyleBundle("~/Content/site").Include("~/Content/Site.css").Include("~/Content/Inspinia/style.css"));    
          
        }
    }
}
