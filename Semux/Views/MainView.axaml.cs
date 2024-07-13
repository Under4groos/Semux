using Avalonia.Controls;
namespace Semux.Views;

public partial class MainView : UserControl
{

    public MainView()
    {
        InitializeComponent();
        this.Loaded += MainView_Loaded;
    }

    private void MainView_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {




        //web_view.Url = new System.Uri("underko.ru");
    }
}
