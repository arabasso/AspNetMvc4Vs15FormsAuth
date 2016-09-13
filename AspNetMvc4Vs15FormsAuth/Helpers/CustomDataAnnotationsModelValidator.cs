using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AspNetMvc4Vs15FormsAuth.Helpers
{
    public class CustomDataAnnotationsModelValidator :
        DataAnnotationsModelValidator
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomDataAnnotationsModelValidator(IServiceProvider serviceProvider, ModelMetadata metadata, ControllerContext context, ValidationAttribute attribute) : base(metadata, context, attribute)
        {
            _serviceProvider = serviceProvider;
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            // Per the WCF RIA Services team, instance can never be null (if you have
            // no parent, you pass yourself for the "instance" parameter).
            ValidationContext context = new ValidationContext(container ?? Metadata.Model, _serviceProvider, null);
            context.DisplayName = Metadata.GetDisplayName();

            ValidationResult result = Attribute.GetValidationResult(Metadata.Model, context);
            if (result != ValidationResult.Success)
            {
                yield return new ModelValidationResult
                {
                    Message = result.ErrorMessage
                };
            }
        }
    }
}