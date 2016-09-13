using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using AspNetMvc4Vs15FormsAuth.Helpers;
using DryIoc;
using DryIoc.Mvc;

namespace AspNetMvc4Vs15FormsAuth
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DryIocConfig.RegisterServices(new Container().WithMvc());
        }

        protected void Application_PostAuthenticateRequest()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null) return;

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            if (ticket == null) return;

            var identity = new FormsIdentity(ticket);

            HttpContext.Current.User = new CustomPrincipal(identity);
        }
    }
}