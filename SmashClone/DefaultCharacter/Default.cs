using System;
using SmashClone;
using OpenTK;
using static SmashClone.Constants;
namespace SmashClone.DefaultCharacter
{
    public class Default:Character
    {
        
        public Default() {
            //define initial state
			_pos = new Vector2(0, 0);
            Grounded = true;
            State = CharacterState.Idle;

            //define character attributes
            WalkSpeed = 0.01f;
            FallSpeed = 0.05f;

            //register animations
            _animations += new DefaultIdle();
            _animations += new DefaultWalk();       

        }
    }
}

