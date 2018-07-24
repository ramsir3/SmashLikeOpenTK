using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlatformFighter.Common
{
    public static class Inputs
    {
        /* Input States
         * 0b0_0000_0000_0000_0000;
         *    t1234c1234_sjab_udlr
         *     ^    ^
         * taunts  cstick          */
        public const uint
            NoInput = 0b0_0000_0000_0000_0000,
            RInput = 0b0_0000_0000_0000_0001,
            LInput = 0b0_0000_0000_0000_0010,
            DInput = 0b0_0000_0000_0000_0100,
            UInput = 0b0_0000_0000_0000_1000,
            BInput = 0b0_0000_0000_0001_0000,
            AInput = 0b0_0000_0000_0010_0000,
            JInput = 0b0_0000_0000_0100_0000,
            SInput = 0b0_0000_0000_1000_0000,
            CRInput = 0b0_0000_0001_0000_0000,
            CLInput = 0b0_0000_0010_0000_0000,
            CDInput = 0b0_0000_0100_0000_0000,
            CUInput = 0b0_0000_1000_0000_0000,
            TRInput = 0b0_0001_0000_0000_0000,
            TLInput = 0b0_0010_0000_0000_0000,
            TDInput = 0b0_0100_0000_0000_0000,
            TUInput = 0b0_1000_0000_0000_0000;
    }
}
