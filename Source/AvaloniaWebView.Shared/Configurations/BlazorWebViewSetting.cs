﻿using System.Reflection;

namespace AvaloniaBlazorWebView.Shared.Configurations;
public class BlazorWebViewSetting
{
    public string WWWRoot { get; set; } = "wwwroot";
    public string AppAddress { get; set; } = "localhost";
    public string StartAddress { get; set; } = "/";

    public Type? ComponentType { get; set; }
    public string? Selector { get; set; }

    public Assembly? ResourceAssembly { get; set; }
}
