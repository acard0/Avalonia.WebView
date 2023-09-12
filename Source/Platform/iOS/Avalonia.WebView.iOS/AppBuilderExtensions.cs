using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.iOS;

public static class AppBuilderExtensions
{
    public static IServiceCollection AddIOSWebViewServices(this IServiceCollection services)
    {
        return services.AddSingleton<IViewHandlerProvider, ViewHandlerProvider>()
            .AddSingleton<IPlatformBlazorWebViewProvider, BlazorWebViewHandlerProvider>();
    }
}
