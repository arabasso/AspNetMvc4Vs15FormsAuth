using System;
using System.ComponentModel.DataAnnotations;
using AspNetMvc4Vs15FormsAuth.Services;

namespace AspNetMvc4Vs15FormsAuth.Models.Validators
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LoginValidationAttribute :
        ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (LoginModel)value;

            var service = validationContext.GetService<LoginService>();

            if (service.Exists(model))
            {
                return ValidationResult.Success;
            }

            var message = FormatErrorMessage(nameof(model.Username));

            return new ValidationResult(message);
        }
    }
}