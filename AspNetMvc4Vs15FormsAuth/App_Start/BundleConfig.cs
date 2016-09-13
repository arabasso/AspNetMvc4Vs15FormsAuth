using System.Web.Optimization;

namespace AspNetMvc4Vs15FormsAuth
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/styles")
                .Include("~/Content/Style.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/Scripts/Script.js"));
        }
    }
}