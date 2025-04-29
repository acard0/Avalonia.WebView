namespace WebViewCore;
public interface IWebViewControl
{
    bool CanGoForward { get; }
    bool CanGoBack { get; }

    double ZoomFactor { get; set; }

    bool Navigate(Uri? uri);
    bool NavigateToString(string htmlContent);

    bool GoBack();
    bool GoForward();
    bool Stop();
    bool Reload();

    Task<string?> ExecuteScriptAsync(string javaScript);

    bool PostWebMessageAsJson(string webMessageAsJson, Uri? baseUri);
    bool PostWebMessageAsString(string webMessageAsString, Uri? baseUri);

    bool OpenDevToolsWindow();
}
