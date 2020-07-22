using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test_InteractiveWebPlayer.RtiPart;

namespace Test_InteractiveWebPlayer
{
    public class CommonData
    {
        public static RingArrayBuffer<int> RtiReceiveData = new RingArrayBuffer<int>(1000);
    }
}
