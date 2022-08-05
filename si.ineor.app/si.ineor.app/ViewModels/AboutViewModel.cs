using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace si.ineor.app.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync($"{(Application.Current as App).restService.GetUri()}/swagger/index.html"));
        }

        public ICommand OpenWebCommand { get; }
    }
}