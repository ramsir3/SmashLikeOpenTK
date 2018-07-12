using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;
using System.Drawing;

namespace SmashClone.Common
{
    public static class Constants
    {
        public static int GameHeight = 480;
        public static int GameWidth = 640;

        public static Color HurtBoxColor { get { return Color.DarkTurquoise; } }
        public static Color HitBoxColor { get { return Color.Red; } }

        public static int NumAnimations = 3;
        public enum AnimationState
        {
            Idle = 0,
            Walk,
            Jump
        }
     }
}
