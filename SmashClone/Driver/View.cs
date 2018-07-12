using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using static SmashClone.Common.Constants;

namespace SmashClone.Driver
{
    class View
    {
        public Vector2 position;

        /// <summary>
        /// In radians, + = clockwise
        /// </summary>
        public double rotation;

        /// <summary>
        /// 1 = no zoom
        /// 2 = 2x zoom
        /// </summary>
        public double zoomX;
        public double zoomY;

        public View(Vector2 startPosition, double startZoom = 1.0, double startRotation = 0.0)
        {
            this.position = startPosition;
            this.zoomX = (startZoom / GameWidth) * GameWidth;
            this.zoomY = (startZoom / GameHeight) * GameWidth;
            this.rotation = startRotation;
        }

        public void Update()
        {

        }

        public void ApplyTransform()
        {
            Matrix4 transform = Matrix4.Identity;

            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-position.X, -position.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ(-(float)rotation));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)zoomX, (float)zoomY, 1.0f));

            GL.MultMatrix(ref transform);
        }
    }
}
