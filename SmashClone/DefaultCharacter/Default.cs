using System;
using SmashClone;
namespace SmashClone.DefaultCharacter
{
    public class Default:Character
    {
        
        public Default() {
            WalkSpeed = 0.01f;

            _animations += new DefaultIdle();
            _animations += new DefaultWalk();       

        }
    }
}

