using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.MacCatalyst;
public static class AppBuilderExtensions
{
    public static IServiceCollection AddMacCatalystWebViewServices(this IServiceCollection services)
    {
        return services.AddSingleton<IViewHandlerProvider, ViewHandlerProvider>()
            .AddSingleton<IPlatformBlazorWebViewProvider, BlazorWebViewHandlerProvider>();
    }
}
