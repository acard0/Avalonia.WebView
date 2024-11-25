using Foundation;
using ObjCRuntime;

namespace WebKit;

[Protocol(Name = "WKUIDelegate", WrapperType = typeof(WKUIDelegateWrapper))]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "CreateWebView", Selector = "webView:createWebViewWithConfiguration:forNavigationAction:windowFeatures:", ReturnType = typeof(WKWebView), ParameterType =
[
    typeof(WKWebView),
    typeof(WKWebViewConfiguration),
    typeof(WKNavigationAction),
    typeof(WKWindowFeatures)
], ParameterByRef = [false, false, false, false])]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "RunJavaScriptAlertPanel", Selector = "webView:runJavaScriptAlertPanelWithMessage:initiatedByFrame:completionHandler:", ParameterType =
[
    typeof(WKWebView),
    typeof(string),
    typeof(WKFrameInfo),
    typeof(Action)
], ParameterByRef = [false, false, false, false], ParameterBlockProxy = new Type[]
{
    null,
    null,
    null,
    typeof(Trampolines.NIDAction)
})]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "RunJavaScriptConfirmPanel", Selector = "webView:runJavaScriptConfirmPanelWithMessage:initiatedByFrame:completionHandler:", ParameterType =
[
    typeof(WKWebView),
    typeof(string),
    typeof(WKFrameInfo),
    typeof(Action<bool>)
], ParameterByRef = [false, false, false, false], ParameterBlockProxy = new Type[]
{
    null,
    null,
    null,
    typeof(Trampolines.NIDActionArity1V2)
})]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "RunJavaScriptTextInputPanel", Selector = "webView:runJavaScriptTextInputPanelWithPrompt:defaultText:initiatedByFrame:completionHandler:", ParameterType =
[
    typeof(WKWebView),
    typeof(string),
    typeof(string),
    typeof(WKFrameInfo),
    typeof(Action<string>)
], ParameterByRef = [false, false, false, false, false], ParameterBlockProxy = new Type[]
{
    null,
    null,
    null,
    null,
    typeof(Trampolines.NIDActionArity1V44)
})]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "RunOpenPanel", Selector = "webView:runOpenPanelWithParameters:initiatedByFrame:completionHandler:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKOpenPanelParameters),
    typeof(WKFrameInfo),
    typeof(Action<NSUrl[]>)
], ParameterByRef = [false, false, false, false], ParameterBlockProxy = new Type[]
{
    null,
    null,
    null,
    typeof(Trampolines.NIDActionArity1V95)
})]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidClose", Selector = "webViewDidClose:", ParameterType = [typeof(WKWebView)], ParameterByRef = [false])]

public interface IWKUIDelegate : INativeObject, IDisposable
{
}
