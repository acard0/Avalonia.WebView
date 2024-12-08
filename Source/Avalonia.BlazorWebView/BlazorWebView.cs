using AvaloniaBlazorWebView.Configurations;

namespace AvaloniaBlazorWebView;

public partial class BlazorWebView : Control, IVirtualWebView<BlazorWebView>, IWebViewEventHandler, IVirtualWebViewControlCallBack, IPlatformWebView, IWebViewControl, IAsyncDisposable
{
    public WebViewCreationProperties CreationProperties { get; }
    public IViewHandlerProvider ViewHandlerProvider { get; }

    public string AppScheme { get; }
    public string AppHostAddress { get; }
    public Uri HostUri { get; }
    public string StartAddress { get; }
    public BlazorWebViewSetting BlazorWebViewProperties { get; }
    public IBlazorWebViewApplication BlazorApplication { get; }
    public IServiceProvider Services { get; }
    public AvaloniaDispatcher Dispatcher { get; }
    public JSComponentConfigurationStore JSComponents { get; }
    public IPlatformBlazorWebViewProvider PlatformBlazorWebViewProvider { get; }

    public AvaloniaWebViewManager? AvaloniaWebViewManager
    {
        get
        {
            return _avaloniaWebViewManager;
        }
    }

    public IPlatformWebView? PlatformWebView
    {
        get
        {
            return _platformWebView;
        }
    }

    public double ZoomFactor
    {
        get
        {
            if (PlatformWebView == null)
            {
                return _zoomFactor;
            }

            return PlatformWebView.ZoomFactor;
        }
        set
        {
            _zoomFactor = value;
            if (PlatformWebView != null)
            {
                PlatformWebView.ZoomFactor = value;
            }
        }
    }

    public object? PlatformViewContext
    {
        get
        {
            return PlatformWebView?.PlatformViewContext;
        }
    }

    public IntPtr NativeHandler
    {
        get
        {
            return (PlatformWebView?.NativeHandler).GetValueOrDefault();
        }
    }

    private double _zoomFactor = 1;

    readonly bool _isDisposed = false;
    private IPlatformWebView? _platformWebView;
    private AvaloniaWebViewManager? _avaloniaWebViewManager;

    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger _logger;

    static BlazorWebView()
    {
        LoadDependencyObjectsChanged();
        LoadHostDependencyObjectsChanged();
    }

    public BlazorWebView(IServiceProvider serviceProvider)
    {
        _loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        _logger = _loggerFactory.CreateLogger<BlazorWebView>();

        _logger.LogInformation("Creating BlazorWebView component");

        var app = serviceProvider.GetService<IBlazorWebViewApplication>() ?? throw new InvalidOperationException("Platform Web View Application service is not found. Make sure that platform services is added.");
        var setting = app.BlazorWebViewProperties;

        CreationProperties = app.WebViewProperties;
        ViewHandlerProvider = app.ViewHandlerProvider;
        PlatformBlazorWebViewProvider = app.PlatformBlazorWebViewProvider;
        BlazorApplication = app;
        Services = serviceProvider;
        BlazorWebViewProperties = setting;
        Dispatcher = Services.GetRequiredService<AvaloniaDispatcher>();
        JSComponents = Services.GetRequiredService<JSComponentConfigurationStore>();

        if (setting.ComponentType is not null && !string.IsNullOrWhiteSpace(setting.Selector))
        {
            RootComponents.Add(new BlazorRootComponent()
            {
                ComponentType = setting.ComponentType!,
                Selector = setting.Selector!
            });
        }

        AppScheme = PlatformBlazorWebViewProvider.Scheme;
        AppHostAddress = setting.AppAddress;
        HostUri = new Uri($"{AppScheme}://{AppHostAddress}/");
        StartAddress = setting.StartAddress;

        RootComponents.CollectionChanged += RootComponents_CollectionChanged;
    }

    public Task<bool> Initialize()
    {
        return Task.FromResult(true);
    }

    public void Dispose()
    {
        DisposeAsync().AsTask().Wait();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        _platformWebView?.Dispose();
        if (_avaloniaWebViewManager != null) 
            await _avaloniaWebViewManager.DisposeAsync();

        _platformWebView = null;
        _avaloniaWebViewManager = null;
        GC.SuppressFinalize(this);
    }
}
