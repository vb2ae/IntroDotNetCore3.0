using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWpfDemo.Models
{


    public class LaunchData
    {
        public string Title { get; set; }
        public string SmallImage { get; set; }
        public string MediumImage { get; set; }
        public string LargeImage { get; set; }
        public string StartOfLaunchWindow { get; set; }
        public string EndOfLaunchWindow { get; set; }
        public string LaunchLocation { get; set; }
        public string Description { get; set; }
        public List<LinkPair> Links { get; set; }
        public List<string> Missions { get; set; }
    }

}
