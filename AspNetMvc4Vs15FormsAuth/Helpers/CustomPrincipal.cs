using System.Security.Principal;

namespace AspNetMvc4Vs15FormsAuth.Helpers
{
    public class CustomPrincipal :
        IPrincipal
    {
        public CustomPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public IIdentity Identity { get; }
        public string Description => Identity.Name;
    }
}