using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CoreWpfDemo.Models;

namespace CoreWpfDemo.Services
{
    public interface ILaunchDataService
    {
        Task<ObservableCollection<LaunchData>> GetUpcomingLaunches();
    }
}