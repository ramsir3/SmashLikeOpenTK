using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Input;
using System.Drawing;

namespace SmashClone
{
    public static class Constants
    {
        public static Key MoveLeft = Key.A;
        public static Key MoveRight = Key.D;
        public static Key Jump = Key.W;

        public static Color HurtBoxColor { get { return Color.DarkTurquoise; } }
        public static Color HitBoxColor { get { return Color.Red; } }

        public enum CharacterState
        {
            Idle = 0,
            Walk,
            Jump
        }

        public enum CharacterFacing
        {
            Left = -1,
            Right = 1
        }

        public static int NumStates = 3;

        public static bool IsKeyRegistered(KeyboardState keyState)
        {
            return keyState.IsKeyDown(MoveLeft) ||
                           keyState.IsKeyDown(MoveRight) ||
                           keyState.IsKeyDown(Jump);
        }


    }
}
