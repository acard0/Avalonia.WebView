namespace AvaloniaBlazorWebView;

partial class BlazorWebView  
{
    public virtual void PlatformWebViewCreated(object? sender, WebViewCreatedEventArgs arg)
    {
        if (arg.IsSucceed)
        {
            _logger.LogInformation("Native Platform Web View is created.");
        }
        else
        {
            _logger.LogInformation("!!! Failed to create Native Platform Web View. {m}", arg.Message);
        }

        WebViewCreated?.Invoke(sender, arg);
    }

    public virtual bool PlatformWebViewCreating(object? sender, WebViewCreatingEventArgs arg)
    {
        _logger.LogInformation("Native Platform Web View is being created.");
        WebViewCreating?.Invoke(sender, arg);
        return true;
    }

    public virtual void PlatformWebViewMessageReceived(object? sender, WebViewMessageReceivedEventArgs arg)
    {
        WebMessageReceived?.Invoke(sender, arg);
    }

    public virtual void PlatformWebViewNavigationCompleted(object? sender, WebViewUrlLoadedEventArg arg)
    {
        NavigationCompleted?.Invoke(sender, arg);
    }

    public virtual bool PlatformWebViewNavigationStarting(object? sender, WebViewUrlLoadingEventArg arg)
    {
        NavigationStarting?.Invoke(sender, arg);
        return true;
    }

    public virtual bool PlatformWebViewNewWindowRequest(object? sender, WebViewNewWindowEventArgs arg)
    {
        WebViewNewWindowRequested?.Invoke(sender, arg);
        return true;
    }
}
