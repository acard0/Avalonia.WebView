using Foundation;
using ObjCRuntime;

namespace WebKit;

[Protocol(Name = "WKScriptMessageHandler", WrapperType = typeof(WKScriptMessageHandlerWrapper))]
[ProtocolMember(IsRequired = true, IsProperty = false, IsStatic = false, Name = "DidReceiveScriptMessage", Selector = "userContentController:didReceiveScriptMessage:", ParameterType =
[
    typeof(WKUserContentController),
    typeof(WKScriptMessage)
], ParameterByRef = [false, false])]
public interface IWKScriptMessageHandler : INativeObject, IDisposable
{
    [Export("userContentController:didReceiveScriptMessage:")]
    [Preserve(Conditional = true)]
    void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message);
}
