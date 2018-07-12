using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashClone.Common
{
    public abstract class CLoopedAnimation:CAnimation
    {
        protected override void AdvanceFrame(bool active)
        {
            if (active && _frame < _main)
            {
                _frame++;
            }
            if (active && _frame >= _main)
            {
                _frame = _start + 1;
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
