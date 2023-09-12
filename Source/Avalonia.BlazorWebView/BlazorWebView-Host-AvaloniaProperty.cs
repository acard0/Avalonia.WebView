﻿namespace AvaloniaBlazorWebView;

partial class BlazorWebView
{
    static bool LoadHostDependencyObjectsChanged()
    {
        HostPageProperty.Changed.AddClassHandler((Action<BlazorWebView, AvaloniaPropertyChangedEventArgs<string?>>)((s, e) =>
        {
            if (s.PlatformWebView is null)
                return;

            var hostPage = e.NewValue.Value;
            if (string.IsNullOrWhiteSpace(hostPage))
                return;

            var webviewManager = s.AvaloniaWebViewManager;
            //if (webviewManager is null)
               // await s.CreateWebViewManager(s._platformWebView);

            if (webviewManager is not null)
                webviewManager.Navigate(s.StartAddress);
        }));

        return true;
    }

    public static readonly StyledProperty<string?> HostPageProperty =
           AvaloniaProperty.Register<BlazorWebView, string?>(nameof(HostPage));

    public static readonly StyledProperty<BlazorRootComponentsCollection> RootComponentsProperty =
            AvaloniaProperty.Register<BlazorWebView, BlazorRootComponentsCollection>(nameof(RootComponents), defaultValue: new BlazorRootComponentsCollection());


    public string? HostPage
    {
        get => GetValue(HostPageProperty);
        set => SetValue(HostPageProperty, value);
    }

    public BlazorRootComponentsCollection RootComponents => GetValue(RootComponentsProperty);

    private async void RootComponents_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        CheckDisposed();

        if (AvaloniaWebViewManager is null)
        {
            //await CreateWebViewManager(_platformWebView);
            return;
        }

        await Dispatcher.InvokeAsync(async () =>
        {
            var newItems = (e.NewItems ?? Array.Empty<BlazorRootComponent>()).Cast<BlazorRootComponent>();
            var oldItems = (e.OldItems ?? Array.Empty<BlazorRootComponent>()).Cast<BlazorRootComponent>();

            foreach (var item in newItems.Except(oldItems))
                await item.AddToWebViewManagerAsync(AvaloniaWebViewManager);

            foreach (var item in oldItems.Except(newItems))
                await item.RemoveFromWebViewManagerAsync(AvaloniaWebViewManager);
        });
    }



}
