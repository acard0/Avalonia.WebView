using WebViewCore;
using WebViewCore.Configurations;

namespace AvaloniaWebView.Shared;

public interface IViewHandlerProvider
{
    IViewHandler CreatePlatformWebViewHandler(IServiceProvider services, IVirtualWebView virtualView, IVirtualWebViewControlCallBack virtualViewCallBack, IVirtualBlazorWebViewProvider? virtualBlazorWebViewCallBack ,Action<WebViewCreationProperties>? configDelegate = default);
}
