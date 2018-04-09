using OpenTK;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmashClone
{
    public struct HitBox : IBox
    {
        Vector2 _center;
        float _radius;

        public Vector2 Center { get => _center; }
        public float Radius { get => _radius; }
        public Color Color { get => Constants.HitBoxColor; }


        //public Vector2 Center { get; set;}
        //public float Radius { get; } }
        //public Color Color { get { return Constants.HitBoxColor; } }

        public HitBox(Vector2 center, float radius)
        {
            _center = center;
            _radius = radius;
        }

        public static HitBox operator+ (HitBox box, Vector2 pos)
        {
            return new HitBox(box.Center+pos, box.Radius);
        }

    }
}

