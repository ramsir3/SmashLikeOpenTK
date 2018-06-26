using System;
using OpenTK;
using SmashClone;
using static SmashClone.Constants;

namespace DefaultCharacter
{
    public class DefaultAnimation : CAnimation
    {
        public DefaultAnimation(CharacterState state)
        {
            _frame = 0;
            _state = state;
            _hitBoxes = new HitBox[][] {
                new HitBox[] //Frame 0
                {
                    new HitBox(new Vector2(0, 0), 0.1f)
                }
            };
        }

    }
}
