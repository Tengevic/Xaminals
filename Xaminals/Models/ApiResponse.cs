using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Xaminals.ViewModels.MainViewModel;

namespace Xaminals.Models
{
    public class ApiResponse
    {
        public string Status { get; set; } = default!;
        public ObservableCollection<DocInfo> Body { get; set; } = default!;
        public ApiResponse(string Status, ObservableCollection<DocInfo> Body)
        {
            this.Status = Status;
            this.Body = Body;
        }
    }
}
