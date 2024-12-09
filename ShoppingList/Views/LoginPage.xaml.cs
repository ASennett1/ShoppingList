using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using ShoppingList.Models;

namespace ShoppingList.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        Title = "Login";
    }

    async void Login_OnClicked(object sender, EventArgs e)
    {
        // user - Andy
        // password - aaa
        
        var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtPassword.Text));

        var client = new HttpClient();
        
        var response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"),
            new StringContent(data, Encoding.UTF8, "application/json"));

        var SKey = response.Content.ReadAsStringAsync().Result;

        if (!string.IsNullOrEmpty((SKey)) && SKey.Length < 50 )
        {
            App.SessionKey = SKey;
            Navigation.PopModalAsync();
        }
        else
        {
            await DisplayAlert("Error", "Sorry there was an issue logging in.", "OK");
            return;
        }
    }

    private void CreateAccount_OnClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NewAccountPage());
    }
}