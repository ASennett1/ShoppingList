using Microsoft.Maui.Controls;
using ShoppingList.Views;
using NavigationPage = Microsoft.Maui.Controls.NavigationPage;
using Newtonsoft.Json;

namespace ShoppingList;

public partial class App : Application
{
    public static string SessionKey = "";
    
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
}