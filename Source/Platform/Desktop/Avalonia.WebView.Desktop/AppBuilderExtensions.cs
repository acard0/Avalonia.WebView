using Avalonia.WebView.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using Avalonia.WebView.MacCatalyst;
using Avalonia.WebView.Linux;

namespace Avalonia.WebView.Desktop;

public static class AppBuilderExtensions
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
