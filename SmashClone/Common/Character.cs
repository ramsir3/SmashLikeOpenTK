using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenPlatformFighter.Common.Constants;
using static OpenPlatformFighter.Common.VolatileStates;
using System.Drawing;


namespace OpenPlatformFighter.Common
{
    public abstract class Character
    {
		protected class AnimationArray
		{
			private readonly CAnimation[] animationArray;
			
			public AnimationArray()
			{
				animationArray = new CAnimation[NumAnimations];
			}
			
			public void Set(AnimationStates state, CAnimation animation)
			{
				animationArray[(int)state] = animation;
			}
			
			public CAnimation this[AnimationStates state]
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
			
			public static AnimationArray operator+ (AnimationArray a, CAnimation b) {
				a.Set(b.State, b);
				return a;
			}
		}

        #region Character attr.
        protected AnimationArray _animations;

        protected float _walkSpeed;
        protected float _fallSpeed;
        protected float _jumpHeight;

        public float WalkSpeed { get => _walkSpeed; }
        public float FallSpeed { get => _fallSpeed; }
        public float JumpHeight { get => _jumpHeight; }

        public Color _color;
        #endregion

        public Character()
        {
            _animations = new AnimationArray();
        }

        public virtual void Draw(AnimationStates animation, Vector2 pos, State volatilestate)
        {
            //Console.WriteLine(State);
            _animations[animation].Draw(pos, volatilestate == ActiveInput, _color);
        }
    }

}
