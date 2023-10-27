using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.DesktopX.Extensions.ServiceCollectionExtensions;
public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddDesktopWebViewServices(this IServiceCollection services, bool isWslDevelop)
    {
#if __WINDOWS__
        services.RegisterWindowsWebView2();
#elif __OSX__
        services.RegisterMacCatalystWebView();
        //services.UseOSXWebView();
#elif __LINUX__
        services.RegisterLinuxWebView(isWslDevelop);
#endif
        return services;
    }
}
