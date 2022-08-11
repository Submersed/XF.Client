using si.ineor.app.Entities;
using si.ineor.app.Models;
using si.ineor.app.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace si.ineor.app.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Movie _selectedItem;

        public string searchText { get; set; }
        public bool IsAdmin { get 
            { 
                return (Application.Current as App).restService.loggedUser.Role == Role.Admin; } }

        public ObservableCollection<Movie> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Movie> ItemTapped { get; }
        public Command<Movie> ItemDelete { get; }

        public ItemsViewModel()
        {
            Title = "Browse Movies";
            Items = new ObservableCollection<Movie>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Movie>(OnItemSelected);
            ItemDelete = new Command<Movie>(OnItemDelete);


            AddItemCommand = new Command(OnAddItem);
        }

        private async void OnItemDelete(Movie obj)
        {
            try
            {
                if ((Application.Current as App).restService.loggedUser.Role == Role.Admin)
                {

                    var result = await (Application.Current as App).restService.DeleteMovie(obj.Id);
                    if (result)
                    {
                        await (Application.Current as App).MainPage.DisplayAlert("Movie deleted", "New movie has been deleted", "Ok").ContinueWith(async x =>
                        {
                            await ExecuteLoadItemsCommand();
                        });


                    }
                    else
                    {
                        await (Application.Current as App).MainPage.DisplayAlert("Movie deleted ERROR", "Movie has NOT been deleted", "Ok").ContinueWith(async x => {
                            await ExecuteLoadItemsCommand();
                        });
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }    


        }

        async Task ExecuteLoadItemsCommand()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                Items.Clear();
                try
                {

                    var items = await (Application.Current as App).restService.GetMovies(searchText);
                    foreach (var item in items)
                    {
                        Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = false;
                }
            }
           
        }

        public void OnAppearing()
        {
            
            SelectedItem = null;

        }

        public Movie SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Movie item)
        {
            if (item == null)
                return;


            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}