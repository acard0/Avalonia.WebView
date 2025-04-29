using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AvaloniaWebView;

public sealed partial class WebView : Control, IVirtualWebView<WebView>, IEmptyView, IWebViewEventHandler, IVirtualWebViewControlCallBack, IWebViewControl
{
    public IServiceProvider Services { get; }

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

    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger _logger;

    readonly WebViewCreationProperties _creationProperties;
    readonly BorderRenderHelper _borderRenderHelper = new();
    readonly IViewHandlerProvider _viewHandlerProvider;

    readonly Border _partInnerContainer;
    readonly ContentPresenter _partEmptyViewPresenter;

    double _zoomFactor;
    double _scale;
    Thickness? _layoutThickness;

    IPlatformWebView? _platformWebView;

    static WebView()
    {
        AffectsRender<WebView>(BackgroundProperty, BorderBrushProperty, BorderThicknessProperty, CornerRadiusProperty, BoxShadowProperty);
        AffectsMeasure<WebView>(ChildProperty, PaddingProperty, BorderThicknessProperty);
        LoadDependencyObjectsChanged();
        LoadHostDependencyObjectsChanged();
    }

    public WebView(IServiceProvider serviceProvider)
    {
        Services = serviceProvider;

        _loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        _logger = _loggerFactory.CreateLogger<WebView>();

        _logger.LogInformation("Creating WebView control");

        var properties = serviceProvider.GetService<WebViewCreationProperties>()!;
        _creationProperties = properties ?? new WebViewCreationProperties();

        _viewHandlerProvider = serviceProvider.GetService<IViewHandlerProvider>()!;
        ClipToBounds = false;

        _partEmptyViewPresenter = new()
        {
            [!ContentPresenter.ContentProperty] = this[!EmptyViewerProperty],
            [!ContentPresenter.ContentTemplateProperty] = this[!EmptyViewerTemplateProperty],
        };

        _partInnerContainer = new()
        {
            Child = _partEmptyViewPresenter,
            ClipToBounds = true,
            [!Border.CornerRadiusProperty] = this[!CornerRadiusProperty]
        };
        Child = _partInnerContainer;
    }
}
