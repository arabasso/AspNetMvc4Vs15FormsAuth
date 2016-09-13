using AspNetMvc4Vs15FormsAuth.Models;

namespace AspNetMvc4Vs15FormsAuth.Services
{
    public class LoginService
    {
        public bool Exists(LoginModel model)
        {
            return model.Username == "arabasso"
                   && model.Password == "123";
        }
    }
}