using System;
using OpenTK;
using static SmashClone.Constants;

namespace SmashClone
{
    public class DefaultWalk : CharacterAnimation
    {
        public DefaultWalk()
        {
            _frame = 0;
            _numFrames = 10;
            _start = 3;
            _main = 5;
            _end = 9;
            _state = CharacterState.Walk;
            _hitBoxes = new HitBox[][] {
                new HitBox[] //Frame 0
                {
                    new HitBox(new Vector2(0, 0), 0.1f)
                },
                new HitBox[] //Frame 1
                {
                    new HitBox(new Vector2(0, 0), 0.1f)
                },
                new HitBox[] //Frame 2
                {
                    new HitBox(new Vector2(0, 0.0125f), 0.125f)
                },
                new HitBox[] //Frame 3
                {
                    new HitBox(new Vector2(0, 0.0125f), 0.125f)
                },
                new HitBox[] //Frame 4
                {
                    new HitBox(new Vector2(0, 0.025f), 0.15f)
                },
                new HitBox[] //Frame 5
                {
                    new HitBox(new Vector2(0, 0.025f), 0.15f)
                },
                new HitBox[] //Frame 6
                {
                    new HitBox(new Vector2(0, 0125f), 0.125f)
                },
                new HitBox[] //Frame 7
                {
                    new HitBox(new Vector2(0, 0125f), 0.125f)
                },
                new HitBox[] //Frame 8
                {
                    new HitBox(new Vector2(0, 0), 0.1f)
                },
                new HitBox[] //Frame 9
                {
                    new HitBox(new Vector2(0, 0), 0.1f)
                }

            };
        }

		public override void AdvanceFrame(bool active)
		{
            if (active && _frame < _main)
            {
                _frame++;
            }
            if (active && _frame >= _main)
            {
                _frame = _start+1;
            }
            if (!active && _frame >= _main)
            {
                _frame++;
            }
            if (_frame > _end)
            {
                _frame = 0;
            }
		}

	}
}
