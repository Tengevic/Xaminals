using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xaminals.Views;

namespace Xaminals.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity connectivity;

        public MainViewModel(IConnectivity connectivity) {
            items = new ObservableCollection<string>();   
            this.connectivity = connectivity;
        }
        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [ICommand]
        async Task Add()
        {
            if(string.IsNullOrEmpty(text))
                return; 

            if(connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("uh oh!", "No internet", "OK");
                return;
            }
            items.Add(text);
            text = string.Empty;
        }
        [ICommand]
        void Remove(string s) 
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
        }
        [ICommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{ nameof(DetailPage)}?Text={s}");
        }
    }
}
