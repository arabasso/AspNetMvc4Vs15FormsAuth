using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvc4Vs15FormsAuth.Helpers
{
    public class CustomValidatableObjectAdapter :
        ValidatableObjectAdapter
    {
        private readonly IServiceProvider _serviceProvider;

        public CustomValidatableObjectAdapter(IServiceProvider serviceProvider, ModelMetadata metadata, ControllerContext context) : base(metadata, context)
        {
            _serviceProvider = serviceProvider;
        }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            // NOTE: Container is never used here, because IValidatableObject doesn't give you
            // any way to get access to your container.

            object model = Metadata.Model;
            if (model == null)
            {
                return Enumerable.Empty<ModelValidationResult>();
            }

            IValidatableObject validatable = model as IValidatableObject;
            if (validatable == null)
            {
                return base.Validate(container);
            }

            ValidationContext validationContext = new ValidationContext(validatable, _serviceProvider, null);
            return ConvertResults(validatable.Validate(validationContext));
        }

        private IEnumerable<ModelValidationResult> ConvertResults(IEnumerable<ValidationResult> results)
        {
            foreach (ValidationResult result in results)
            {
                if (result != ValidationResult.Success)
                {
                    if (result.MemberNames == null || !result.MemberNames.Any())
                    {
                        yield return new ModelValidationResult { Message = result.ErrorMessage };
                    }
                    else
                    {
                        foreach (string memberName in result.MemberNames)
                        {
                            yield return new ModelValidationResult { Message = result.ErrorMessage, MemberName = memberName };
                        }
                    }
                }
            }
        }
    }
}