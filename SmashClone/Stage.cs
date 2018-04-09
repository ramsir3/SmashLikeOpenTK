using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace SmashClone
{
    public class Stage
    {
        float ground;

        public float Ground { get { return ground; } }

        public Stage(float ground)
        {
            this.ground = ground;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.GhostWhite);
            GL.Vertex2(-1f, ground);
            GL.Vertex2(1f, ground);
            GL.Vertex2(1f, -0.9f);
            GL.Vertex2(-1f, -0.9f);
            GL.End();

        }
    }
}
