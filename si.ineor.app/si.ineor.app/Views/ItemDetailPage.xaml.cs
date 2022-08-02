using si.ineor.app.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace si.ineor.app.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}