using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xaminals.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        public MainViewModel() {
            items = new ObservableCollection<string>();        
        }
        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [ICommand]
        void Add()
        {
            if(string.IsNullOrEmpty(text))
                return; 
            items.Add(text);
            text = string.Empty;
        }
      
    }
}
