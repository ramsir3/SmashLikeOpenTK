using System;
using OpenTK;
using OpenTK.Input;
using static SmashClone.Constants;
namespace SmashClone
{
    public class Engine
    {
        Character[] _characters;
        Stage _stage;

        static Vector2 ux = new Vector2(1f, 0);
        static Vector2 uy = new Vector2(0, 1f);

        public Engine(Character[] characters, Stage stage)
        {
            _characters = characters;
            _stage = stage;
        }

        public void Play(KeyboardState keyState, KeyboardState lastKeyState)
        {

            Character c = _characters[0];
            CalcState(c, keyState, lastKeyState);
            PlayCharacter(c);
            DoPhysics(c);

        }

        public void Draw()
        {
            Character c = _characters[0];
            c.Draw();
        }

        void PlayCharacter(Character c)
        {
            switch (c.State)
            {
                case CharacterState.Idle:
                    break;
                case CharacterState.Walk:
                    if (c.Facing == CharacterFacing.Left)
                    {
                        c.AddAcc(-c.WalkSpeed * ux);
                    }
                    else
                    {
                        c.AddAcc(c.WalkSpeed * ux);
                    }
                    break;
                case CharacterState.Jump:
                    c.AddAcc(uy * c.JumpHeight);
                    break;
                default:
                    break;
            }
        }

        void CalcState(Character c, KeyboardState keyState, KeyboardState lastKeyState)
        {
            if (c.Grounded && keyState.IsKeyDown(MoveLeft))
            {
                c.ActiveInput = true;
                c.Facing = CharacterFacing.Left;
                c.State = CharacterState.Walk;
            } else
            if (c.Grounded && keyState.IsKeyDown(MoveRight))
            {
                c.ActiveInput = true;
                c.Facing = CharacterFacing.Right;
                c.State = CharacterState.Walk;
            } else
            if (c.Grounded && keyState.IsKeyDown(Jump) && lastKeyState.IsKeyUp(Jump))
            {
                c.ActiveInput = true;
                c.State = CharacterState.Jump;
            } else
            {
                c.ActiveInput = false;
                c.State = CharacterState.Idle;
            }
            //Console.WriteLine(c.State);
        }

        void DoPhysics(Character c)
        {
            c.Grounded = !StageCollision(c);
            if (!c.Grounded)
            {
                c.AddVel(uy * -c.FallSpeed);

            }
            else
            {
                c.ApplyStageFriction(_stage.Friction);
                c.SetGrounded();
            }
            c.Physics();

        }

        bool Collision(IBox box1, IBox box2)
        {
            Vector2 dp = box1.Center - box2.Center;
            float radii = box1.Radius + box2.Radius;
            if ((dp.X * dp.X) + (dp.Y * dp.Y) < radii * radii)
            {
                return true;
            }
            return false;
        }

        bool StageCollision(Character c)
        {
            return c.Pos.Y >= _stage.Ground;
        }


    }


}
