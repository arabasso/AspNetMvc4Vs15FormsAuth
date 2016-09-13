using System.Web.Mvc;

namespace AspNetMvc4Vs15FormsAuth.Helpers
{
    public abstract class CustomWebViewPage : WebViewPage
    {
        public new virtual CustomPrincipal User => base.User as CustomPrincipal;
    }

    public abstract class CustomWebViewPage<T> : WebViewPage<T>
    {
        public new virtual CustomPrincipal User => base.User as CustomPrincipal;
    }
}