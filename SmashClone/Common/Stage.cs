using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace SmashClone.Common
{
    public class Stage
    {
        public float Ground { get; }
        public float Friction { get; }


        public Stage(float ground, float friction)
        {
            Ground = ground;
            Friction = friction;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.GhostWhite);
            GL.Vertex2(-1f, Ground);
            GL.Vertex2(1f, Ground);
            GL.Vertex2(1f, -0.9f);
            GL.Vertex2(-1f, -0.9f);
            GL.End();
        }
    }
}
