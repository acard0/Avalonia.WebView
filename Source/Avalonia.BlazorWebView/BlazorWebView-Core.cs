﻿using AvaloniaBlazorWebView.Common;
using Toolkit.Shared;

namespace AvaloniaBlazorWebView;

partial class BlazorWebView
{
    void CheckDisposed()
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(GetType().Name);
        }
    }

    async Task<bool> CreateWebViewManager()
    {
        _logger.LogInformation("Creating Blazor Web View Manager");

        CheckDisposed();

        if (AvaloniaWebViewManager is not null)
            return true;

        if (string.IsNullOrEmpty(HostPage))
        {
            _logger.LogError("HostPage is empty. Could not create Blazor Web View Manager.");
            return false;
        }

        if (RootComponents.Count <= 0)
        {
            _logger.LogError("RootComponents. Could not create Blazor Web View Manager.");
            return false;
        }

        string contentRootDirFullPath;
        string hostPageRelativePath;
        string contentRootDir;

        if (OperatingSystemEx.IsDesktop())
        {
            var appRootDir = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
            if (string.IsNullOrEmpty(appRootDir)) throw new InvalidOperationException("AppContext.BaseDirectory + Directory.GetCurrentDirectory() returned null/empty string");
            var hostPageFullPath = Path.GetFullPath(Path.Combine(appRootDir, HostPage));
            if (string.IsNullOrEmpty(hostPageFullPath)) throw new InvalidOperationException("Path.GetFullPath(Path.Combine(appRootDir, HostPage)) returned null/empty string");

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

        _logger.LogInformation("Resolved content root {}", contentRootDirFullPath);

        //IFileProvider fileProvider;
        //if (_setting.IsAvaloniaResource)
        //    fileProvider = new AvaloniaResourceFileProvider(_setting.ResourceAssembly!, contentRootDir);
        //else
        var fileProvider = PlatformBlazorWebViewProvider.CreateFileProvider(BlazorWebViewProperties.ResourceAssembly, contentRootDirFullPath);
        var webViewManager = new AvaloniaWebViewManager(this, Services, Dispatcher, AppScheme, AppHostAddress, HostUri, fileProvider, JSComponents, contentRootDirFullPath, hostPageRelativePath);
        StaticContentHotReloadManager.AttachToWebViewManagerIfEnabled(webViewManager);

        var viewHandler = ViewHandlerProvider.CreatePlatformWebViewHandler(Services, this, this, webViewManager, config =>
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
        {
            _logger.LogError("AttachableControl is not set. Could not create Blazor Web View Manager.");
            return false;
        }

        var zoomFactor = ZoomFactor;
        if ((_platformWebView = viewHandler.PlatformWebView)  is null)
        {
            _logger.LogError("PlatformWebView is not set. Could not create Blazor Web View Manager.");
            return false;
        }

        Child = control;

        var bRet = await _platformWebView.Initialize();
        if (!bRet)
        {
            _logger.LogError("Platform Web View is failed to initialize. Could not create Blazor Web View Manager.");
            return false;
        }

        _platformWebView.ZoomFactor = zoomFactor;

        foreach (var rootComponent in RootComponents)
            await rootComponent.AddToWebViewManagerAsync(webViewManager);

        _avaloniaWebViewManager = webViewManager;
        _logger.LogInformation("Platform Web View initilized & Blazor Web View Manager created.");
        return true;
    }

    private void Child_LostFocus(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void Child_GotFocus(object? sender, Avalonia.Input.GotFocusEventArgs e)
    {
        throw new NotImplementedException();
    }
}
