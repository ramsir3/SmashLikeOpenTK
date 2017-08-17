using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashClone
{
    class Character
    {
        public enum CharacterState
        {
            Walk = 0,
            Idle = 1,
            Jump = 2
        }

        protected static int numStates = Enum.GetValues(typeof(CharacterState)).Length;

        protected class CharacterAnimation
        {
            Character parent;

            //TDOD implement the actual animation construtor
            public CharacterAnimation(Character parent)
            {
                this.parent = parent;
            }

            //TODO implement draw func
            public void Draw()
            {
                throw new NotImplementedException();
            }

        }

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
