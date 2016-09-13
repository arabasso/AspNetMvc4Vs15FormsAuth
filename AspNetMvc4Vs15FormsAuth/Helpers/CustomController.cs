using System.Web.Mvc;

namespace AspNetMvc4Vs15FormsAuth.Helpers
{
    public class CustomController :
        Controller
    {
        protected new virtual CustomPrincipal User => base.User as CustomPrincipal;
    }
}