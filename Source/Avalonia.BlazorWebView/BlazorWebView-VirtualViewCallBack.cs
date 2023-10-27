namespace AvaloniaBlazorWebView;

partial class BlazorWebView  
{
    public virtual void PlatformWebViewCreated(object? sender, WebViewCreatedEventArgs arg)
    {
        if (arg.IsSucceed)
        {
            Console.WriteLine(">>> Native Platform Web View is created.");
        }
        else
        {
            Console.WriteLine($">>> !!! Failed to create Native Platform Web View: {arg.Message}");
        }

        WebViewCreated?.Invoke(sender, arg);
    }

    public virtual bool PlatformWebViewCreating(object? sender, WebViewCreatingEventArgs arg)
    {
        Console.WriteLine(">>> Native Platform Web View is being created.");
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
