using AvaloniaBlazorWebView.Configurations;
using Microsoft.Extensions.Options;

namespace AvaloniaBlazorWebView.Core;

internal class BlazorWebViewApplication : IBlazorWebViewApplication
{
    public BlazorWebViewApplication(IServiceProvider services)
    {
        ServiceProvider = services;
    }

    public IServiceProvider ServiceProvider { get; }

    public WebViewCreationProperties WebViewProperties => ServiceProvider.GetService<WebViewCreationProperties>()!;
    public BlazorWebViewSetting BlazorWebViewProperties => ServiceProvider.GetService<IOptions<BlazorWebViewSetting>>()!.Value!;
    
    public IViewHandlerProvider ViewHandlerProvider => ServiceProvider.GetService<IViewHandlerProvider>()!;
    public IPlatformBlazorWebViewProvider PlatformBlazorWebViewProvider => ServiceProvider.GetService<IPlatformBlazorWebViewProvider>()!;

    public AvaloniaDispatcher AvaloniaDispatcher => ServiceProvider.GetService<AvaloniaDispatcher>()!;
    public JSComponentConfigurationStore JSComponentConfigurationStore => ServiceProvider.GetService<JSComponentConfigurationStore>()!;
    
}
