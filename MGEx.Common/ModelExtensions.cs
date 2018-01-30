using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGEx.Common
{
    public static class ModelExtensions
    {
        public static void DrawModel(this Model model, ICamera camera)
        {
            model.DrawModel(camera.World, camera.View, camera.Projection);
        }

        public static void DrawModel(this Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }
        }
    }
}
