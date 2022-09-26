using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlockchain.Config
{
    public class AppSettings
    {
        public string RpcPort { get; set; }
        public string NodeName { get; set; }
        public List<string> PeerList { get; set; }
    }
}
