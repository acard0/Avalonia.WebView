﻿using Foundation;
using ObjCRuntime;

namespace WebKit;

[Protocol(Name = "WebOpenPanelResultListener", WrapperType = typeof(WebOpenPanelResultListenerWrapper))]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "ChooseFilename", Selector = "chooseFilename:", ParameterType = [typeof(string)], ParameterByRef = [false])]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "ChooseFilenames", Selector = "chooseFilenames:", ParameterType = [typeof(string[])], ParameterByRef = [false])]
[ProtocolMember(IsRequired = false, IsProperty = false, IsStatic = false, Name = "Cancel", Selector = "cancel")]
public interface IWebOpenPanelResultListener : INativeObject, IDisposable
{
}
