using System;
using SmashClone;
using OpenTK;
using static SmashClone.Common.Constants;
using System.Drawing;

namespace SmashClone.Characters.DefaultCharacter
{
    public class Character : Common.Character
    {
        public Character(Color color)
        {
            //define character attributes
            _walkSpeed = 0.0001f;
            _fallSpeed = 0.0005f;
            _jumpHeight = 0.02f;
            _color = color;

            //register animations
            _animations += new Idle();
            _animations += new Walk();
            _animations += new DefaultAnimation(AnimationStates.Jump);
        }
    }
}