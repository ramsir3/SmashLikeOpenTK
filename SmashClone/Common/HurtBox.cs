using OpenTK;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashClone
{
    struct HurtBox : IBox
    {
        private Vector2 center;
        private float radius;

        public Vector2 Center { get { return center; } }
        public float Radius { get { return radius; } }
        public Color Color { get { return Constants.HurtBoxColor; } }

        public HurtBox(Vector2 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }
    }
}

