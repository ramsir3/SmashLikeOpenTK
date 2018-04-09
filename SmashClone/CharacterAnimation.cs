using System;
using OpenTK;

namespace SmashClone
{
    public abstract class CharacterAnimation
    {
        protected Constants.CharacterState _state;
        protected HitBox[][] _hitBoxes;
        protected int _frame;
        protected int _numFrames;
        protected int _start = -1;
        protected int _main;
        protected int _end = -1;
        public bool Active;

        public Constants.CharacterState State { get
            {
                return _state;
            }}

        public virtual void Draw(Vector2 pos, bool active)
        {
            foreach (HitBox box in _hitBoxes[_frame])
            {
                Game.DrawBox(box, pos);
            }
            AdvanceFrame(active);
        }

        public virtual void AdvanceFrame(bool active)
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
