using System;
using OpenTK;
using OpenTK.Input;
using OpenPlatformFighter.Common;
using static OpenPlatformFighter.Common.Constants;


namespace OpenPlatformFighter.Driver
{
    public class Engine
    {
        Player[] _players;
        Stage _stage;

        static readonly Vector2 ux = new Vector2(1f, 0);
        static readonly Vector2 uy = new Vector2(0, 1f);

        public Engine(Player[] players, Stage stage)
        {
            _players = players;
            _stage = stage;
        }

        public void Play(KeyboardState keyState, KeyboardState lastKeyState)
        {
            //Player p = _players[0];
            //p.SetInputStates(keyState, lastKeyState);
            ////Console.WriteLine("{0} - {1}", inputState, lastInputState);
            //CalcState2(p);
            //PlayCharacter(p);
            //DoPhysics(p);

            //p = _players[1];
            //p.SetInputStates(keyState, lastKeyState);
            ////Console.WriteLine("{0} - {1}", inputState, lastInputState);
            //CalcState(p);
            //PlayCharacter(p);
            //DoPhysics(p);

            foreach (Player p in _players)
            {
                p.SetInputStates(keyState, lastKeyState);
                //Console.WriteLine("{0} - {1}", inputState, lastInputState);
                CalcState(p);
                PlayCharacter(p);
                DoPhysics(p);
                //Console.Write(p.AnimationState);
                //Console.Write(" | ");
            }
            //Console.WriteLine(" ");
        }

        public void Draw()
        {
            foreach (var p in _players)
            {
                p.Draw();
            }
        }

        private void PlayCharacter(Player p)
        {
            switch (p.AnimationState)
            {
                case AnimationStates.Idle:
                    break;
                case AnimationStates.Walk:
                    if (p.VolatileState == VolatileStates.FacingLeft)
                    {
                        p.AddAcc(-p.Character.WalkSpeed * ux);
                    }
                    else
                    {
                        p.AddAcc(p.Character.WalkSpeed * ux);
                    }
                    break;
                case AnimationStates.Jump:
                    p.AddAcc(uy * p.Character.JumpHeight);
                    break;
                default:
                    break;
            }
        }

        private void CalcState(Player p)
        {
            if ((p.VolatileState == VolatileStates.Grounded) && (p.InputState == Inputs.LInput))
            {
                p.VolatileState += VolatileStates.ActiveInput;
                p.VolatileState += VolatileStates.FacingLeft;
                p.AnimationState = AnimationStates.Walk;
            }
            else
            if ((p.VolatileState == VolatileStates.Grounded) && (p.InputState == Inputs.RInput))
            {
                p.VolatileState += VolatileStates.ActiveInput;
                p.VolatileState -= VolatileStates.FacingLeft;
                p.AnimationState = AnimationStates.Walk;
            }
            else
            if ((p.VolatileState == VolatileStates.Grounded) && (p.InputState == Inputs.JInput) && (p.LastInputState != Inputs.JInput))
            {
                p.VolatileState += VolatileStates.ActiveInput;
                p.AnimationState = AnimationStates.Jump;
            }
            else
            {
                p.VolatileState -= VolatileStates.ActiveInput;
                p.AnimationState = AnimationStates.Idle;
            }
            //Console.WriteLine(c.State);
        }

        private void CalcState2(Player p)
        {
            p.VolatileState += VolatileStates.ActiveInput;
            p.VolatileState += VolatileStates.FacingLeft;
            p.AnimationState = AnimationStates.Walk;
        }

        private void DoPhysics(Player p)
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

        private bool Collision(Box box1, Box box2)
        {
            Vector2 dp = box1.Center - box2.Center;
            float radii = box1.Radius + box2.Radius;
            if ((dp.X * dp.X) + (dp.Y * dp.Y) < radii * radii)
            {
                return true;
            }
            return false;
        }

        private bool StageCollision(Player p)
        {
            return p.Pos.Y <= _stage.Ground;
        }
    }


}
