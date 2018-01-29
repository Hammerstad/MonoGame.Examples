using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGEx.Common
{
    public class Camera
    {
        public Matrix World { get; }
        public Matrix View { get; }
        public Matrix Projection { get; }

        public Camera(GraphicsDevice graphicsDevice)
        {
            float tilt = MathHelper.ToRadians(0);  // 0 degree angle
                                                   // Use the world matrix to tilt the cube along x and y axes.
            World = Matrix.CreateRotationX(tilt) * Matrix.CreateRotationY(tilt);
            View = Matrix.CreateLookAt(new Vector3(5, 5, 5), Vector3.Zero, Vector3.Up);

            Projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(45),  // 45 degree angle
                (float)graphicsDevice.Viewport.Width /
                (float)graphicsDevice.Viewport.Height,
                1.0f, 100.0f);
        }
    }
}
