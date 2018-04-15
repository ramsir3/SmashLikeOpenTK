using System;
using SmashClone;
using OpenTK;
using static SmashClone.Constants;
namespace SmashClone.DefaultCharacter
{
    public class Default : Character
    {

        public Default()
        {
            //define initial state
            _pos = new Vector2(0, 0);

            //define character attributes
            _walkSpeed = 0.0001f;
            _fallSpeed = 0.0005f;
            _jumpHeight = 0.02f;

            //register animations
            _animations += new DefaultIdle();
            _animations += new DefaultWalk();
            _animations += new DefaultAnimation(CharacterState.Jump);


        }
    }
}

