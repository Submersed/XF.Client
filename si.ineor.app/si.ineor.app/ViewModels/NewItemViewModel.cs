using si.ineor.app.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace si.ineor.app.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string title;
        private string description;
        private DateTime releaseDate;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Movie newItem = new Movie()
            {
                Title = title,
                Description = description,
                ReleaseDate = releaseDate
            };

            var added = await (Application.Current as App).restService.AddMovie(newItem);

            if (added != null)
            {
                await (Application.Current as App).MainPage.DisplayAlert("New movie", "New movie has been added", "Ok").ContinueWith(async x =>
                {
                    await Shell.Current.GoToAsync("..");
                });


            }
            else
            {
                await (Application.Current as App).MainPage.DisplayAlert("New movie ERROR", "New movie has NOT been added", "Ok").ContinueWith(async x => {
                    await Shell.Current.GoToAsync("..");
                });
            }
            // This will pop the current page off the navigation stack
        }
    }
}
