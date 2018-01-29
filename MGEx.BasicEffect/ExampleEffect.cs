using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGEx.BasicEffectIntro
{
    class ExampleEffect : BasicEffect
    {
        public ExampleEffect(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            AmbientLightColor = new Vector3(0.1f, 0.1f, 0.1f);
            DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
            SpecularColor = new Vector3(0.25f, 0.25f, 0.25f);
            SpecularPower = 5.0f;
            Alpha = 1.0f;

            LightingEnabled = true;

            DirectionalLight0.Enabled = true;
            DirectionalLight0.DiffuseColor = new Vector3(1, 0, 0);
            DirectionalLight0.Direction = Vector3.Normalize(new Vector3(-1, 0, 0));
            DirectionalLight0.SpecularColor = Vector3.One;

            DirectionalLight1.Enabled = true;
            DirectionalLight1.DiffuseColor = new Vector3(0, 0.75f, 0);
            DirectionalLight1.Direction = Vector3.Normalize(new Vector3(0, -1, 0));
            DirectionalLight1.SpecularColor = Vector3.One;

            DirectionalLight2.Enabled = true;
            DirectionalLight2.DiffuseColor = new Vector3(0, 0, 0.5f);
            DirectionalLight2.Direction = Vector3.Normalize(new Vector3(0, 0, -1));
            DirectionalLight2.SpecularColor = Vector3.One;
        }
    }
}
