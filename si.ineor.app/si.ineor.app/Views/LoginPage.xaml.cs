using Newtonsoft.Json;
using si.ineor.app.Models.Users;
using si.ineor.app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using si.ineor.app.Models;

namespace si.ineor.app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //this.BindingContext = new LoginViewModel();
        }

        private async void Admin_Clicked(object sender, EventArgs e)
        {
            (this.BindingContext as LoginViewModel).OnLoginClicked(new AuthenticateRequest() { Username = "admin",Password="admin"});
        }
        private void User_Clicked(object sender, EventArgs e)
        {
            (this.BindingContext as LoginViewModel).OnLoginClicked(new AuthenticateRequest() { Username = "user", Password = "user" });

        }

        private void Slo_Clicked(object sender, EventArgs e)
        {
            Language.SetLanguage(new Language() { FullName = "Slovenščina", Culture = "sl" });
            (Application.Current as App).MainPage = new LoginPage();

        }
        private void En_Clicked(object sender, EventArgs e)
        {
            Language.SetLanguage(new Language() { FullName = "English", Culture = "en" });
            (Application.Current as App).MainPage = new LoginPage();

        }
    }
}