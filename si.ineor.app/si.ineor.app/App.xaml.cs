using si.ineor.app.Services;
using si.ineor.app.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace si.ineor.app
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
