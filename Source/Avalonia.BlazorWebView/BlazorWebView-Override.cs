namespace AvaloniaBlazorWebView;

partial class BlazorWebView  
{
    protected override async void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);

        Console.WriteLine(">>> Attached to a Visual Tree.");
        await CreateWebViewManager();

        if (AvaloniaWebViewManager is null)
            return;

        AvaloniaWebViewManager.Navigate(StartAddress);
    }

    protected override void OnDetachedFromVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnDetachedFromVisualTree(e);
        Child = null;
        _platformWebView?.Dispose();
        _platformWebView = null;
    }

}
