using NETWORKLIST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppAssessment
{
    public class InternetConnectionChecker
    {
        private readonly INetworkListManager _networkListManager;

        public InternetConnectionChecker()
        {
            _networkListManager = new NetworkListManager();
        }

        public bool IsConnected()
        {
            return _networkListManager.IsConnectedToInternet;
        }
    }
}
