using Avalonia.WebView.Linux;
using Linux.WebView.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.Linux;

public static class AppBuilderExtensions
{

    public static IServiceCollection AddLinuxWebViewServies(this IServiceCollection services, bool isWslDevelop)
    {
        //GtkApi.SetAllowedBackends("x11");
        //Environment.SetEnvironmentVariable("WAYLAND_DISPLAY", "/proc/fake-display-to-prevent-wayland-initialization-by-gtk3");

        return services
            .AddSingleton<ILinuxApplication>((provider) => LinuxApplicationBuilder.Build(isWslDevelop))
            .AddSingleton<IViewHandlerProvider, ViewHandlerProvider>()
            .AddSingleton<IPlatformBlazorWebViewProvider, BlazorWebViewHandlerProvider>();
    }
}
