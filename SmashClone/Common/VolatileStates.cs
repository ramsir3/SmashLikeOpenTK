using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashClone.Common
{
    class VolatileStates
    {
        /* Volatile States
         * 0b0_0000_0000_0000_0000;
         * public bool Grounded;
         * public bool ActiveInput;
         * public bool Interruptable;
         * public bool Helpless;
         * public bool Facing == Left;
         */
        public const uint
            Grounded = 0b0_0000_0000_0000_0001,
            ActiveInput = 0b0_0000_0000_0000_0010,
            Interruptable = 0b0_0000_0000_0000_0100,
            Helpless = 0b0_0000_0000_0000_1000,
            //BInput = 0b0_0000_0000_0001_0000,
            //AInput = 0b0_0000_0000_0010_0000,
            //JInput = 0b0_0000_0000_0100_0000,
            //SInput = 0b0_0000_0000_1000_0000,
            //CRInput = 0b0_0000_0001_0000_0000,
            //CLInput = 0b0_0000_0010_0000_0000,
            //CDInput = 0b0_0000_0100_0000_0000,
            //CUInput = 0b0_0000_1000_0000_0000,
            //TRInput = 0b0_0001_0000_0000_0000,
            //TLInput = 0b0_0010_0000_0000_0000,
            //TDInput = 0b0_0100_0000_0000_0000,
            FacingLeft = 0b0_1000_0000_0000_0000;
    }
}
