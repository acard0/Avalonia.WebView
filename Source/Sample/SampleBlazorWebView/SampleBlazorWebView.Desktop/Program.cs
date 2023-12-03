using AntDesign.Toolkit;
using Avalonia;
using Avalonia.ReactiveUI;
using System.Runtime.InteropServices;

namespace SampleBlazorWebView.Desktop;

internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        [DllImport("kernel32.dll")]
        static extern void AllocConsole();
        AllocConsole();

        BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI()
            .UseAntDesignToolkit();
}
