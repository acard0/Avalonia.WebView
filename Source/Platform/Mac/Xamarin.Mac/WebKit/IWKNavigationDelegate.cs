using Foundation;
using ObjCRuntime;
namespace WebKit;

[Protocol(Name = "WKNavigationDelegate", WrapperType = typeof(WKNavigationDelegateWrapper))]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DecidePolicy", Selector = "webView:decidePolicyForNavigationAction:decisionHandler:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKNavigationAction),
    typeof(Action<WKNavigationActionPolicy>)
], ParameterByRef = [false, false, false], ParameterBlockProxy = new Type[]
{
    null,
    null,
    typeof(Trampolines.NIDActionArity1V93)
})]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DecidePolicy", Selector = "webView:decidePolicyForNavigationResponse:decisionHandler:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKNavigationResponse),
    typeof(Action<WKNavigationResponsePolicy>)
], ParameterByRef = [false, false, false], ParameterBlockProxy = new Type[]
{
    null,
    null,
    typeof(Trampolines.NIDActionArity1V94)
})]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DecidePolicy", Selector = "webView:decidePolicyForNavigationAction:preferences:decisionHandler:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKNavigationAction),
    typeof(WKWebpagePreferences),
    typeof(Action<WKNavigationActionPolicy, WKWebpagePreferences>)
], ParameterByRef = [false, false, false, false], ParameterBlockProxy = new Type[]
{
    null,
    null,
    null,
    typeof(Trampolines.NIDActionArity2V85)
})]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidStartProvisionalNavigation", Selector = "webView:didStartProvisionalNavigation:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKNavigation)
], ParameterByRef = [false, false])]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidReceiveServerRedirectForProvisionalNavigation", Selector = "webView:didReceiveServerRedirectForProvisionalNavigation:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKNavigation)
], ParameterByRef = [false, false])]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidFailProvisionalNavigation", Selector = "webView:didFailProvisionalNavigation:withError:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKNavigation),
    typeof(NSError)
], ParameterByRef = [false, false, false])]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidCommitNavigation", Selector = "webView:didCommitNavigation:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKNavigation)
], ParameterByRef = [false, false])]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidFinishNavigation", Selector = "webView:didFinishNavigation:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKNavigation)
], ParameterByRef = [false, false])]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidFailNavigation", Selector = "webView:didFailNavigation:withError:", ParameterType =
[
    typeof(WKWebView),
    typeof(WKNavigation),
    typeof(NSError)
], ParameterByRef = [false, false, false])]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "DidReceiveAuthenticationChallenge", Selector = "webView:didReceiveAuthenticationChallenge:completionHandler:", ParameterType =
[
    typeof(WKWebView),
    typeof(NSUrlAuthenticationChallenge),
    typeof(Action<NSUrlSessionAuthChallengeDisposition, NSUrlCredential>)
], ParameterByRef = [false, false, false], ParameterBlockProxy = new Type[]
{
    null,
    null,
    typeof(Trampolines.NIDActionArity2V44)
})]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "ContentProcessDidTerminate", Selector = "webViewWebContentProcessDidTerminate:", ParameterType = [typeof(WKWebView)], ParameterByRef = [false])]

public interface IWKNavigationDelegate : INativeObject, IDisposable
{
}