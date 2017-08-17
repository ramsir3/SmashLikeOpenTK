using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;
using System.Drawing;

namespace SmashClone
{
    static class Constants
    {
        public static Key MoveLeft { get { return Key.A; } }
        public static Key MoveRight { get { return Key.D; } }
        public static Key Jump { get { return Key.W; } }

        public static Color HurtBoxColor { get { return Color.DarkTurquoise; } }
        public static Color HitBoxColor { get { return Color.Red; } }

    }
}
