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
                        c.Move(-c.WalkSpeed * ux);
                    }
                    else
                    {
                        c.Move(c.WalkSpeed * ux);
                    }
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
			}
            if (c.Grounded && keyState.IsKeyDown(MoveRight))
            {
                c.ActiveInput = true;
                c.Facing = CharacterFacing.Right;
                c.State = CharacterState.Walk;
            }
            if (c.Grounded && !IsKeyRegistered(keyState)) {

                c.ActiveInput = false;
                c.State = CharacterState.Idle;
            }
        }

    }


}
