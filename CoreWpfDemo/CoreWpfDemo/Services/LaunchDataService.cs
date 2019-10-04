using CoreWpfDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreWpfDemo.Services
{
    public class LaunchDataService : ILaunchDataService
    {
        public async Task<ObservableCollection<LaunchData>> GetUpcomingLaunches()
        {

            ObservableCollection<LaunchData> result = new ObservableCollection<LaunchData>();
            using (HttpClient http = new HttpClient())
            {
                string json = await http.GetStringAsync("http://kentuckerapps.azurewebsites.net/api/spacelaunch");
                var list = System.Text.Json.JsonSerializer.Deserialize<List<LaunchData>>(json);
                foreach(var item in list)
                {
                    result.Add(item);
                }
            }

            return result;
        }

    }
}
