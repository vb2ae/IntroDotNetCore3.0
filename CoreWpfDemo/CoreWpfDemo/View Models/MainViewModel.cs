using CoreWpfDemo.Models;
using CoreWpfDemo.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CoreWpfDemo.View_Models
{
    public class MainViewModel:ViewModelBase
    {
        private ObservableCollection<LaunchData> _launches;

        public ObservableCollection<LaunchData> Launches
        {
            get
            {
                return _launches;
            }
            set
            {
                _launches = value;
                RaisePropertyChanged("Launches");
            }
        }

        public  MainViewModel(ILaunchDataService service)
        {
            Task.Run(async ()=> { Launches = await service.GetUpcomingLaunches(); });
            Task.WaitAll();
        }
    }
}
