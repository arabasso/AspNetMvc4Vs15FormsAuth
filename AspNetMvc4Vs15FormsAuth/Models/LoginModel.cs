using System.ComponentModel.DataAnnotations;
using AspNetMvc4Vs15FormsAuth.Models.Validators;

namespace AspNetMvc4Vs15FormsAuth.Models
{
    [LoginValidation]
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}