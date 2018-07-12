using System;
using OpenTK;
using OpenTK.Input;
using SmashClone.Common;
using static SmashClone.Common.Constants;


namespace SmashClone.Driver
{
    public class Engine
    {
        Player[] _players;
        Stage _stage;

        static Vector2 ux = new Vector2(1f, 0);
        static Vector2 uy = new Vector2(0, 1f);

        public Engine(Player[] players, Stage stage)
        {
            _players = players;
            _stage = stage;
        }

        public void Play(KeyboardState keyState, KeyboardState lastKeyState)
        {

            Player p = _players[0];
            State inputState = p.Controls.GetControl(keyState);
            State lastInputState = p.Controls.GetControl(lastKeyState);
            //Console.WriteLine("{0} - {1}", inputState, lastInputState);
            CalcState(p, inputState, lastInputState);
            PlayCharacter(p);
            DoPhysics(p);
            Console.WriteLine(p.AnimationState);
        }

        public void Draw()
        {
            foreach (var c in _players)
            {
                c.Draw();
            }
        }

        void PlayCharacter(Player p)
        {
            switch (p.AnimationState)
            {
                case AnimationState.Idle:
                    break;
                case AnimationState.Walk:
                    if (p.VolatileState == VolatileStates.FacingLeft)
                    {
                        p.AddAcc(-p.Character.WalkSpeed * ux);
                    }
                    else
                    {
                        p.AddAcc(p.Character.WalkSpeed * ux);
                    }
                    break;
                case AnimationState.Jump:
                    p.AddAcc(uy * p.Character.JumpHeight);
                    break;
                default:
                    break;
            }
        }

        void CalcState(Player p, State inputState, State lastInputState)
        {
            if ((p.VolatileState == VolatileStates.Grounded) && (inputState == Inputs.LInput))
            {
                p.VolatileState += VolatileStates.ActiveInput;
                p.VolatileState += VolatileStates.FacingLeft;
                p.AnimationState = AnimationState.Walk;
            }
            else
            if ((p.VolatileState == VolatileStates.Grounded) && (inputState == Inputs.RInput))
            {
                p.VolatileState += VolatileStates.ActiveInput;
                p.VolatileState -= VolatileStates.FacingLeft;
                p.AnimationState = AnimationState.Walk;
            }
            else
            if ((p.VolatileState == VolatileStates.Grounded) && (inputState == Inputs.JInput) && (lastInputState != Inputs.JInput))
            {
                p.VolatileState += VolatileStates.ActiveInput;
                p.AnimationState = AnimationState.Jump;
            }
            else
            {
                p.VolatileState -= VolatileStates.ActiveInput;
                p.AnimationState = AnimationState.Idle;
            }
            //Console.WriteLine(c.State);
        }

        void DoPhysics(Player p)
        {
            if (StageCollision(p))
            {
                p.VolatileState += VolatileStates.Grounded;
            } else
            {
                p.VolatileState -= VolatileStates.Grounded;
            }

            if (p.VolatileState != VolatileStates.Grounded)
            {
                p.AddVel(uy * -p.Character.FallSpeed);
            }
            else
            {
                p.ApplyStageFriction(_stage.Friction);
                p.SetGrounded();
            }
            p.Physics();
        }

        bool Collision(Box box1, Box box2)
        {
            Vector2 dp = box1.Center - box2.Center;
            float radii = box1.Radius + box2.Radius;
            if ((dp.X * dp.X) + (dp.Y * dp.Y) < radii * radii)
            {
                return true;
            }
            return false;
        }

        bool StageCollision(Player p)
        {
            return p.Pos.Y <= _stage.Ground;
        }
    }


}
