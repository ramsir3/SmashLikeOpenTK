using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmashClone.Constants;

namespace SmashClone
{
    public abstract class Character
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
        protected Vector2 _vel;
        protected Vector2 _acc;
        public CharacterState State;
        public CharacterFacing Facing;
        public bool Grounded;
        public bool Interruptable;
        public bool ActiveInput;
        protected AnimationArray _animations;
        #endregion

        #region Character attr.
        protected float _walkSpeed;
        protected float _fallSpeed;
        protected float _jumpHeight;

        public Vector2 Pos { get => _pos; }
        public Vector2 Vel { get => _vel; }
        public Vector2 Acc { get => _acc; }
        public float WalkSpeed { get => _walkSpeed; }
        public float FallSpeed { get => _fallSpeed; }
        public float JumpHeight { get => _jumpHeight; }
        #endregion



        protected Character()
        {
            _init(new Vector2(0f, 0f));
        }

        protected Character(Vector2 pos)
        {
            _init(pos);

        }

        void _init(Vector2 pos)
        {
            _animations = new AnimationArray();
            _pos = pos;
            _vel = new Vector2(0, 0);
            _acc = new Vector2(0, 0);

            Grounded = true;
            State = CharacterState.Idle;
        }

        public virtual void Draw()
        {
            //Console.WriteLine(State);
            _animations[State].Draw(Pos, ActiveInput);
        }

        public virtual void Move(Vector2 mv)
        {
            _pos += mv;
        }

        public virtual void AddAcc(Vector2 acc)
        {
            _acc += acc;
        }

        public virtual void AddVel(Vector2 vel)
        {
            _vel += vel;
        }

        public virtual void SetGrounded()
        {
            if (_acc.Y < 0)
            {
                _acc.Y = 0;
            }
            if (_vel.Y < 0)
            {
                _vel.Y = 0;
            }
            Grounded = true;
        }

        public virtual void Physics()
        {
            _vel += _acc;
            _pos += _vel;
            _acc.Y = 0;
            _acc.X = 0;
        }

        public virtual void ApplyStageFriction(float f)
        {
            if (_vel.X < 0)
            {
                _vel.X += f;
                if (_vel.X > 0)
                {
                    _vel.X = 0;
                }            
            }
            else if (_vel.X > 0)
            {
                _vel.X -= f;
                if (_vel.X < 0)
                {
                    _vel.X = 0;
                }
            }
        }
    }

}
