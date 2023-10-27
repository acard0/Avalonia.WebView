namespace Toolkit.Shared.Extensions.Services;
public static class ServiceProviderExtensions
{
    public static T? GetService<T>(this IServiceProvider services)
    {
        return (T?)services.GetService(typeof(T));  
    }
}
