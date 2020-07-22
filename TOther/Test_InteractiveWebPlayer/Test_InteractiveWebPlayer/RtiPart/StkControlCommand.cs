using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hla.rti;

namespace Test_InteractiveWebPlayer.RtiPart
{
    public class StkControlCommand : FederateInteractionBase
    {
        public int CommandId { get; set; }
        public StkControlCommand(RTIambassador rtia) : base(rtia) { }
    }
}
