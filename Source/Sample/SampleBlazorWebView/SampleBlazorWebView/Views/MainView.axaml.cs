using Avalonia.Controls;
using Avalonia.WebView.Desktop;
using Avalonia.WebView.Desktop.Extensions.Services;
using AvaloniaBlazorWebView;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using WebViewCore.Configurations;

namespace SampleBlazorWebView.Views;
public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

        var services = new ServiceCollection()
        .AddDesktopWebViewServices(false)
        .AddAvaloniaBlazorWebViewServices(
            new WebViewCreationProperties(),
            config =>
            {
                config.ComponentType = typeof(SampleBlazorWebViewShared.AppWeb);
                config.Selector = "#app";
                config.ResourceAssembly = typeof(SampleBlazorWebViewShared.AppWeb).Assembly;
                config.AppAddress = "0.0.0.0"; // unbound ip is much faster as it will bypass dns
            }
        )
        .AddGlobalForServer();

        services
        .AddMasaBlazor(builder =>
        {
            builder.ConfigureTheme(theme =>
            {
                theme.Themes.Light.Primary = "#4318FF";
                theme.Themes.Light.Accent = "#4318FF";
            });
        }).AddI18nForServer("wwwroot/i18n");

        var provider = services.BuildServiceProvider();

        var webView = new BlazorWebView(provider);
        webView.HostPage = @"wwwroot/index.html";
        webView.RootComponents.Add<HeadOutlet>("head::after");
        webView.WebViewCreated += WebView_WebViewCreated;

        Content = webView;
    }

    private void WebView_WebViewCreated(object? sender, WebViewCore.Events.WebViewCreatedEventArgs e)
    {

    }
}