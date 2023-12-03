using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Avalonia.WebView.Windows.Core;

public partial class WebView2Core : IPlatformWebView<WebView2Core>
{
    private readonly IServiceProvider _services;

    private readonly IVirtualBlazorWebViewProvider? _provider;
    private readonly IVirtualWebViewControlCallBack _callBack;
    private readonly ViewHandler _handler;
    private readonly TaskCompletionSource<IntPtr> _hwndTaskSource;

    private bool _browserHitTransparent;
    private bool _browserCrashed;
    private bool _isInitialized = false;
    private bool _isDisposed = false;
    private bool _isBlazorWebView;

    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger _logger;

    public WebView2Core(IServiceProvider services, ViewHandler handler, IVirtualWebViewControlCallBack callback, IVirtualBlazorWebViewProvider? provider, WebViewCreationProperties webViewCreationProperties)
    {
        _loggerFactory = (_services = services).GetRequiredService<ILoggerFactory>();
        _logger = _loggerFactory.CreateLogger<WebView2Core>();

        _hwndTaskSource = new();
        _callBack = callback;
        _handler = handler;
        CreationProperties = webViewCreationProperties;
        _provider = provider;

        if (handler.RefHandler.Handle != IntPtr.Zero)
        {
            NativeHandler = handler.RefHandler.Handle;
            _hwndTaskSource.SetResult(handler.RefHandler.Handle);
        }

        SetEnvirmentDefaultBackground(webViewCreationProperties.DefaultWebViewBackgroundColor);
        RegisterEvents();
    }

    ~WebView2Core()
    {
        Dispose(disposing: false);
    }

    public bool IsInitialized
    {
        get => Volatile.Read(ref _isInitialized);
        private set => Volatile.Write(ref _isInitialized, value);
    }

    public bool IsDisposed
    {
        get => Volatile.Read(ref _isDisposed);
        private set => Volatile.Write(ref _isDisposed, value);
    }

    public bool IsBlazorWebView => _isBlazorWebView;
 
    public WebViewCreationProperties CreationProperties { get; private set; }
    public CoreWebView2Environment? CoreWebView2Environment { get; set; }
    public CoreWebView2Controller? CoreWebView2Controller { get; set; }
    public CoreWebView2ControllerOptions? ControllerOptions { get; set; }

    [Browsable(false)]
    public CoreWebView2? CoreWebView2
    {
        get
        {
            VerifyNotDisposed();
            VerifyBrowserNotCrashed();
            return CoreWebView2Controller?.CoreWebView2;
        }
    }
}