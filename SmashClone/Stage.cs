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
        float _ground;
        float _friction;

        public float Ground { get { return _ground; } }
        public float Friction { get { return _friction; } }


        public Stage(float ground, float friction)
        {
            _ground = ground;
            _friction = friction;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.GhostWhite);
            GL.Vertex2(-1f, _ground);
            GL.Vertex2(1f, _ground);
            GL.Vertex2(1f, -0.9f);
            GL.Vertex2(-1f, -0.9f);
            GL.End();

        }
    }
}
