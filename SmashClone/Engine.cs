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
                    Vector2 mv = new Vector2(c.WalkSpeed, 0);
                    if (c.Facing == CharacterFacing.Left)
                    {
                        c.Move(-1*mv);
                    }
                    else
                    {
                        c.Move(mv);
                    }
                    break;
                default:
                    break;
            }

        }

        void CalcState(Character c, KeyboardState keyState, KeyboardState lastKeyState)
        {
            if (keyState.IsKeyDown(MoveLeft))
            {
                c.Facing = CharacterFacing.Left;
                c.State = CharacterState.Walk;
            }
            if (keyState.IsKeyDown(MoveRight))
            {
                c.Facing = CharacterFacing.Right;
                c.State = CharacterState.Walk;
            }
            if (!c.Grounded && !IsKeyRegistered(keyState)) {
                c.State = CharacterState.Idle;
            }
        }

    }


}
