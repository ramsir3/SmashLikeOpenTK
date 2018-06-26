using System;
using SmashClone;
using OpenTK;
using static SmashClone.Constants;

namespace DefaultCharacter
{
    public class Character : SmashClone.Character
    {

        public Character()
        {
            //define initial state
            _pos = new Vector2(0, 0);

            //define character attributes
            _walkSpeed = 0.0001f;
            _fallSpeed = 0.0005f;
            _jumpHeight = 0.02f;

            //register animations
            _animations += new Idle();
            _animations += new Walk();
            _animations += new DefaultAnimation(CharacterState.Jump);

        }
    }
}