using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.Windows.Extensions.Services;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWindowsWebView2Services(this IServiceCollection services)
    {
        return services.AddSingleton<IViewHandlerProvider, ViewHandlerProvider>()
            .AddSingleton<IPlatformBlazorWebViewProvider, BlazorWebViewHandlerProvider>();
    }
}
