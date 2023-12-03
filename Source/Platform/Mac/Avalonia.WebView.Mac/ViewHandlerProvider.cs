namespace Avalonia.WebView.Mac;

internal class ViewHandlerProvider : IViewHandlerProvider
{
    public ViewHandlerProvider()
    {
        NSApplication.Init();
    }

    IViewHandler IViewHandlerProvider.CreatePlatformWebViewHandler(IServiceProvider services, IVirtualWebView virtualView, IVirtualWebViewControlCallBack virtualViewCallBack, IVirtualBlazorWebViewProvider? provider, Action<WebViewCreationProperties>? configDelegate)
    {
        var creatonProperty = new WebViewCreationProperties();
        configDelegate?.Invoke(creatonProperty);

        return new WebViewHandler(services, virtualView, virtualViewCallBack, provider, creatonProperty);
    }
}
