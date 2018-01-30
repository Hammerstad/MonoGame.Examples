using Microsoft.Xna.Framework;

namespace MGEx.Common
{
    public class OrbitCamera : ICamera
    {
        private readonly Vector3 cameraPosition;

        private float angle;

        public OrbitCamera(Vector3 cameraPosition)
        {
            World = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 1000f);
            this.cameraPosition = cameraPosition;
        }

        public Matrix World { get; }

        public Matrix View { get; private set; }

        public Matrix Projection { get; }

        public void Update(GameTime gameTime)
        {
            angle += gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            var cameraPosition = Vector3.Transform(this.cameraPosition, Matrix.CreateRotationY(angle));
            View = Matrix.CreateLookAt(cameraPosition, new Vector3(0, 0, 0), Vector3.UnitY);
        }
    }
}
