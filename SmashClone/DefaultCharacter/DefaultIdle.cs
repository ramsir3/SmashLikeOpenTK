using System;
using OpenTK;
using static SmashClone.Constants;

namespace SmashClone
{
    public class DefaultIdle:CharacterAnimation
    {
        public DefaultIdle()
        {
            _numFrames = 1;
            _frame = 0;
            _state = CharacterState.Idle;
            _hitBoxes = new HitBox[][] { 
                new HitBox[] //Frame 0
                {
                    new HitBox(new Vector2(0, 0), 0.1f)
                } 
            };
        }


    }
}
