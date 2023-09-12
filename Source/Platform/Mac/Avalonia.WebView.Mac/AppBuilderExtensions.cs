﻿using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.WebView.Mac;

public static class AppBuilderExtensions
{
    public static IServiceCollection AddOSXWebViewServices(this IServiceCollection services)
    {
        return services.AddSingleton<IViewHandlerProvider, ViewHandlerProvider>()
            .AddSingleton<IPlatformBlazorWebViewProvider, BlazorWebViewHandlerProvider>();
    }
}


//新版本的macOS及iOS都强制必须使用https网页访问，如果需要支持老的http网页，还需要在Info.plist中增加一行：App Transport Security Settings，类型为字典项，其中增加一项：Allow Arbitrary Loads，值为YES。
//完成以上4项，网页已经可以访问了。