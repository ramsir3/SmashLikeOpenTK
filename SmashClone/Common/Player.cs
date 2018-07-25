using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenPlatformFighter.Common.Constants;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenPlatformFighter.Common
{
    public class Player
    {
        protected Vector2 _pos;
        protected Vector2 _vel;
        protected Vector2 _acc;

        public Character Character;
        public Controls Controls;
        public State InputState;
        public State LastInputState;
        public State VolatileState;
        public AnimationStates AnimationState;

        public Vector2 Pos { get => _pos; }
        public Vector2 Vel { get => _vel; }
        public Vector2 Acc { get => _acc; }

        public Player(Character character, Controls controls, Vector2 pos)
        {
            Character = character;
            Controls = controls;

            _pos = pos;
            _vel = new Vector2(0, 0);
            _acc = new Vector2(0, 0);

            AnimationState = AnimationStates.Idle;
        }

        public void Draw()
        {
            //Console.WriteLine(AnimationState);
            Character.Draw(AnimationState, Pos, VolatileState);
        }

        public void SetInputStates(KeyboardState keyState, KeyboardState lastKeyState)
        {
            InputState = Controls.GetControl(keyState);
            LastInputState = Controls.GetControl(lastKeyState);
        }

        public void Move(Vector2 mv)
        {
            _pos += mv;
        }

        public void AddAcc(Vector2 acc)
        {
            _acc += acc;
        }

        public void AddVel(Vector2 vel)
        {
            _vel += vel;
        }

        public void SetGrounded()
        {
            if (_acc.Y < 0)
            {
                _acc.Y = 0;
            }
            if (_vel.Y < 0)
            {
                _vel.Y = 0;
            }
            VolatileState += VolatileStates.Grounded;
        }

        public void Physics()
        {
            _vel += _acc;
            _pos += _vel;
            _acc.Y = 0;
            _acc.X = 0;
        }

        public void ApplyStageFriction(float f)
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
