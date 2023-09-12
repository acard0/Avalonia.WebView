using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.Android;

public static class AppBuilderExtensions
{
    public static IServiceCollection AddAndroidWebViewServices(this IServiceCollection services)
    {
        return services.AddSingleton<IViewHandlerProvider, ViewHandlerProvider>()
            .AddSingleton<IPlatformBlazorWebViewProvider, BlazorWebViewHandlerProvider>();
    }
}
