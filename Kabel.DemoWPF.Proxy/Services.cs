using Kabel.DemoWPF.Proxy.NorthWindServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kabel.DemoWPF.Proxy
{
    public static class Services
    {
        static Services()
        {
            Client = new ServicesClient();
            Client.ChannelFactory.Faulted += ChannelFactoryFaulted;
        }

        static void ChannelFactoryFaulted(object sender, EventArgs e)
        {
            Client.ChannelFactory.Faulted -= ChannelFactoryFaulted;
            Client = new ServicesClient();
            Client.ChannelFactory.Faulted += ChannelFactoryFaulted;
        }
        public static ServicesClient Client { get; private set; }

    }
}
