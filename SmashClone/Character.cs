using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmashClone.Constants;

namespace SmashClone
{
    public class Character
    {

        protected class AnimationArray
        {
            private CharacterAnimation[] animationArray;

            public AnimationArray()
            {
                animationArray = new CharacterAnimation[NumStates];
            }

            public void Set(CharacterState state, CharacterAnimation animation)
            {
                animationArray[(int)state] = animation;
            }

            public CharacterAnimation this[CharacterState state]
            {
                get
                {
                    return animationArray[(int)state];
                }

                set
                {
                    Set(state, value);
                }
            }

            public static AnimationArray operator+ (AnimationArray a, CharacterAnimation b) {
                a.Set(b.State, b);
                return a;
            }
        }


#region Character state attr.
        protected Vector2 _pos;
        public CharacterState State;
        public CharacterFacing Facing;
        public bool Grounded;
        protected AnimationArray _animations;
        #endregion

#region Character attr.
        public float WalkSpeed;
        public float FallSpeed;
#endregion

        public Character()
        {
            _pos = new Vector2(0, 0);
            State = CharacterState.Idle;

            _animations = new AnimationArray();

        }

        public void Draw()
        {
            Console.WriteLine(State);
            _animations[State].Draw(_pos);
        }

        public void Move(Vector2 mv)
        {
            _pos += mv;
        }
    }

}
