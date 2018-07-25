using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenPlatformFighter.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlatformFighter.Driver
{
    public static class Draw
    {
        public static void DrawBox(Box box, Vector2 pos, Color color)
        {
            float vec = (float)Math.Sin(Math.PI / 4) * box.Radius;
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color);
            GL.Vertex2(box.Center.X + pos.X - vec, box.Center.Y + pos.Y - vec);
            GL.Vertex2(box.Center.X + pos.X + vec, box.Center.Y + pos.Y - vec);
            GL.Vertex2(box.Center.X + pos.X + vec, box.Center.Y + pos.Y + vec);
            GL.Vertex2(box.Center.X + pos.X - vec, box.Center.Y + pos.Y + vec);
            GL.End();
        }

        public static void DrawBoxes(Box[] boxes, Vector2 pos, Color color)
        {
            foreach (Box b in boxes)
            {
                DrawBox(b, pos, color);
            }
        }

        public static void DrawVBO(int VBO, Vector2[] data, Vector2 pos, Color color)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.InvalidateBufferData(VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Vector2.SizeInBytes * data.Length), data, BufferUsageHint.StreamDraw);
            GL.Color3(color);
            Matrix4 trans = Matrix4.CreateTranslation(pos.X, pos.Y, 0f);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref trans);
            GL.DrawArrays(Constants.BoxPrimitiveType, 0, data.Length);
        }
    }
}
