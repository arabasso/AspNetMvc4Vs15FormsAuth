using System;

namespace AspNetMvc4Vs15FormsAuth.Services
{
    public static class Extensions
    {
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}