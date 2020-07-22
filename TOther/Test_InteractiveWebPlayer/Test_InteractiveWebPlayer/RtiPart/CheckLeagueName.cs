using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using hla.rti;
using hla.rti.jlc;

namespace Test_InteractiveWebPlayer.RtiPart
{
    public class CheckLeagueName : FederateInteractionBase
    {
        public string MyFederationName { get; set; }
        public int GrandControlCommandId { get; set; }
        public bool IsAllLeagueExit { get; set; }
        public CheckLeagueName(RTIambassador rtia) : base(rtia) { }
    }
}
