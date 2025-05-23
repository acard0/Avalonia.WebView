﻿namespace Avalonia.WebView.iOS;

public class WebViewHandler : ViewHandler<IVirtualWebView, IosWebViewCore>
{
    public WebViewHandler(IServiceProvider services,IVirtualWebView virtualWebView, IVirtualWebViewControlCallBack callback, IVirtualBlazorWebViewProvider? provider, WebViewCreationProperties webViewCreationProperties) 
        : base(services)
    {
        var webView = new IosWebViewCore(this, callback, provider, webViewCreationProperties);
        _webViewCore = webView;
        PlatformWebView = webView;
        VirtualViewContext = virtualWebView;
        PlatformViewContext = webView;
    }
    readonly IosWebViewCore _webViewCore;

    protected override HandleRef CreatePlatformHandler(IPlatformHandle parent, Func<IPlatformHandle> createFromSystem)
    {
        //var handler = createFromSystem.Invoke();
        return new HandleRef(this, _webViewCore.NativeHandler);
    }

    protected override void Disposing()
    {
        PlatformWebView.Dispose();
        PlatformWebView = default!;
        VirtualViewContext = default!;
    }
}