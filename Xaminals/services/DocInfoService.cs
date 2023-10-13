using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xaminals.Models;
using static Xaminals.ViewModels.MainViewModel;

namespace Xaminals.services
{
    public class DocInfoService
    {
        private readonly IConfiguration _configuration;
        public DocInfoService(IConfiguration Configuration) {
            _configuration = Configuration;
        }
        public ObservableCollection<DocInfo> DocList = new ObservableCollection<DocInfo>();
        internal async void Docinfo(string name)
        {
            HttpClient client = new HttpClient();

            ObservableCollection<DocInfo> docInfo = new ObservableCollection<DocInfo>();
            var response =  await client.GetAsync("https://nbi-intranet-02.ea.aku.edu/DocPhoneInfo/api/DocInfo/" + name);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                docInfo = apiResponse.Body;
            }
        }
        internal ObservableCollection<DocInfo> GetList()
        {
            return DocList;
        }
    }
}
