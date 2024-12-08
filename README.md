# Avalonia.WebView
WebView for avalonia

sample usage
```csharp
 var services = new ServiceCollection()
 .AddDesktopWebViewServices(false)
 .AddAvaloniaBlazorWebViewServices(
     new WebViewCreationProperties(),
     config =>
     {
         config.ComponentType = typeof(SampleBlazorWebViewShared.AppWeb);
         config.Selector = "#app";
         config.ResourceAssembly = typeof(SampleBlazorWebViewShared.AppWeb).Assembly;
         config.AppAddress = "0.0.0.0";
     }
 )
 .AddGlobalForServer();

 services.Add(ServiceDescriptor.Singleton(typeof(ILoggerFactory), _loggerFactory));
 services.Add(ServiceDescriptor.Singleton(typeof(ILogger<>), typeof(Logger<>)));

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

 _logger.LogInformation("Setting up BlazorWebView");

 var webView = new BlazorWebView(provider);
 webView.HostPage = @"wwwroot/index.html";
 webView.RootComponents.Add<HeadOutlet>("head::after");
 webView.WebViewCreated += WebView_WebViewCreated;

 Content = webView;
```
        
## Credits

Full credit goes to https://github.com/MicroSugarDeveloperOrg

[Avalonia](https://github.com/AvaloniaUI/Avalonia)

[Maui](https://github.com/dotnet/maui)

[Xamarin.MacIos](https://github.com/xamarin/xamarin-macios)

[Microsoft.WebView2](https://github.com/MicrosoftEdge/WebView2Samples)

[GTKSharp](https://github.com/GtkSharp/GtkSharp)

[WebkitGtkSharp](https://github.com/GtkSharp/GtkSharp)
