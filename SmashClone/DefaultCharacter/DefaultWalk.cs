using System;
using OpenTK;
using static SmashClone.Constants;

namespace SmashClone
{
    public class DefaultWalk : CharacterAnimation
    {
        public DefaultWalk()
        {
            _numFrames = 2;
            _frame = 0;
            _state = CharacterState.Walk;
            _hitBoxes = new HitBox[][] {
                new HitBox[] //Frame 0
                {
                    new HitBox(new Vector2(0, 0), 0.1f)
                },
                new HitBox[] //Frame 1
                {
                    new HitBox(new Vector2(0, 0.025f), 0.15f)
                }
            };
        }

    }
}
