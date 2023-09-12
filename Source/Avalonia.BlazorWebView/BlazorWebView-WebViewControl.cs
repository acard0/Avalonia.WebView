namespace AvaloniaBlazorWebView;

partial class BlazorWebView
{
    public bool IsCanGoForward => PlatformWebView?.IsCanGoForward ?? false;

    public bool IsCanGoBack => PlatformWebView?.IsCanGoBack ?? false;

    public bool Navigate(Uri? uri)
    {
        if (uri is null)
            return false;

        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return false;

        return PlatformWebView.Navigate(uri);
    }

    public bool NavigateToString(string htmlContent)
    {
        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return false;

        return PlatformWebView.NavigateToString(htmlContent);
    }

    public bool GoBack()
    {
        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return false;

        return PlatformWebView.GoBack();
    }

    public bool GoForward()
    {
        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return false;

        return PlatformWebView.GoForward();
    }

    public bool Stop()
    {
        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return false;

        return PlatformWebView.Stop();
    }

    public bool Reload()
    {
        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return false;

        return PlatformWebView.Reload();
    }

    public async Task<string?> ExecuteScriptAsync(string javaScript)
    {
        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return await Task.FromResult<string?>(default);

        return await PlatformWebView.ExecuteScriptAsync(javaScript);
    }

    public bool PostWebMessageAsJson(string webMessageAsJson, Uri? baseUri)
    {
        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return false;

        return PlatformWebView.PostWebMessageAsString(webMessageAsJson, baseUri);
    }

    public bool PostWebMessageAsString(string webMessageAsString, Uri? baseUri)
    {
        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return false;

        return PlatformWebView.PostWebMessageAsString(webMessageAsString, baseUri);
    }

    public bool OpenDevToolsWindow()
    {
        if (PlatformWebView is null || !PlatformWebView.IsInitialized)
            return false;

        return PlatformWebView.OpenDevToolsWindow();
    }

}
