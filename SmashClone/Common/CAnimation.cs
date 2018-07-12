using System;
using OpenTK;
using static SmashClone.Common.Constants;
using SmashClone.Driver;

namespace SmashClone.Common
{
    public abstract class CAnimation
    {
        protected AnimationState _state;
        protected Box[][] _hurtBoxes;
        protected int _frame;
        protected int _start = -1;
        protected int _main;
        protected int _end = -1;
        public bool Active;

        public AnimationState State { get => _state; }

        public virtual void Draw(Vector2 pos, bool active)
        {
            foreach (Box box in _hurtBoxes[_frame])
            {
                Game.DrawBox(box, pos, HurtBoxColor);
            }
            AdvanceFrame(active);
        }

        protected virtual void AdvanceFrame(bool active)
        {
            if (_frame+1 > _end)
            {
                _frame = 0;
            }
            else
            {
                _frame++;
            }
        }

        public void Reset()
        {
            _frame = 0;
        }
    }
}
