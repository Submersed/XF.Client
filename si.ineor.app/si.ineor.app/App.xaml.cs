using si.ineor.app.Data;
using si.ineor.app.Models;
using si.ineor.app.Models.Users;
using si.ineor.app.Services;
using si.ineor.app.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace si.ineor.app
{
    public partial class App : Application
    {
        public RestService restService = new RestService();
        public AuthenticateResponse authenticateResponse { get; set; }


        public App()
        {
            InitializeComponent();
            Language.SetLanguage(Language.GetCurrentLanguage());

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
