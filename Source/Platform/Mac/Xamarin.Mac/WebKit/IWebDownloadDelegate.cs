using AppKit;
using Foundation;
using ObjCRuntime;

namespace WebKit;

[Protocol(Name = "WebDownloadDelegate", WrapperType = typeof(WebDownloadDelegateWrapper), FormalSince = "10.11")]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "OnDownloadWindowForSheet", Selector = "downloadWindowForAuthenticationSheet:", ReturnType = typeof(NSWindow), ParameterType = [typeof(WebDownload)], ParameterByRef = [false])]
public interface IWebDownloadDelegate : INativeObject, IDisposable
{
}
