using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using static SmashClone.Common.Constants;
using static SmashClone.Driver.Draw;

namespace SmashClone.Common
{
    public abstract class CAnimation
    {
        protected AnimationStates _state;
        protected Box[][] _hurtBoxes;
        protected Vector2[][] _vecBoxes;
        protected int VBO;
        protected int _frame;
        protected int _start = -1;
        protected int _main;
        protected int _end = -1;
        protected bool Active;

        public AnimationStates State { get => _state; }

        public CAnimation()
        {
            Init();
            if (Constants.UseVBOs)
            {
                VBO = GL.GenBuffer();
                GetVecArr();
            }
        }

        protected abstract void Init();

        private Vector2[] GetOneVecArr(int frame)
        {
            if (_hurtBoxes != null && _hurtBoxes.Length != 0)
            {
                int arrlen = 0;
                foreach (Box b in _hurtBoxes[frame])
                {
                    arrlen += b.VectArrLen(BoxPrimitiveType);
                }

                Vector2[] vector2s = new Vector2[arrlen];
                int p = 0;
                foreach (Box b in _hurtBoxes[frame])
                {
                    b.ToVectArr(BoxPrimitiveType).CopyTo(vector2s, p);
                    p += b.VectArrLen(BoxPrimitiveType);
                }
                return vector2s;
            }
            return null;
        }

        private void GetVecArr()
        {
            if (_hurtBoxes != null && _hurtBoxes.Length != 0)
            {
                _vecBoxes = new Vector2[_hurtBoxes.Length][];
                for (int i = 0; i < _hurtBoxes.Length; i++)
                {
                    _vecBoxes[i] = GetOneVecArr(i);
                }
            }
        }

        public virtual void Draw(Vector2 pos, bool active, Color color)
        {
            if (_vecBoxes != null && _vecBoxes[_frame] != null)
            {
                //Console.WriteLine(_vecBoxes[_frame]);
                DrawVBO(VBO, _vecBoxes[_frame], pos, color);
            }
            else
            {
                DrawBoxes(_hurtBoxes[_frame], pos, color);
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
