using Microsoft.Extensions.Logging;

namespace Avalonia.WebView.Windows.Core;

partial class WebView2Core
{
    public IntPtr NativeHandler { get; private set; }

    public WebView2Core PlatformView => this;

    public object? PlatformViewContext => this;

    public bool CanGoForward => CoreWebView2?.CanGoForward ?? false;

    public bool CanGoBack => CoreWebView2?.CanGoBack ?? false;

    public async Task<bool> Initialize()
    {
        if (IsInitialized)
            return true;

        try
        {
            _callBack.PlatformWebViewCreating(this, new WebViewCreatingEventArgs());

            _logger.LogInformation("Creating WebView environment");
            var environment2 = await CreateEnvironmentAsync().ConfigureAwait(true);
            CoreWebView2Environment = environment2;

            _logger.LogInformation("Creating CoreWebView2 Controller options");
            var options = CreateCoreWebView2ControllerOptions(environment2);
            IntPtr intPtr = await _hwndTaskSource.Task;
            if (options is not null)
            {
                CoreWebView2Environment environment3 = environment2;
                CoreWebView2Controller coreWebView2Controller = await environment3.CreateCoreWebView2ControllerAsync(intPtr, options).ConfigureAwait(true);
                CoreWebView2Controller = coreWebView2Controller;
                ControllerOptions = options;
            }
            else
            {
                CoreWebView2Environment environment3 = environment2;
                CoreWebView2Controller coreWebView2Controller = await environment3.CreateCoreWebView2ControllerAsync(intPtr).ConfigureAwait(true);
                CoreWebView2Controller = coreWebView2Controller;
            }

            var coreWebView2 = CoreWebView2Controller.CoreWebView2;
            if (coreWebView2 is null)
                throw new ArgumentNullException(nameof(coreWebView2), "coreWebView2 is null!");

            try
            {
                _browserHitTransparent = CoreWebView2Controller.IsBrowserHitTransparent;
            }
            catch (NotImplementedException)
            {

            }

            _logger.LogInformation("Finalizing WebView creation");

            ResetWebViewSize(CoreWebView2Controller);

            if (CoreWebView2Controller.ParentWindow != intPtr)
                ReparentController(CoreWebView2Controller, intPtr);

            if (CoreWebView2Controller.ParentWindow != IntPtr.Zero)
                SyncControllerWithParentWindow(CoreWebView2Controller);

            ApplyDefaultWebViewSettings(coreWebView2);
            RegisterWebViewEvents(CoreWebView2Controller);

            if (_provider is not null)
                await PrepareBlazorWebViewStarting(_provider, coreWebView2).ConfigureAwait(true);
  
            IsInitialized = true;

            _callBack.PlatformWebViewCreated(this, new WebViewCreatedEventArgs { IsSucceed = true });
            return true;
        }
        catch (Exception ex2)
        {
            _callBack.PlatformWebViewCreated(this, new WebViewCreatedEventArgs { IsSucceed = false, Message = ex2.ToString() });
        }

        return false;
    }

    public bool GoBack()
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return false;

        if (!coreWebView2.CanGoBack)
            return false;

        coreWebView2.GoBack();
        return true;
    }

    public bool GoForward()
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return false;

        if (!coreWebView2.CanGoForward)
            return false;

        coreWebView2.GoForward();
        return true;
    }

    public bool Navigate(Uri? uri)
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return false;

        if (uri is null)
            return false;

        coreWebView2.Navigate(uri.AbsoluteUri);
        return true;
    }

    public bool NavigateToString(string htmlContent)
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return false;

        if (string.IsNullOrWhiteSpace(htmlContent))
            return false;

        coreWebView2.NavigateToString(htmlContent);
        return true;    
    }

    public bool OpenDevToolsWindow()
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return false;

        coreWebView2.OpenDevToolsWindow();
        return true;    
    }

    public async Task<string?> ExecuteScriptAsync(string javaScript)
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return default;

        if (string.IsNullOrEmpty(javaScript))
            return default;

        var result = await coreWebView2.ExecuteScriptAsync(javaScript);
        return result;
    }


    public bool PostWebMessageAsJson(string webMessageAsJson, Uri? baseUri)
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return false;

        if (string.IsNullOrWhiteSpace(webMessageAsJson))
            return false;

        coreWebView2.PostWebMessageAsJson(webMessageAsJson);
        return true;
    }

    public bool PostWebMessageAsString(string webMessageAsString, Uri? baseUri)
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return false;

        if (string.IsNullOrWhiteSpace(webMessageAsString))
            return false;

        coreWebView2.PostWebMessageAsString(webMessageAsString);
        return true;
    }

    public bool Reload()
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return false;

        coreWebView2.Reload();
        return true;
    }

    public bool Stop()
    {
        var coreWebView2 = CoreWebView2;
        if (coreWebView2 is null)
            return false;

        coreWebView2.Stop();
        return true;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!IsDisposed)
        {
            if (disposing)
            {
                try
                {
                    ClearBlazorWebViewCompleted(CoreWebView2!);
                    UnregisterWebViewEvents(CoreWebView2Controller!);
                    UnregisterEvents();
                }
                catch (Exception)
                {

                }

                ControllerOptions = null;
                CoreWebView2Controller = null;
                CoreWebView2Environment = null;
            }
 
            IsDisposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public ValueTask DisposeAsync()
    {
        ((IDisposable)this)?.Dispose();
        return new ValueTask();
    }
}
