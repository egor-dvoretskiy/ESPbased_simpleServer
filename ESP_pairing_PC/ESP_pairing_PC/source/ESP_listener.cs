using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ESP_pairing_PC.source
{
    static class ESP_listener
    {
        private static UdpClient sck;
        private static readonly IPAddress IP_LOCAL = IPAddress.Parse("192.168.1.66");
        private static readonly int UPORT_LOCAL = 25066;

        public static void Entry()
        {
            sck = new UdpClient(UPORT_LOCAL);
            sck.BeginReceive(new AsyncCallback(OnReceive), sck);
        }

        private static void OnReceive(IAsyncResult res)
        {
            sck = res.AsyncState as UdpClient;

            IPEndPoint source = new IPEndPoint(IP_LOCAL, UPORT_LOCAL);
            byte[] message = sck.EndReceive(res, ref source);
            //unbox SOURCE
        }

        //commit 1.
        //commit 2.
        //commit 3.
    }
}
