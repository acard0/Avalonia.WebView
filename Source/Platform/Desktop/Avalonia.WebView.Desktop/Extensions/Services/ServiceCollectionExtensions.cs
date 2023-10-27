using Avalonia.WebView.Linux.Extensions.Services;
using Avalonia.WebView.MacCatalyst.Extensions.Services;
using Avalonia.WebView.Windows.Extensions.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace Avalonia.WebView.Desktop.Extensions.Services;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDesktopWebViewServices(this IServiceCollection services, bool isWslDevelop)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            services.AddWindowsWebView2Services();
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            services.AddMacCatalystWebViewServices();
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            services.AddLinuxWebViewServies(isWslDevelop);

        return services;
    }
}
