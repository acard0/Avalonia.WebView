
namespace Avalonia.WebView.iOS;

internal class ViewHandlerProvider : IViewHandlerProvider
{
    public IViewHandler CreatePlatformWebViewHandler(IServiceProvider services, IVirtualWebView virtualView, IVirtualWebViewControlCallBack virtualViewCallBack, IVirtualBlazorWebViewProvider? virtualBlazorWebViewCallBack, Action<WebViewCreationProperties>? configDelegate = null)
    {
        var creatonProperty = new WebViewCreationProperties();
        configDelegate?.Invoke(creatonProperty);

        return new WebViewHandler(services, virtualView, virtualViewCallBack, virtualBlazorWebViewCallBack, creatonProperty);
    }
}
