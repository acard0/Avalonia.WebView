using AvaloniaBlazorWebView;
using AvaloniaBlazorWebView.Shared.Configurations;

namespace Avalonia.WebView.Desktop;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAvaloniaBlazorWebViewServices(
        this IServiceCollection services, WebViewCreationProperties webViewOptions,
        Action<BlazorWebViewSetting>? blazorConfig = default
    )
    {
        blazorConfig ??= c => { };


        services.AddOptions<BlazorWebViewSetting>().Configure(blazorConfig);
        services.AddBlazorWebView()
            .AddSingleton<JSComponentConfigurationStore>()
            .AddSingleton<AvaloniaDispatcher>(provider => new AvaloniaDispatcher(AvaloniaUIDispatcher.UIThread))
            .AddSingleton<IJSComponentConfiguration>(provider => new JsComponentConfigration(provider.GetRequiredService<JSComponentConfigurationStore>()))
            .AddSingleton(provider => webViewOptions)
            .AddSingleton<IBlazorWebViewApplication>(provider => new BlazorWebViewApplication(provider));

        return services;
    }
}
