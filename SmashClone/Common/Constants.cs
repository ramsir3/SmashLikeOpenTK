using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace OpenPlatformFighter.Common
{
    public static class Constants
    {
        public const int GameHeight = 480;
        public const int GameWidth = 640;

        public static bool UseVBOs = false;
        public static readonly PrimitiveType BoxPrimitiveType = PrimitiveType.Quads;
        public static float CircleEdgeLen = 0.001f;

        public static readonly Color HurtBoxColor = Color.DarkTurquoise;
        public static readonly Color HitBoxColor = Color.Red;

        public const int NumAnimations = 3;
        public enum AnimationStates
        {
            Idle = 0,
            Walk,
            Jump
        }
     }
}
