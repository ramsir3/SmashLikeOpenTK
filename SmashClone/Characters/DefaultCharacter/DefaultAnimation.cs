using System;
using OpenTK;
using OpenPlatformFighter;
using static OpenPlatformFighter.Common.Constants;
using OpenPlatformFighter.Common;

namespace OpenPlatformFighter.Characters.DefaultCharacter
{
    public class DefaultAnimation : CLoopedAnimation
    {
        public DefaultAnimation(AnimationStates state)
        {
            _state = state;
        }

        protected override void Init()
        {
            _frame = 0;
            _end = 1;
            _main = 1;
            _start = 0;
            _hurtBoxes = new Box[][] {
                new Box[] //Frame 0
                {
                    new Box(new Vector2(0, 0), 0.1f),
                    new Box(new Vector2(0, 0.2f), 0.075f),
                },
                new Box[] //Frame 1
                {
                    new Box(new Vector2(0, 0), 0.1f),
                    new Box(new Vector2(0, 0.2f), 0.075f),
                }
            };
        }
    }
}