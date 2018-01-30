using MGEx.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MGEx.BasicModel
{
    public class BasicModelGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private readonly OrbitCamera camera;

        private SpriteBatch spriteBatch;
        private Model spaceship;
        
        public BasicModelGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            camera = new OrbitCamera(new Vector3(100, 25, 0));
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spaceship = Content.Load<Model>("spaceCraft1");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            camera.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spaceship.DrawModel(camera);

            base.Draw(gameTime);
        }
    }
}
