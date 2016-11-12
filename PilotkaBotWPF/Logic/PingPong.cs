using PilotkaBotWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static PilotkaBotWPF.Logic.API;

namespace Logic
{
    public static class PingPong
    {
        

        public static void DoPingPong()
        {
            Info.GetUrl(csgo_PingPong + keyMarket);
        }

    }
}
