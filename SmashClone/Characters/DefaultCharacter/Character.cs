using System;
using SmashClone;
using OpenTK;
using static SmashClone.Common.Constants;

namespace SmashClone.Characters.DefaultCharacter
{
    public class Character : Common.Character
    {

        public Character()
        {
            //define character attributes
            _walkSpeed = 0.0001f;
            _fallSpeed = 0.0005f;
            _jumpHeight = 0.02f;

            //register animations
            _animations += new Idle();
            _animations += new Walk();
            _animations += new DefaultAnimation(AnimationState.Jump);

        }
    }
}