using System;
using DryIoc;

namespace AspNetMvc4Vs15FormsAuth.DryIoc
{
    public class DryIocServiceProvider : IServiceProvider
    {
        private readonly IResolver _resolver;

        public DryIocServiceProvider(IResolver resolver)
        {
            _resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            return _resolver.Resolve(serviceType);
        }
    }
}