using OpenTK;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashClone.Common
{
    public struct Box
    {
        
        public Vector2 Center { get; }
        public float Radius { get; }

        public Box(Vector2 center, float radius)
        {
            Center = center;
            Radius = radius;
        }
    }

}
