﻿namespace Avalonia.WebView.Android.Core;

partial class AndroidWebViewCore
{
    AndroidWebViewCore IPlatformWebView<AndroidWebViewCore>.PlatformView => this;

    public nint NativeHandler { get; private set; }

    bool IPlatformWebView.IsInitialized => IsInitialized;

    object? IPlatformWebView.PlatformViewContext => this;

    bool IWebViewControl.IsCanGoForward => WebView.CanGoForward();

    bool IWebViewControl.IsCanGoBack => WebView.CanGoBack();

    Task<string?> IWebViewControl.ExecuteScriptAsync(string javaScript)
    {
        _webView.EvaluateJavascript(javaScript, new JavaScriptValueCallback(result =>
        {


        }));
        throw new NotImplementedException();
    }

    bool IWebViewControl.GoBack()
    {
        var webView = WebView;
        if (webView is null)
            return false;

        if (!webView.CanGoBack())
            return false;

        webView.GoBack();
        return true;
    }

    bool IWebViewControl.GoForward()
    {
        var webView = WebView;
        if (webView is null)
            return false;

        if (!webView.CanGoForward())
            return false;

        webView.GoForward();
        return true;
    }

    async Task<bool> IPlatformWebView.Initialize(IVirtualBlazorWebViewProvider? virtualProvider)
    {
        if (IsInitialized)
            return true;

        _provider = virtualProvider;
        var webView = WebView;

        webView.Settings.SetSupportMultipleWindows(true);
        webView.Settings.JavaScriptEnabled = true;
        webView.Settings.DomStorageEnabled = true;
        webView.Settings.SetSupportZoom(true);
        //webview.ZoomBy(1.2f);

        var bRet = await PrepareBlazorWebViewStarting(webView, virtualProvider);
        if (!bRet)
        {
            _webViewClient = new WebViewClient();
            _webChromeClient = new WebChromeClient();
            webView.SetWebViewClient(_webViewClient);
            webView.SetWebChromeClient(_webChromeClient);
        }
        IsInitialized = true;
        return true;
    }

    bool IWebViewControl.Navigate(Uri? uri)
    {
        if (uri is null)
            return false;

        var webView = WebView;
        if (webView is null)
            return false;

        webView.LoadUrl(uri.AbsoluteUri);
        return true;
    }

    bool IWebViewControl.NavigateToString(string htmlContent)
    {
        if (string.IsNullOrWhiteSpace(htmlContent))
            return false;

        var webView = WebView;
        if (webView is null)
            return false;

        webView.LoadData(htmlContent, default, default);
        return true;
    }

    bool IWebViewControl.OpenDevToolsWindow()
    {
        throw new NotImplementedException();
    }

    bool IWebViewControl.PostWebMessageAsJson(string webMessageAsJson)
    {
        throw new NotImplementedException();
    }

    bool IWebViewControl.PostWebMessageAsString(string webMessageAsString)
    {
        if (string.IsNullOrWhiteSpace(webMessageAsString))
            return false;

        var webView = WebView;
        if (webView is null)
            return false;

        webView.PostWebMessage(new WebMessage(webMessageAsString), default!);
        return true;
    }

    bool IWebViewControl.Reload()
    {
        var webView = WebView;
        if (webView is null)
            return false;

        webView.Reload();
        return true;
    }

    bool IWebViewControl.Stop()
    {
        var webView = WebView;
        if (webView is null)
            return false;

        webView.StopLoading();
        return true;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!IsDisposed)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            ClearBlazorWebViewCompleted();
            UnregisterEvents();
            WebView.Dispose();
            WebView = default!;
            IsDisposed = true;
        }
    }

    void IDisposable.Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }


    ValueTask IAsyncDisposable.DisposeAsync()
    {
        ((IDisposable)this)?.Dispose();
        return new ValueTask();
    }

}
