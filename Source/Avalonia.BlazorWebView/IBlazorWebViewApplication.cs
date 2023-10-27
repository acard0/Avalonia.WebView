using AvaloniaBlazorWebView.Configurations;

namespace AvaloniaBlazorWebView;

public interface IBlazorWebViewApplication
{
    public IServiceProvider ServiceProvider { get; }

    public WebViewCreationProperties WebViewProperties { get; }
    public BlazorWebViewSetting BlazorWebViewProperties { get; }

    public IViewHandlerProvider ViewHandlerProvider { get; }
    public IPlatformBlazorWebViewProvider PlatformBlazorWebViewProvider { get; }
}
