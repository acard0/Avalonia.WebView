using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.MacCatalyst.Extensions.Services;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMacCatalystWebViewServices(this IServiceCollection services)
    {
        return services.AddSingleton<IViewHandlerProvider, ViewHandlerProvider>()
            .AddSingleton<IPlatformBlazorWebViewProvider, BlazorWebViewHandlerProvider>();
    }
}
