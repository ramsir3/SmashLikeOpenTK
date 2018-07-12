using System;
using OpenTK;
using SmashClone;
using static SmashClone.Common.Constants;
using SmashClone.Common;

namespace SmashClone.Characters.DefaultCharacter
{
    public class DefaultAnimation : CAnimation
    {
        public DefaultAnimation(AnimationState state)
        {
            _frame = 0;
            _state = state;
            _hurtBoxes = new Box[][] {
                new Box[] //Frame 0
                {
                    new Box(new Vector2(0, 0), 0.1f)
                }
            };
        }

    }
}