using Foundation;
using ObjCRuntime;

namespace WebKit;

[Protocol(Name = "WKURLSchemeHandler", WrapperType = typeof(WKUrlSchemeHandlerWrapper))]
[ProtocolMember(IsRequired = true, IsProperty = false, IsStatic = false, Name = "StartUrlSchemeTask", Selector = "webView:startURLSchemeTask:", ParameterType =
[
    typeof(WKWebView),
    typeof(IWKUrlSchemeTask)
], ParameterByRef = [false, false])]
[ProtocolMember(IsRequired = true, IsProperty = false, IsStatic = false, Name = "StopUrlSchemeTask", Selector = "webView:stopURLSchemeTask:", ParameterType =
[
    typeof(WKWebView),
    typeof(IWKUrlSchemeTask)
], ParameterByRef = [false, false])]
public interface IWKUrlSchemeHandler : INativeObject, IDisposable
{
    [Export("webView:startURLSchemeTask:")]
    [Preserve(Conditional = true)]
    void StartUrlSchemeTask(WKWebView webView, IWKUrlSchemeTask urlSchemeTask);

    [Export("webView:stopURLSchemeTask:")]
    [Preserve(Conditional = true)]
    void StopUrlSchemeTask(WKWebView webView, IWKUrlSchemeTask urlSchemeTask);
}