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

        public Constants.CharacterState State { get
            {
                return _state;
            }}

        public virtual void Draw(Vector2 pos)
        {
            foreach (HitBox box in _hitBoxes[_frame])
            {
                Game.DrawBox(box + pos);
            }
            AdvanceFrame();
        }

        public virtual void AdvanceFrame()
        {
            if (_frame+1 >= _numFrames)
            {
                _frame = 0;
            }
            else
            {
                _frame++;
            }
        }
    }
}
