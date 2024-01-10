using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppAssessment
{
    public class Root
    {
        public string title { get; set; }
        public string bulletText { get; set; }
        public string description { get; set; }
        public int runningTime { get; set; }
        public string id { get; set; }
        public string artUrl { get; set; }
        public List<string> related { get; set; }
    }

}
