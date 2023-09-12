using Microsoft.AspNetCore.Components.Web;

namespace AvaloniaBlazorWebView.Shared.Configurations;
public class JsComponentConfigration : IJSComponentConfiguration
{
    public JsComponentConfigration(JSComponentConfigurationStore jSComponentConfigurationStore)
    {
        JSComponents = jSComponentConfigurationStore;
    }

    public JSComponentConfigurationStore JSComponents { get; init; }
}
