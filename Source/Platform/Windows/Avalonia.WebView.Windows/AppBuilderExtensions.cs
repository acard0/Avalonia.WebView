using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.Windows;
public static class AppBuilderExtensions
{
    public static IServiceCollection AddWindowsWebView2Services(this IServiceCollection services)
    {
        return services.AddSingleton<IViewHandlerProvider, ViewHandlerProvider>()
            .AddSingleton<IPlatformBlazorWebViewProvider, BlazorWebViewHandlerProvider>();
    }
}
