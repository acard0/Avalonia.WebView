using Avalonia.Controls;
using Microsoft.Extensions.Logging;

namespace SampleBlazorWebView.Views;
public partial class MainWindow : Window
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly ILogger<MainWindow> _logger;

    public MainWindow(ILoggerFactory loggerFactory)
    {
        InitializeComponent();
        _loggerFactory = loggerFactory;
        _logger = _loggerFactory.CreateLogger<MainWindow>();

        var main = new MainView(loggerFactory);
        this.Content = main;

        _logger.LogInformation("MainWindow created");
    }
}