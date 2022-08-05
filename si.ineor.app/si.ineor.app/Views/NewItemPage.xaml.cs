using si.ineor.app.Entities;
using si.ineor.app.Models;
using si.ineor.app.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace si.ineor.app.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Movie Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}