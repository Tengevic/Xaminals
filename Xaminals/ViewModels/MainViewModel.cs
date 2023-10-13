using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xaminals.Models;
using Xaminals.services;

namespace Xaminals.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        public class DocInfo
        {
            public int Id { get; set; }

            public string Name { get; set; }
            public string Speciality { get; set; }
            public string Department { get; set; }
            public string Ext { get; set; }
            public string phone { get; set; }
            public string phone2 { get; set; }
            public string phone3 { get; set; }
            public string phone4 { get; set; }
            public string phone5 { get; set; }
        }
        private readonly IConfiguration _configuration;
        private readonly DocInfoService Service;
        public MainViewModel(IConfiguration Configuration) {
            items = new ObservableCollection<DocInfo>();
            _configuration = Configuration;
            Service = new DocInfoService(_configuration);
        }
        [ObservableProperty]
        ObservableCollection<DocInfo> items;

        [ObservableProperty]
        string text;

        [ICommand]
        async void Add()
        {
            HttpClient client = new HttpClient();

            ObservableCollection<DocInfo> docInfo = new ObservableCollection<DocInfo>();
            var response = await client.GetAsync("https://nbi-intranet-02.ea.aku.edu/DocPhoneInfo/api/DocInfo/" + Text);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                Items = apiResponse.Body;
            }
        }
      
    }
}
