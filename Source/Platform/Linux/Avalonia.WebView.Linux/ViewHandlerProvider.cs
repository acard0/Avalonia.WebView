using Avalonia.Controls.ApplicationLifetimes;
using Linux.WebView.Core;

namespace Avalonia.WebView.Linux;

internal class ViewHandlerProvider : IViewHandlerProvider
{
    private readonly ILinuxApplication _linuxApplication;

    public ViewHandlerProvider(ILinuxApplication app)
    {
        _linuxApplication = app;

        var bRet = app.RunAsync(default, default).Result;
        if (!bRet) throw new ArgumentNullException(nameof(ILinuxApplication), "create gtk application failed!");

        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime deskTop)
            deskTop.ShutdownRequested += DeskTop_ShutdownRequested;
    }


    IViewHandler IViewHandlerProvider.CreatePlatformWebViewHandler(IServiceProvider services, IVirtualWebView virtualView, IVirtualWebViewControlCallBack virtualViewCallBack, IVirtualBlazorWebViewProvider? provider, Action<WebViewCreationProperties>? configDelegate)
    {
        var creatonProperty = new WebViewCreationProperties();
        configDelegate?.Invoke(creatonProperty);

        return new WebViewHandler(services, _linuxApplication, virtualView, virtualViewCallBack, provider, creatonProperty);
    }

    private void DeskTop_ShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        _linuxApplication.Dispose();
    }
}
