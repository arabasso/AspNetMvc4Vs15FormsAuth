using System;
using System.Web.Mvc;
using AspNetMvc4Vs15FormsAuth.DryIoc;
using AspNetMvc4Vs15FormsAuth.Helpers;
using AspNetMvc4Vs15FormsAuth.Services;
using DryIoc;

namespace AspNetMvc4Vs15FormsAuth
{
    public class DryIocConfig
    {
        public static void RegisterServices(IContainer container)
        {
            DataAnnotationsModelValidatorProvider
                .RegisterDefaultAdapterFactory(
                    (metadata, context, attribute) =>
                        new CustomDataAnnotationsModelValidator(
                            new DryIocServiceProvider(container),
                            metadata, context, attribute));

            DataAnnotationsModelValidatorProvider
                .RegisterDefaultValidatableObjectAdapterFactory(
                    (metadata, context) =>
                        new CustomValidatableObjectAdapter(
                            new DryIocServiceProvider(container),
                            metadata, context));

            container.Register<IServiceProvider, DryIocServiceProvider>();
            container.Register<LoginService>();
        }
    }
}