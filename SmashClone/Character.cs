using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashClone
{
    public class Character
    {
        public enum CharacterState
        {
            Idle = 0,
            Walk = 1,
            Jump = 2
        }

        protected static int numStates = Enum.GetValues(typeof(CharacterState)).Length;



        protected class AnimationArray
        {
            private CharacterAnimation[] animationArray;

            public AnimationArray()
            {
                animationArray = new CharacterAnimation[numStates];
            }

            public void Set(CharacterState state, CharacterAnimation animation)
            {
                animationArray[(int)state] = animation;
            }

            public CharacterAnimation Get(CharacterState state)
            {
                return animationArray[(int)state];
            }

            public static AnimationArray operator+ (AnimationArray a, CharacterAnimation b) {
                a.Set(b.State, b);
                return a;
            }
        }

        protected Vector2 pos;
        protected CharacterState state;
        protected AnimationArray animations;

        public Character()
        {
            pos = new Vector2(0, 0);
            state = CharacterState.Idle;

            animations = new AnimationArray();
            //animations.Set(CharacterState.Idle, new CharacterAnimation(this, ).)

        }

        public void SetState(CharacterState state)
        {
            this.state = state;
        }

        public void Draw()
        {
            animations.Get(state).Draw();
        }


    }

}
