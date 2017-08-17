using OpenTK;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashClone
{
    public interface IBox
    {
        Vector2 Center { get; }
        float Radius { get; }
        Color Color { get; }
    }
}
