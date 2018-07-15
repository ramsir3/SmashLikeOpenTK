using OpenTK;
using OpenTK.Graphics.OpenGL;
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

        public Vector2[] ToVectArr(PrimitiveType type, Vector2 pos)
        {
            float rad = Radius;
            switch (type)
            {
                case PrimitiveType.Quads:
                    return new Vector2[4] {
                        new Vector2(Center.X - rad + pos.X, Center.Y - rad + pos.Y),
                        new Vector2(Center.X + rad + pos.X, Center.Y - rad + pos.Y),
                        new Vector2(Center.X + rad + pos.X, Center.Y + rad + pos.Y),
                        new Vector2(Center.X - rad + pos.X, Center.Y + rad + pos.Y)
                    };
                case PrimitiveType.Polygon:
                    int nume = (int)((2 * Math.PI * rad) / Constants.CircleEdgeLen) + 1;
                    Vector2[] arrout = new Vector2[nume];
                    int j = 0;
                    for (double i = 0; i < 2 * Math.PI; i += 2 * Math.PI / nume)
                    {
                        arrout[j++] = new Vector2((float)Math.Cos(i) * rad + Center.X + pos.X, (float)Math.Sin(i) * rad + Center.Y + pos.Y);
                    }
                    return arrout;
                default:
                    throw new Exception("Unsupported primitive type");
            }
        }


        public Vector2[] ToVectArr(PrimitiveType type)
        {
            float rad = Radius;
            switch (type)
            {
                case PrimitiveType.Quads:
                    return new Vector2[4] {
                        new Vector2(Center.X - rad, Center.Y - rad),
                        new Vector2(Center.X + rad, Center.Y - rad),
                        new Vector2(Center.X + rad, Center.Y + rad),
                        new Vector2(Center.X - rad, Center.Y + rad)
                    };
                case PrimitiveType.Polygon:
                    int nume = (int)((2 * Math.PI * rad) / Constants.CircleEdgeLen) + 1;
                    Vector2[] arrout = new Vector2[nume];
                    int j = 0;
                    for (double i = 0; (i < 2 * Math.PI) && (j < nume); i += 2 * Math.PI / nume)
                    {
                        arrout[j++] = new Vector2((float)Math.Cos(i) * rad + Center.X, (float)Math.Sin(i) * rad + Center.Y);
                    }
                    return arrout;
                default:
                    throw new Exception("Unsupported primitive type");
            }
        }

        public int VectArrLen(PrimitiveType type)
        {
            float rad = Radius;
            switch (type)
            {
                case PrimitiveType.Quads:
                    return 4;
                case PrimitiveType.Polygon:
                    return (int)((2 * Math.PI * rad) / Constants.CircleEdgeLen) + 1;
                default:
                    throw new Exception("Unsupported primitive type");
            }
        }
    }
}
