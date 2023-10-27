using Toolkit.Shared;

namespace AvaloniaBlazorWebView;

partial class BlazorWebView
{
    void CheckDisposed()
    {
        if (_isDisposed)
            throw new ObjectDisposedException(GetType().Name);
    }

    async Task<bool> CreateWebViewManager()
    {
        Console.WriteLine($">>> Creating Web View Manager");

        CheckDisposed();

        if (AvaloniaWebViewManager is not null)
            return true;

        if (string.IsNullOrEmpty(HostPage))
            return false;

        if (RootComponents.Count <= 0)
            return false;

        string contentRootDirFullPath;
        string hostPageRelativePath;
        string contentRootDir;

        if (OperatingSystemEx.IsDesktop())
        {
            var appRootDir = AppContext.BaseDirectory;
            var hostPageFullPath = Path.GetFullPath(Path.Combine(appRootDir, HostPage));
            contentRootDirFullPath = Path.GetDirectoryName(hostPageFullPath)!;
            hostPageRelativePath = Path.GetRelativePath(contentRootDirFullPath, hostPageFullPath);
            contentRootDir = Path.GetRelativePath(appRootDir, contentRootDirFullPath);
        }
        else
        {
            contentRootDirFullPath = Path.GetDirectoryName(HostPage) ?? string.Empty;
            hostPageRelativePath = Path.GetRelativePath(contentRootDirFullPath, HostPage!);
            contentRootDir = contentRootDirFullPath;
        }

        //IFileProvider fileProvider;
        //if (_setting.IsAvaloniaResource)
        //    fileProvider = new AvaloniaResourceFileProvider(_setting.ResourceAssembly!, contentRootDir);
        //else
        var fileProvider = PlatformBlazorWebViewProvider.CreateFileProvider(BlazorWebViewProperties.ResourceAssembly, contentRootDirFullPath);
        var webViewManager = new AvaloniaWebViewManager(this, Services, Dispatcher, AppScheme, AppHostAddress, HostUri, fileProvider, JSComponents, contentRootDirFullPath, hostPageRelativePath);
        //StaticContentHotReloadManager.AttachToWebViewManagerIfEnabled(webviewManager);

        var viewHandler = ViewHandlerProvider.CreatePlatformWebViewHandler(this, this, webViewManager, config =>
        {
            config.AreDevToolEnabled = CreationProperties.AreDevToolEnabled;
            config.AreDefaultContextMenusEnabled = CreationProperties.AreDefaultContextMenusEnabled;
            config.IsStatusBarEnabled = CreationProperties.IsStatusBarEnabled;
            config.BrowserExecutableFolder = CreationProperties.BrowserExecutableFolder;
            config.UserDataFolder = CreationProperties.UserDataFolder;
            config.Language = CreationProperties.Language;
            config.AdditionalBrowserArguments = CreationProperties.AdditionalBrowserArguments;
            config.ProfileName = CreationProperties.ProfileName;
            config.IsInPrivateModeEnabled = CreationProperties.IsInPrivateModeEnabled;
            config.DefaultWebViewBackgroundColor = CreationProperties.DefaultWebViewBackgroundColor;
        });

        if (viewHandler is null)
            throw new ArgumentNullException(nameof(viewHandler));

        var control = viewHandler.AttachableControl;
        if (control is null)
            return false;

        if ((_platformWebView = viewHandler.PlatformWebView)  is null)
            return false;

        Child = control;

        var bRet = await _platformWebView.Initialize();
        if (!bRet)
            return false;
        foreach (var rootComponent in RootComponents)
            await rootComponent.AddToWebViewManagerAsync(webViewManager);

        _avaloniaWebViewManager = webViewManager;
        return true;
    }

    ValueTask IAsyncDisposable.DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }
}
