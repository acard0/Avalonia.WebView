using Foundation;
using ObjCRuntime;
namespace WebKit;

[Protocol(Name = "WKHTTPCookieStoreObserver", WrapperType = typeof(WKHttpCookieStoreObserverWrapper))]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "CookiesDidChangeInCookieStore", Selector = "cookiesDidChangeInCookieStore:", ParameterType = [typeof(WKHttpCookieStore)], ParameterByRef = [false])]
public interface IWKHttpCookieStoreObserver : INativeObject, IDisposable
{
}
