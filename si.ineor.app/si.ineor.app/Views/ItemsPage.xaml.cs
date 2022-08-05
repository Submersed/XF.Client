using si.ineor.app.Entities;
using si.ineor.app.Models;
using si.ineor.app.ViewModels;
using si.ineor.app.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace si.ineor.app.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            AddButton.IsEnabled = (Application.Current as App).restService.loggedUser.Role == Role.Admin;

        }
    }
}