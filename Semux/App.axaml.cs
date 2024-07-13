using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaBlazorWebView;
using Semux.ViewModels;
using Semux.Views;
namespace Semux;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
    public override void RegisterServices()
    {
        base.RegisterServices();


        // if you use BlazorWebView, please setting for blazor 
        AvaloniaBlazorWebViewBuilder.Initialize(default, setting =>
        {
            //this is setting for blazor 
            setting.ComponentType = typeof(App);
            setting.Selector = "#app";

            //because avalonia support the html css and js for resource ,so you must set the ResourceAssembly 
            //setting.IsAvaloniaResource = true;
            setting.ResourceAssembly = typeof(App).Assembly;
        }, inject =>
        {
            //you can inject the resource in this
            //inject.AddSingleton<WeatherForecastService>();
        });
    }
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
