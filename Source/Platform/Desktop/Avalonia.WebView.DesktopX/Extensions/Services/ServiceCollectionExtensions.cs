using Avalonia.WebView.Windows.Extensions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.DesktopX.Extensions.ServiceCollectionExtensions;
public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddDesktopWebViewServices(this IServiceCollection services, bool isWslDevelop)
    {
#if __WINDOWS__
        services.AddWindowsWebView2Services();
#elif __OSX__
        services.AddMacCatalystWebViewServices();
        //services.UseOSXWebView();
#elif __LINUX__
        services.AddLinuxWebViewServies(isWslDevelop);
#endif
        return services;
    }
}
