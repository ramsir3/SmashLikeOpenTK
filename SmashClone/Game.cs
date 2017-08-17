using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace SmashClone
{
    class Game : GameWindow
    {
        Texture2D texture;
        View view;
        Stage stage;

        public Game(int width, int height)
            : base(width, height)
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            //GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Gequal, 0.5f);

            view = new View(Vector2.Zero, 1.0, 0.0);
            stage = new Stage(-0.3f);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            texture = ContentPipe.LoadTexture("penguin4.png");
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            view.Update();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.ClearColor(Color.CornflowerBlue);

            GL.ClearDepth(1);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.LoadIdentity();
            view.ApplyTransform();


            //GL.BindTexture(TextureTarget.Texture2D, texture.ID);
            //GL.Begin(PrimitiveType.Quads);

            //GL.Color3(Color.Red);
            //GL.TexCoord2(0, 0); GL.Vertex2(0, 0.9f);
            //GL.Color3(Color.Blue);
            //GL.TexCoord2(1, 0); GL.Vertex2(1, 1);
            //GL.Color3(Color.Yellow);
            //GL.TexCoord2(1, 1); GL.Vertex2(0.9f, 0);
            //GL.Color3(Color.Green);
            //GL.TexCoord2(0, 1); GL.Vertex2(0, 0);

            //GL.End();

            stage.Draw();


            this.SwapBuffers();
        }
    }
}
