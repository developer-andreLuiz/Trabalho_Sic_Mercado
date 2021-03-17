using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace Mercado.Funcoes
{
    public class Internet
    {
        public bool TesteInternet()
        {
            Ping ping = new Ping();

            PingReply pingStatus = ping.Send(IPAddress.Parse("172.217.30.4"));

            if (pingStatus.Status == IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
