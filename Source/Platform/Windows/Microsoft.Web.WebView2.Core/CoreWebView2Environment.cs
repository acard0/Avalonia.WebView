using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core.Raw;

namespace Microsoft.Web.WebView2.Core;

/// <summary>
/// This represents the WebView2 Environment.
/// </summary>
/// <remarks>
/// WebViews created from an environment run on the Browser process specified with environment parameters and objects created from an environment should be used in the same environment. Using it in different environments are not guaranteed to be compatible and may fail.
/// </remarks>
public class CoreWebView2Environment
{
    private enum ProcessorArchitecture : ushort
    {
        x86 = 0,
        x64 = 9,
        ARM64 = 12,
        Unknown = ushort.MaxValue
    }

    private struct SYSTEM_INFO
    {
        internal ushort wProcessorArchitecture;

        private ushort wReserved;

        private int dwPageSize;

        private IntPtr lpMinimumApplicationAddress;

        private IntPtr lpMaximumApplicationAddress;

        private IntPtr dwActiveProcessorMask;

        private int dwNumberOfProcessors;

        private int dwProcessorType;

        private int dwAllocationGranularity;

        private short wProcessorLevel;

        private short wProcessorRevision;
    }

    private static bool webView2LoaderLoaded;

    internal ICoreWebView2Environment _nativeICoreWebView2EnvironmentValue;

    internal ICoreWebView2Environment2 _nativeICoreWebView2Environment2Value;

    internal ICoreWebView2Environment3 _nativeICoreWebView2Environment3Value;

    internal ICoreWebView2Environment4 _nativeICoreWebView2Environment4Value;

    internal ICoreWebView2Environment5 _nativeICoreWebView2Environment5Value;

    internal ICoreWebView2Environment6 _nativeICoreWebView2Environment6Value;

    internal ICoreWebView2Environment7 _nativeICoreWebView2Environment7Value;

    internal object _rawNative;

    private EventRegistrationToken _newBrowserVersionAvailableToken;

    private EventHandler<object> newBrowserVersionAvailable;

    private EventRegistrationToken _browserProcessExitedToken;

    private EventHandler<CoreWebView2BrowserProcessExitedEventArgs> browserProcessExited;

    internal ICoreWebView2Environment _nativeICoreWebView2Environment
    {
        get
        {
            if (_nativeICoreWebView2EnvironmentValue == null)
            {
                try
                {
                    _nativeICoreWebView2EnvironmentValue = (ICoreWebView2Environment)_rawNative;
                }
                catch (Exception inner)
                {
                    throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://docs.microsoft.com/microsoft-edge/webview2/concepts/versioning", inner);
                }
            }
            return _nativeICoreWebView2EnvironmentValue;
        }
        set
        {
            _nativeICoreWebView2EnvironmentValue = value;
        }
    }

    internal ICoreWebView2Environment2 _nativeICoreWebView2Environment2
    {
        get
        {
            if (_nativeICoreWebView2Environment2Value == null)
            {
                try
                {
                    _nativeICoreWebView2Environment2Value = (ICoreWebView2Environment2)_rawNative;
                }
                catch (Exception inner)
                {
                    throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment2.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://docs.microsoft.com/microsoft-edge/webview2/concepts/versioning", inner);
                }
            }
            return _nativeICoreWebView2Environment2Value;
        }
        set
        {
            _nativeICoreWebView2Environment2Value = value;
        }
    }

    internal ICoreWebView2Environment3 _nativeICoreWebView2Environment3
    {
        get
        {
            if (_nativeICoreWebView2Environment3Value == null)
            {
                try
                {
                    _nativeICoreWebView2Environment3Value = (ICoreWebView2Environment3)_rawNative;
                }
                catch (Exception inner)
                {
                    throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment3.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://docs.microsoft.com/microsoft-edge/webview2/concepts/versioning", inner);
                }
            }
            return _nativeICoreWebView2Environment3Value;
        }
        set
        {
            _nativeICoreWebView2Environment3Value = value;
        }
    }

    internal ICoreWebView2Environment4 _nativeICoreWebView2Environment4
    {
        get
        {
            if (_nativeICoreWebView2Environment4Value == null)
            {
                try
                {
                    _nativeICoreWebView2Environment4Value = (ICoreWebView2Environment4)_rawNative;
                }
                catch (Exception inner)
                {
                    throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment4.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://docs.microsoft.com/microsoft-edge/webview2/concepts/versioning", inner);
                }
            }
            return _nativeICoreWebView2Environment4Value;
        }
        set
        {
            _nativeICoreWebView2Environment4Value = value;
        }
    }

    internal ICoreWebView2Environment5 _nativeICoreWebView2Environment5
    {
        get
        {
            if (_nativeICoreWebView2Environment5Value == null)
            {
                try
                {
                    _nativeICoreWebView2Environment5Value = (ICoreWebView2Environment5)_rawNative;
                }
                catch (Exception inner)
                {
                    throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment5.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://docs.microsoft.com/microsoft-edge/webview2/concepts/versioning", inner);
                }
            }
            return _nativeICoreWebView2Environment5Value;
        }
        set
        {
            _nativeICoreWebView2Environment5Value = value;
        }
    }

    internal ICoreWebView2Environment6 _nativeICoreWebView2Environment6
    {
        get
        {
            if (_nativeICoreWebView2Environment6Value == null)
            {
                try
                {
                    _nativeICoreWebView2Environment6Value = (ICoreWebView2Environment6)_rawNative;
                }
                catch (Exception inner)
                {
                    throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment6.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://docs.microsoft.com/microsoft-edge/webview2/concepts/versioning", inner);
                }
            }
            return _nativeICoreWebView2Environment6Value;
        }
        set
        {
            _nativeICoreWebView2Environment6Value = value;
        }
    }

    internal ICoreWebView2Environment7 _nativeICoreWebView2Environment7
    {
        get
        {
            if (_nativeICoreWebView2Environment7Value == null)
            {
                try
                {
                    _nativeICoreWebView2Environment7Value = (ICoreWebView2Environment7)_rawNative;
                }
                catch (Exception inner)
                {
                    throw new NotImplementedException("Unable to cast to Microsoft.Web.WebView2.Core.Raw.ICoreWebView2Environment7.\nThis may happen if you are using an interface not supported by the version of the WebView2 Runtime you are using.\nFor instance, if you are using an experimental interface from an older SDK that has been modified or removed in a newer runtime.\nOr, if you are using a public interface from a newer SDK that wasn't implemented in an older runtime.\nFor more information about WebView2 versioning please visit the following: https://docs.microsoft.com/microsoft-edge/webview2/concepts/versioning", inner);
                }
            }
            return _nativeICoreWebView2Environment7Value;
        }
        set
        {
            _nativeICoreWebView2Environment7Value = value;
        }
    }

    /// <summary>
    /// Gets the browser version info of the current <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2Environment" />, including channel name if it is not the stable channel.
    /// </summary>
    /// <remarks>
    /// It matches the format of the <see cref="M:Microsoft.Web.WebView2.Core.CoreWebView2Environment.GetAvailableBrowserVersionString(System.String)" /> method. Channel names are <c>beta</c>, <c>dev</c>, and <c>canary</c>.
    /// </remarks>
    public string BrowserVersionString
    {
        get
        {
            try
            {
                return _nativeICoreWebView2Environment.BrowserVersionString;
            }
            catch (InvalidCastException ex)
            {
                if (ex.HResult == -2147467262)
                {
                    throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
                }
                throw ex;
            }
            catch (COMException ex2)
            {
                if (ex2.HResult == -2147019873)
                {
                    throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
                }
                throw ex2;
            }
        }
    }

    /// <summary>
    /// Gets the user data folder that all CoreWebView2s created from this environment are using.
    /// </summary>
    /// <remarks>
    /// This could be either the value passed in by the developer when creating the environment object or the calculated one for default handling. And will always be an absolute path.
    /// </remarks>
    public string UserDataFolder
    {
        get
        {
            try
            {
                return _nativeICoreWebView2Environment7.UserDataFolder;
            }
            catch (InvalidCastException ex)
            {
                if (ex.HResult == -2147467262)
                {
                    throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
                }
                throw ex;
            }
            catch (COMException ex2)
            {
                if (ex2.HResult == -2147019873)
                {
                    throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
                }
                throw ex2;
            }
        }
    }

    /// <summary>
    /// NewBrowserVersionAvailable is raised when a newer version of the WebView2 Runtime is installed and available using WebView2.
    /// </summary>
    /// <remarks>
    /// To use the newer version of the browser you must create a new environment and WebView. The event is only raised for new version from the same WebView2 Runtime from which the code is running. When not running with installed WebView2 Runtime, no event is raised.
    ///
    /// Because a user data folder is only able to be used by one browser process at a time, if you want to use the same user data folder in the WebViews using the new version of the browser, you must close the environment and instance of WebView that are using the older version of the browser first. Or simply prompt the user to restart the app.
    /// </remarks>
    public event EventHandler<object> NewBrowserVersionAvailable
    {
        add
        {
            if (newBrowserVersionAvailable == null)
            {
                try
                {
                    _nativeICoreWebView2Environment.add_NewBrowserVersionAvailable(new CoreWebView2NewBrowserVersionAvailableEventHandler(OnNewBrowserVersionAvailable), out _newBrowserVersionAvailableToken);
                }
                catch (InvalidCastException ex)
                {
                    if (ex.HResult == -2147467262)
                    {
                        throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
                    }
                    throw ex;
                }
                catch (COMException ex2)
                {
                    if (ex2.HResult == -2147019873)
                    {
                        throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
                    }
                    throw ex2;
                }
            }
            newBrowserVersionAvailable = (EventHandler<object>)Delegate.Combine(newBrowserVersionAvailable, value);
        }
        remove
        {
            newBrowserVersionAvailable = (EventHandler<object>)Delegate.Remove(newBrowserVersionAvailable, value);
            if (newBrowserVersionAvailable != null)
            {
                return;
            }
            try
            {
                _nativeICoreWebView2Environment.remove_NewBrowserVersionAvailable(_newBrowserVersionAvailableToken);
            }
            catch (InvalidCastException ex)
            {
                if (ex.HResult == -2147467262)
                {
                    throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
                }
                throw ex;
            }
            catch (COMException ex2)
            {
                if (ex2.HResult == -2147019873)
                {
                    throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
                }
                throw ex2;
            }
        }
    }

    /// <summary>
    /// BrowserProcessExited is raised when the collection of WebView2 Runtime processes for the browser process of this <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2Environment" /> terminate due to browser process failure or normal shutdown (for example, when all associated WebViews are closed), after all resources have been released (including the user data folder).
    /// </summary>
    /// <remarks>
    /// Multiple app processes can share a browser process by creating their webviews from a <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2Environment" /> with the same user data folder. When the entire collection of WebView2Runtime processes for the browser process exit, all associated <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2Environment" /> objects receive the BrowserProcessExited event. Multiple processes sharing the same browser process need to coordinate their use of the shared user data folder to avoid race conditions and unnecessary waits. For example, one process should not clear the user data folder at the same time that another process recovers from a crash by recreating its WebView controls; one process should not block waiting for the event if other app processes are using the same browser process (the browser process will not exit until those other processes have closed their webviews too).
    ///
    /// Note this is an event from <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2Environment" />, not <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2" />. The difference between BrowserProcessExited and <see cref="E:Microsoft.Web.WebView2.Core.CoreWebView2.ProcessFailed" /> is that BrowserProcessExited is raised for any <strong>browser process</strong> exit (expected or unexpected, after all associated processes have exited too), while <see cref="E:Microsoft.Web.WebView2.Core.CoreWebView2.ProcessFailed" /> is raised for <strong>unexpected</strong> process exits of any kind (browser, render, GPU, and all other types), or for main frame <strong>render process</strong> unresponsiveness. To learn more about the WebView2 Process Model, go to [Process model](/microsoft-edge/webview2/concepts/process-model).
    ///
    /// In the case the browser process crashes, both BrowserProcessExited and <see cref="E:Microsoft.Web.WebView2.Core.CoreWebView2.ProcessFailed" /> events are raised, but the order is not guaranteed. These events are intended for different scenarios. It is up to the app to coordinate the handlers so they do not try to perform reliability recovery while also trying to move to a new WebView2 Runtime version or remove the user data folder.
    /// </remarks>
    public event EventHandler<CoreWebView2BrowserProcessExitedEventArgs> BrowserProcessExited
    {
        add
        {
            if (browserProcessExited == null)
            {
                try
                {
                    _nativeICoreWebView2Environment5.add_BrowserProcessExited(new CoreWebView2BrowserProcessExitedEventHandler(OnBrowserProcessExited), out _browserProcessExitedToken);
                }
                catch (InvalidCastException ex)
                {
                    if (ex.HResult == -2147467262)
                    {
                        throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
                    }
                    throw ex;
                }
                catch (COMException ex2)
                {
                    if (ex2.HResult == -2147019873)
                    {
                        throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
                    }
                    throw ex2;
                }
            }
            browserProcessExited = (EventHandler<CoreWebView2BrowserProcessExitedEventArgs>)Delegate.Combine(browserProcessExited, value);
        }
        remove
        {
            browserProcessExited = (EventHandler<CoreWebView2BrowserProcessExitedEventArgs>)Delegate.Remove(browserProcessExited, value);
            if (browserProcessExited != null)
            {
                return;
            }
            try
            {
                _nativeICoreWebView2Environment5.remove_BrowserProcessExited(_browserProcessExitedToken);
            }
            catch (InvalidCastException ex)
            {
                if (ex.HResult == -2147467262)
                {
                    throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
                }
                throw ex;
            }
            catch (COMException ex2)
            {
                if (ex2.HResult == -2147019873)
                {
                    throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
                }
                throw ex2;
            }
        }
    }

    [DllImport("WebView2Loader.dll")]
    internal static extern int CreateCoreWebView2EnvironmentWithOptions([In][MarshalAs(UnmanagedType.LPWStr)] string browserExecutableFolder, [In][MarshalAs(UnmanagedType.LPWStr)] string userDataFolder, ICoreWebView2EnvironmentOptions options, ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler environment_created_handler);

    [DllImport("WebView2Loader.dll")]
    internal static extern int GetAvailableCoreWebView2BrowserVersionString([In][MarshalAs(UnmanagedType.LPWStr)] string browserExecutableFolder, [MarshalAs(UnmanagedType.LPWStr)] ref string versionInfo);

    [DllImport("WebView2Loader.dll")]
    internal static extern int CompareBrowserVersions([In][MarshalAs(UnmanagedType.LPWStr)] string version1, [In][MarshalAs(UnmanagedType.LPWStr)] string version2, ref int result);

    /// <summary>
    /// Creates a WebView2 Environment using the installed or a custom WebView2 Runtime version.
    /// </summary>
    /// <param name="browserExecutableFolder">
    /// The relative path to the folder that contains a custom version of WebView2 Runtime.
    /// <para>
    /// To use a fixed version of the WebView2 Runtime, pass the
    /// folder path that contains the fixed version of the WebView2 Runtime
    /// to <c>browserExecutableFolder</c>. BrowserExecutableFolder supports both relative 
    /// (to the application's executable) and absolute file paths. To create WebView2 controls 
    /// that use the installed version of the WebView2 Runtime that exists on
    /// user machines, pass a <c>null</c> or empty string to
    /// <c>browserExecutableFolder</c>. In this scenario, the API tries to 
    /// find a compatible version of the WebView2 Runtime that is installed
    /// on the user machine (first at the machine level, and then per user)
    /// using the selected channel preference. The path of fixed version of
    /// the WebView2 Runtime should not contain <em>\Edge\Application\</em>. When
    /// such a path is used, the API fails with <c>ERROR_NOT_SUPPORTED</c>.
    /// </para>
    /// </param>
    /// <param name="userDataFolder">
    /// The user data folder location for WebView2.
    /// <para>
    /// The path is either an absolute file path or a relative file path
    /// that is interpreted as relative to the compiled code for the
    /// current process. The default user data folder <em>{Executable File
    /// Name}.WebView2</em> is created in the same directory next to the
    /// compiled code for the app. WebView2 creation fails if the compiled
    /// code is running in a directory in which the process does not have
    /// permission to create a new directory. The app is responsible to
    /// clean up the associated user data folder when it is done.
    /// </para>
    /// </param>
    /// <param name="options">
    /// Options used to create WebView2 Environment.
    /// <para>
    /// As a browser process may be shared among WebViews, WebView creation
    /// fails if the specified <c>options</c> does not match the options of
    /// the WebViews that are currently running in the shared browser
    /// process.
    /// </para>
    /// </param>
    /// <remarks>
    /// <para>
    /// The default channel search order is the WebView2 Runtime, Beta, Dev, and
    /// Canary. When an override <c>WEBVIEW2_RELEASE_CHANNEL_PREFERENCE</c> environment
    /// variable or applicable <c>releaseChannelPreference</c> registry value is set to
    /// <c>1</c>, the channel search order is reversed.
    /// </para>
    /// <para>
    /// To use a fixed version of the WebView2 Runtime, pass the relative
    /// folder path that contains the fixed version of the WebView2 Runtime
    /// to <c>browserExecutableFolder</c>. To create WebView2 controls that
    /// use the installed version of the WebView2 Runtime that exists on
    /// user machines, pass a <c>null</c> or empty string to
    /// <c>browserExecutableFolder</c>. In this scenario, the API tries to
    /// find a compatible version of the WebView2 Runtime that is installed
    /// on the user machine (first at the machine level, and then per user)
    /// using the selected channel preference. The path of fixed version of
    /// the WebView2 Runtime should not contain <em>\Edge\Application\</em>. When
    /// such a path is used, the API fails with the following error.
    /// </para>
    /// <para>
    /// The <paramref name="browserExecutableFolder" />, <paramref name="userDataFolder" />, and <paramref name="options" /> may be
    /// overridden by values either specified in environment variables or in
    /// the registry.
    /// </para>
    /// <para>
    /// When creating a <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2Environment" /> the following environment variables are verified.
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c>WEBVIEW2_BROWSER_EXECUTABLE_FOLDER</c></term>
    /// </item>
    /// <item>
    /// <term><c>WEBVIEW2_USER_DATA_FOLDER</c></term>
    /// </item>
    /// <item>
    /// <term><c>WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS</c></term>
    /// </item>
    /// <item>
    /// <term><c>WEBVIEW2_RELEASE_CHANNEL_PREFERENCE</c></term>
    /// </item>
    /// </list>
    /// <para>
    /// If browser executable folder or user data folder is specified in an
    /// environment variable or in the registry, the specified <paramref name="browserExecutableFolder" /> or <paramref name="userDataFolder" /> values are overridden. If additional browser
    /// arguments are specified in an environment variable or in the
    /// registry, it is appended to the corresponding value in the specified
    /// <paramref name="options" />.
    /// </para>
    /// <para>
    /// While not strictly overrides, additional environment variables may be set.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>Value</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term><c>WEBVIEW2_WAIT_FOR_SCRIPT_DEBUGGER</c></term>
    /// <description>
    /// When found with a non-empty value, this indicates that the WebView
    /// is being launched under a script debugger. In this case, the WebView
    /// issues a <c>Page.waitForDebugger</c> CDP command that runs the
    /// script inside the WebView to pause on launch, until a debugger
    /// issues a corresponding <c>Runtime.runIfWaitingForDebugger</c> CDP
    /// command to resume the runtime.
    /// Note that this environment variable does not have a registry key equivalent.
    /// </description>
    /// </item>
    /// <item>
    /// <term><c>WEBVIEW2_PIPE_FOR_SCRIPT_DEBUGGER</c></term>
    /// <description>
    /// When found with a non-empty value, it indicates that the WebView is
    /// being launched under a script debugger that also supports host apps
    /// that use multiple WebViews. The value is used as the identifier for
    /// a named pipe that is opened and written to when a new WebView is
    /// created by the host app. The payload should match the payload of the
    /// <c>remote-debugging-port</c> JSON target and an external debugger
    /// may use it to attach to a specific WebView instance. The format of
    /// the pipe created by the debugger should be
    /// <c>\\.\pipe\WebView2\Debugger\{app_name}\{pipe_name}</c>, where the
    /// following are true.
    ///
    /// <list type="bullet">
    /// <item><description><c>{app_name}</c> is the host app exe file name, for example, <c>WebView2Example.exe</c></description></item>
    /// <item><description><c>{pipe_name}</c> is the value set for <c>WEBVIEW2_PIPE_FOR_SCRIPT_DEBUGGER</c></description></item>
    /// </list>
    ///
    /// To enable debugging of the targets identified by the JSON, you must
    /// set the <c>WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS</c> environment
    /// variable to send <c>--remote-debugging-port={port_num}</c>, where
    /// the following is true.
    ///
    /// <list type="bullet">
    /// <item><description><c>{port_num}</c> is the port on which the CDP server binds.</description></item>
    /// </list>
    ///
    /// If both <c>WEBVIEW2_PIPE_FOR_SCRIPT_DEBUGGER</c> and
    /// <c>WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS</c> environment variables,
    /// the WebViews hosted in your app and associated contents may exposed
    /// to 3rd party apps such as debuggers. Note that this environment
    /// variable does not have a registry key equivalent.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// If none of those environment variables exist, then the registry is examined
    /// next.
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <term><c>[{Root}]\Software\Policies\Microsoft\Edge\WebView2\BrowserExecutableFolder "{AppId}"=""</c></term>
    /// </item>
    /// <item>
    /// <term><c>[{Root}]\Software\Policies\Microsoft\Edge\WebView2\ReleaseChannelPreference "{AppId}"=""</c></term>
    /// </item>
    /// <item>
    /// <term><c>[{Root}]\Software\Policies\Microsoft\Edge\WebView2\AdditionalBrowserArguments "{AppId}"=""</c></term>
    /// </item>
    /// <item>
    /// <term><c>[{Root}]\Software\Policies\Microsoft\Edge\WebView2\UserDataFolder "{AppId}"=""</c></term>
    /// </item>
    /// </list>
    /// <para>
    /// Use a group policy under <strong>Administrative Templates</strong> &gt;
    /// <strong>Microsoft Edge WebView2</strong> to configure browser executable folder
    /// and release channel preference.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>Value</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term><c>ERROR_DISK_FULL</c></term>
    /// <description>
    /// In the unlikely scenario where some instances of WebView are open during a
    /// browser update, the deletion of the previous WebView2 Runtime may be
    /// blocked. To avoid running out of disk space, a new WebView creation fails
    /// with this error if it detects that too many previous WebView2
    /// Runtime versions exist.
    /// </description>
    /// </item>
    /// <item>
    /// <term><c>WEBVIEW2_MAX_INSTANCES</c></term>
    /// <description>
    /// The default maximum number of WebView2 Runtime versions allowed is <c>20</c>.
    /// To override the maximum number of the previous WebView2 Runtime versions
    /// allowed, set the value of the following environment variable.
    /// </description>
    /// </item>
    /// <item>
    /// <term><c>ERROR_PRODUCT_UNINSTALLED</c></term>
    /// <description>
    /// If the Webview depends upon an installed WebView2 Runtime version and it is
    /// uninstalled, any subsequent creation fails with this error.
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// First verify with Root as <c>HKLM</c> and then <c>HKCU</c>. <c>AppId</c> is first set to
    /// the Application User Model ID of the process, then if no corresponding
    /// registry key, the <c>AppId</c> is set to the compiled code name of the process,
    /// or if that is not a registry key then <c>*</c>. If an override registry key is
    /// found, use the <c>browserExecutableFolder</c> and <c>userDataFolder</c> registry
    /// values as replacements and append <c>additionalBrowserArguments</c> registry
    /// values for the corresponding values in the provided <paramref name="options" />.
    /// </para>
    /// </remarks>
    public static async Task<CoreWebView2Environment> CreateAsync(string browserExecutableFolder = null, string userDataFolder = null, CoreWebView2EnvironmentOptions options = null)
    {
        LoadWebView2LoaderDll();
        CoreWebView2CreateCoreWebView2EnvironmentCompletedHandler handler = new();
        CoreWebView2EnvironmentOptions coreWebView2EnvironmentOptions = options ?? new CoreWebView2EnvironmentOptions();
        int num = CreateCoreWebView2EnvironmentWithOptions(browserExecutableFolder, userDataFolder, coreWebView2EnvironmentOptions._nativeICoreWebView2EnvironmentOptions, handler);
        if (num == -2147024894)
        {
            throw new WebView2RuntimeNotFoundException(Marshal.GetExceptionForHR(num));
        }
        Marshal.ThrowExceptionForHR(num);
        await handler;
        Marshal.ThrowExceptionForHR(handler.errCode);
        return handler.createdEnvironment;
    }

    /// <summary>
    /// Gets the browser version info including channel name if it is not the stable channel or WebView2 Runtime.
    /// </summary>
    /// <param name="browserExecutableFolder">
    /// The relative path to the folder that contains the WebView2 Runtime.
    /// </param>
    /// <exception cref="T:Microsoft.Web.WebView2.Core.WebView2RuntimeNotFoundException">
    /// WebView2 Runtime installation is missing.
    /// </exception>
    public static string GetAvailableBrowserVersionString(string browserExecutableFolder = null)
    {
        LoadWebView2LoaderDll();
        string versionInfo = null;
        int availableCoreWebView2BrowserVersionString = GetAvailableCoreWebView2BrowserVersionString(browserExecutableFolder, ref versionInfo);
        if (availableCoreWebView2BrowserVersionString == -2147024894)
        {
            throw new WebView2RuntimeNotFoundException(Marshal.GetExceptionForHR(availableCoreWebView2BrowserVersionString));
        }
        Marshal.ThrowExceptionForHR(availableCoreWebView2BrowserVersionString);
        return versionInfo;
    }

    /// <summary>
    /// Compares two instances of browser versions correctly and returns an integer that indicates whether the first instance is older, the same as, or newer than the second instance.
    /// </summary>
    /// <param name="version1">
    /// One of the version strings to compare.
    /// </param>
    /// <param name="version2">
    /// The other version string to compare.
    /// </param>
    /// <returns>
    /// An integer that indicates whether the first instance is older, the same as, or newer than the second instance.
    /// <list type="table">
    /// <listheader>
    /// <description>Value Type</description>
    /// <description>Condition</description>
    /// </listheader>
    /// <item>
    /// <description>Less than zero</description>
    /// <description><c>version1</c> is older than <c>version2</c>.</description>
    /// </item>
    /// <item>
    /// <description>Zero</description>
    /// <description><c>version1</c> is the same as <c>version2</c>.</description>
    /// </item>
    /// <item>
    /// <description>Greater than zero</description>
    /// <description><c>version1</c> is newer than <c>version2</c>.</description>
    /// </item>
    /// </list>
    /// </returns>
    public static int CompareBrowserVersions(string version1, string version2)
    {
        LoadWebView2LoaderDll();
        int result = 0;
        Marshal.ThrowExceptionForHR(CompareBrowserVersions(version1, version2, ref result));
        return result;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2WebResourceRequest" /> object.
    /// </summary>
    /// <param name="uri">The request URI.</param>
    /// <param name="Method">The HTTP request method.</param>
    /// <param name="postData"></param>
    /// <param name="Headers">The raw request header string delimited by CRLF (optional in last header).</param>
    /// <remarks>
    /// <c>uri</c> parameter must be absolute URI. It's also possible to create this object with <c>null</c> headers string and then use the <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2HttpRequestHeaders" /> to construct the headers line by line.
    /// </remarks>
    /// <seealso cref="T:Microsoft.Web.WebView2.Core.CoreWebView2WebResourceRequest" />
    public CoreWebView2WebResourceRequest CreateWebResourceRequest(string uri, string Method, Stream postData, string Headers)
    {
        return new CoreWebView2WebResourceRequest(_nativeICoreWebView2Environment2.CreateWebResourceRequest(uri, Method, (postData == null) ? null : new ManagedIStream(postData), Headers));
    }

    private static ProcessorArchitecture GetArchitecture()
    {
        GetSystemInfo(out var lpSystemInfo);
        return (ProcessorArchitecture)lpSystemInfo.wProcessorArchitecture;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

    [DllImport("kernel32.dll", SetLastError = true)]
    internal static extern IntPtr LoadLibrary(string dllToLoad);

    private static bool IsDotNetFramework()
    {
        return typeof(object).Assembly.GetCustomAttribute<AssemblyProductAttribute>().Product.Contains(".NET Framework");
    }

    private static void LoadWebView2LoaderDll()
    {
        if (webView2LoaderLoaded)
        {
            return;
        }
        if (IsDotNetFramework())
        {
            string directoryName = Path.GetDirectoryName(new Uri(typeof(COMStreamWrapper).Assembly.Location).LocalPath);
            string text = "\\runtimes\\win-";
            string text2 = directoryName + GetArchitecture() switch
            {
                ProcessorArchitecture.x86 => text + "x86",
                ProcessorArchitecture.x64 => text + "x64",
                ProcessorArchitecture.ARM64 => text + "arm64",
                _ => throw new NotSupportedException("Unknown Processor Architecture of WebView2Loader.dll is not supported"),
            } + "\\native\\WebView2Loader.dll";
            if (File.Exists(text2) && LoadLibrary(text2) == IntPtr.Zero)
            {
                Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
        }
        webView2LoaderLoaded = true;
    }

    internal CoreWebView2Environment(object rawCoreWebView2Environment)
    {
        _rawNative = rawCoreWebView2Environment;
    }

    internal void OnNewBrowserVersionAvailable(object args)
    {
        newBrowserVersionAvailable?.Invoke(this, args);
    }

    /// <summary>
    /// Asynchronously creates a new WebView.
    /// </summary>
    /// <param name="ParentWindow">The HWND in which the WebView should be displayed and from which receive input.</param>
    /// <remarks>
    /// The WebView adds a child window to the provided window during WebView creation. Z-order and other things impacted by sibling window order are affected accordingly.
    ///
    /// <para>
    /// It is recommended that the application set Application User Model ID for the process or the application window. If none is set, during WebView creation a generated Application User Model ID is set to root window of <c>ParentWindow</c>.
    /// </para>
    ///
    /// <para>
    /// It is recommended that the app handles restart manager messages, to gracefully restart it in the case when the app is using the WebView2 Runtime from a certain installation and that installation is being uninstalled. For example, if a user installs a version of the WebView2 Runtime and opts to use another version of the WebView2 Runtime for testing the app, and then uninstalls the 1st version of the WebView2 Runtime without closing the app, the app restarts to allow un-installation to succeed.
    /// </para>
    ///
    /// <para>
    /// When the app retries CreateCoreWebView2ControllerAsync upon failure, it is recommended that the app restarts from creating a new WebView2 Environment. If a WebView2 Runtime update happens, the version associated with a WebView2 Environment may have been removed and causing the object to no longer work. Creating a new WebView2 Environment works since it uses the latest version.
    /// </para>
    ///
    /// <para>
    /// WebView creation fails if a running instance using the same user data folder exists, and the Environment objects have different <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2EnvironmentOptions" />. For example, if a WebView was created with one <see cref="P:Microsoft.Web.WebView2.Core.CoreWebView2EnvironmentOptions.Language" />, an attempt to create a WebView with a different <see cref="P:Microsoft.Web.WebView2.Core.CoreWebView2EnvironmentOptions.Language" /> using the same user data folder fails.
    /// </para>
    /// </remarks>
    public async Task<CoreWebView2Controller> CreateCoreWebView2ControllerAsync(IntPtr ParentWindow)
    {
        CoreWebView2CreateCoreWebView2ControllerCompletedHandler handler;
        try
        {
            handler = new CoreWebView2CreateCoreWebView2ControllerCompletedHandler();
            _nativeICoreWebView2Environment.CreateCoreWebView2Controller(ParentWindow, handler);
        }
        catch (InvalidCastException ex)
        {
            if (ex.HResult == -2147467262)
            {
                throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
            }
            throw ex;
        }
        catch (COMException ex2)
        {
            if (ex2.HResult == -2147019873)
            {
                throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
            }
            throw ex2;
        }
        await handler;
        Marshal.ThrowExceptionForHR(handler.errCode);
        return handler.createdController;
    }

    /// <summary>
    /// Creates a new <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2WebResourceResponse" /> object.
    /// </summary>
    /// <param name="Content">HTTP response content as stream.</param>
    /// <param name="StatusCode">The HTTP response status code.</param>
    /// <param name="ReasonPhrase">The HTTP response reason phrase.</param>
    /// <param name="Headers">The raw response header string delimited by newline.</param>
    /// <remarks>
    /// It is also possible to create this object with empty headers string and then use the <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2HttpResponseHeaders" /> to construct the headers line by line.
    /// </remarks>
    /// <seealso cref="T:Microsoft.Web.WebView2.Core.CoreWebView2WebResourceResponse" />
    public CoreWebView2WebResourceResponse CreateWebResourceResponse(Stream Content, int StatusCode, string ReasonPhrase, string Headers)
    {
        try
        {
            return new CoreWebView2WebResourceResponse(_nativeICoreWebView2Environment.CreateWebResourceResponse((Content == null) ? null : new ManagedIStream(Content), StatusCode, ReasonPhrase, Headers));
        }
        catch (InvalidCastException ex)
        {
            if (ex.HResult == -2147467262)
            {
                throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
            }
            throw ex;
        }
        catch (COMException ex2)
        {
            if (ex2.HResult == -2147019873)
            {
                throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
            }
            throw ex2;
        }
    }

    /// <summary>
    /// Asynchronously creates a new WebView for use with visual hosting.
    /// </summary>
    /// <param name="ParentWindow">The HWND in which the app will connect the visual tree of the WebView.</param>
    /// <remarks>
    /// <c>ParentWindow</c> will be the HWND that the app will receive pointer/mouse input meant for the WebView (and will need to use <see cref="M:Microsoft.Web.WebView2.Core.CoreWebView2CompositionController.SendMouseInput(Microsoft.Web.WebView2.Core.CoreWebView2MouseEventKind,Microsoft.Web.WebView2.Core.CoreWebView2MouseEventVirtualKeys,System.UInt32,System.Drawing.Point)" /> or <see cref="M:Microsoft.Web.WebView2.Core.CoreWebView2CompositionController.SendPointerInput(Microsoft.Web.WebView2.Core.CoreWebView2PointerEventKind,Microsoft.Web.WebView2.Core.CoreWebView2PointerInfo)" /> to forward). If the app moves the WebView visual tree to underneath a different window, then it needs to set <see cref="P:Microsoft.Web.WebView2.Core.CoreWebView2Controller.ParentWindow" /> to update the new parent HWND of the visual tree.
    ///
    /// Set <see cref="P:Microsoft.Web.WebView2.Core.CoreWebView2CompositionController.RootVisualTarget" /> property on the created <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2CompositionController" /> to provide a visual to host the browser's visual tree.
    ///
    /// It is recommended that the application set Application User Model ID for the process or the application window. If none is set, during WebView creation a generated Application User Model ID is set to root window of <c>ParentWindow</c>.
    ///
    /// CreateCoreWebView2Controller is supported in the following versions of Windows:
    ///
    /// - Windows 11
    /// - Windows 10
    /// - Windows Server 2019
    /// - Windows Server 2016
    ///
    /// </remarks>
    public async Task<CoreWebView2CompositionController> CreateCoreWebView2CompositionControllerAsync(IntPtr ParentWindow)
    {
        CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler handler;
        try
        {
            handler = new CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler();
            _nativeICoreWebView2Environment3.CreateCoreWebView2CompositionController(ParentWindow, handler);
        }
        catch (InvalidCastException ex)
        {
            if (ex.HResult == -2147467262)
            {
                throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
            }
            throw ex;
        }
        catch (COMException ex2)
        {
            if (ex2.HResult == -2147019873)
            {
                throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
            }
            throw ex2;
        }
        await handler;
        Marshal.ThrowExceptionForHR(handler.errCode);
        return handler.webView;
    }

    /// <summary>
    /// Creates an empty <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2PointerInfo" />.
    /// </summary>
    /// <remarks>
    /// The returned <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2PointerInfo" /> needs to be populated with all of the relevant info before calling <see cref="M:Microsoft.Web.WebView2.Core.CoreWebView2CompositionController.SendPointerInput(Microsoft.Web.WebView2.Core.CoreWebView2PointerEventKind,Microsoft.Web.WebView2.Core.CoreWebView2PointerInfo)" />.
    /// </remarks>
    public CoreWebView2PointerInfo CreateCoreWebView2PointerInfo()
    {
        try
        {
            return new CoreWebView2PointerInfo(_nativeICoreWebView2Environment3.CreateCoreWebView2PointerInfo());
        }
        catch (InvalidCastException ex)
        {
            if (ex.HResult == -2147467262)
            {
                throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
            }
            throw ex;
        }
        catch (COMException ex2)
        {
            if (ex2.HResult == -2147019873)
            {
                throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
            }
            throw ex2;
        }
    }

    internal void OnBrowserProcessExited(CoreWebView2BrowserProcessExitedEventArgs args)
    {
        browserProcessExited?.Invoke(this, args);
    }

    /// <summary>
    /// Creates the <see cref="T:Microsoft.Web.WebView2.Core.CoreWebView2PrintSettings" /> used by the <see cref="M:Microsoft.Web.WebView2.Core.CoreWebView2.PrintToPdfAsync(System.String,Microsoft.Web.WebView2.Core.CoreWebView2PrintSettings)" /> method.
    /// </summary>
    public CoreWebView2PrintSettings CreatePrintSettings()
    {
        try
        {
            return new CoreWebView2PrintSettings(_nativeICoreWebView2Environment6.CreatePrintSettings());
        }
        catch (InvalidCastException ex)
        {
            if (ex.HResult == -2147467262)
            {
                throw new InvalidOperationException("CoreWebView2 members can only be accessed from the UI thread.", ex);
            }
            throw ex;
        }
        catch (COMException ex2)
        {
            if (ex2.HResult == -2147019873)
            {
                throw new InvalidOperationException("CoreWebView2 members cannot be accessed after the WebView2 control is disposed.", ex2);
            }
            throw ex2;
        }
    }
}
