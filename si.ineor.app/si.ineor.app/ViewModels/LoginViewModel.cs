using si.ineor.app.Models.Users;
using si.ineor.app.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace si.ineor.app.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public AuthenticateRequest authenticateRequest { get; set; }

        public LoginViewModel()
        {
            authenticateRequest = new AuthenticateRequest();
            LoginCommand = new Command(OnLoginClicked); 
        }

        public async void OnLoginClicked(object obj = null)
        {
            if(obj is AuthenticateRequest)
            {
                authenticateRequest = obj as AuthenticateRequest;
            }
            if(authenticateRequest.Password != "" && authenticateRequest.Username != "")
            {
                var result = await (Application.Current as App).restService.Login(authenticateRequest);
                (Application.Current as App).authenticateResponse = result;

                if (result == null)
                {
                    await (App.Current as Application).MainPage.DisplayAlert("Error", "User non existed, or incorrect credentials", "ok");
                }
                else
                {
                    (App.Current as Application).MainPage = new AppShell();
                }
                //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

        }
    }
}
