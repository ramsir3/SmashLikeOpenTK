using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;
using static OpenPlatformFighter.Common.Constants;
namespace OpenPlatformFighter.Common
{
    public class Controls
    {

        private Dictionary<Key, uint> _controls;

        public Controls(int i)
        {
            if (i > 0)
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
            else
            {
                _controls = new Dictionary<Key, uint>
                {
                    { Key.Left, Inputs.LInput },
                    { Key.Right, Inputs.RInput },
                    //_controls.Add(Key.W, Inputs.UInput);
                    { Key.Down, Inputs.DInput },
                    { Key.Up, Inputs.JInput }
                };
            }

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
