using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashClone.Common
{
    /* Input States
     * 0b0_0000_0000_0000_0000;
     *    t1234c1234_sjab_udlr
     *     ^    ^
     * taunts  cstick          */

    public struct State
    {
        public uint Data { get; set; }

        public static bool operator ==(State a, uint b)
        {
            return (a.Data & b) == b;
        }

        public static bool operator !=(State a, uint b)
        {
            return (a.Data & b) != b;
        }

        public static State operator +(State a, uint b)
        {
            a.Data = a.Data | b;
            return a;
        }

        public static State operator -(State a, uint b)
        {
            a.Data = a.Data & (~b);
            return a;
        }

        public override string ToString()
        {
            return Convert.ToString(Data, 2).PadLeft(16, '0');
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is State))
            {
                return false;
            }

            var state = (State)obj;
            return Data == state.Data;
        }
    }

}
