using Avalonia.Controls;
using Avalonia.Threading;
using System.Diagnostics;
using System.Threading;
namespace Semux.Views;

public partial class MainView : UserControl
{
    CancellationTokenSource? Token = null;
    public MainView()
    {
        InitializeComponent();
        this.Loaded += MainView_Loaded;

    }
    ~MainView()
    {
        Token?.Dispose();
    }
    private void MainView_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Token = new SemuxBlazorShared.DLLImportLib().Init(loaded: (host) =>
        {

            Dispatcher.UIThread.Invoke(() =>
            {
                webview.Url = new System.Uri(host);
                webview.Tag = webview.Url;
                webview.Reload();

            });
        });




    }

    private void WebView_NavigationStarting(object? sender, WebViewCore.Events.WebViewUrlLoadingEventArg e)
    {
        //if (!e.Url.OriginalString.StartsWith("https://localhost"))
        //{



        //}

        Debug.WriteLine(e.Url);
        webview.IsVisible = true;
        _label_loaded.IsVisible = false;
    }
}
