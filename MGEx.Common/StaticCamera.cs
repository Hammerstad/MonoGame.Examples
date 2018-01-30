using Microsoft.Xna.Framework;

namespace MGEx.Common
{
    public class StaticCamera : ICamera
    {

        public StaticCamera() : this(new Vector3(5,5,5))
        {

        }

        public StaticCamera(Vector3 cameraPosition)
        {
            World = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 1000f);
        }

        public Matrix World { get; }
        public Matrix View { get; }
        public Matrix Projection { get; }
    }
}
