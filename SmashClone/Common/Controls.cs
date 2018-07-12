using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;
using static SmashClone.Common.Constants;
namespace SmashClone.Common
{
    public class Controls
    {

        private Dictionary<Key, uint> _controls;

        public Controls()
        {
            _controls = new Dictionary<Key, uint>
            {
                { Key.A, Inputs.LInput },
                { Key.D, Inputs.RInput },
                //_controls.Add(Key.W, Inputs.UInput);
                { Key.S, Inputs.DInput },
                { Key.W, Inputs.JInput }
            };

        }

        public bool IsKeyRegistered(KeyboardState keyState)
        {
            foreach (Key key in _controls.Keys)
            {
                if (keyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public State GetControl(KeyboardState keyState)
        {
            State StateOut = new State();
            foreach (Key key in _controls.Keys)
            {
                if (keyState.IsKeyDown(key))
                {
                    StateOut += _controls[key];
                }
            }
            //Console.WriteLine(StateOut);
            return StateOut;
        }
    }
}
