﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MGEx.Common;

namespace MGEx.BasicEffectIntro
{
    public class BasicEffectGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private readonly ICamera camera;

        private BasicEffect exampleEffect;
        private BasicEffect basicEffect;
        private BasicEffect currentBasicEffect;

        private Cube orangeCube;
        private SpriteBatch spriteBatch;
        private KeyboardState previousKeyboardState;
        private SpriteFont font;

        public BasicEffectGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            camera = new StaticCamera();
        }

        protected override void Initialize()
        {
            exampleEffect = new ExampleEffect(graphics.GraphicsDevice)
            {
                World = camera.World,
                View = camera.View,
                Projection = camera.Projection
            };
            basicEffect = new BasicEffect(graphics.GraphicsDevice)
            {
                World = camera.World,
                View = camera.View,
                Projection = camera.Projection,
                VertexColorEnabled = true
            };
            currentBasicEffect = exampleEffect;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            orangeCube = new Cube(GraphicsDevice, Color.Orange);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            previousKeyboardState = Keyboard.GetState();
            font = Content.Load<SpriteFont>("Courier New");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (KeyReleased(Keys.D1))
                currentBasicEffect = (currentBasicEffect == exampleEffect) ? basicEffect : exampleEffect;

            orangeCube.Update(gameTime);

            previousKeyboardState = Keyboard.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SteelBlue);

            DrawText();
            orangeCube.Draw(GraphicsDevice, currentBasicEffect);

            base.Draw(gameTime);
        }

        private void DrawText()
        {
            spriteBatch.Begin();
            var effectName = currentBasicEffect == basicEffect ? "vertex colors enabled" : "vertex colors and lighting enabled";
            spriteBatch.DrawString(font, $"Press '1' to change effect." , new Vector2(50, 30), Color.Black);
            spriteBatch.DrawString(font, $"Currently using basic effect with {effectName}" , new Vector2(50, 50), Color.Black);
            spriteBatch.End();

            // Reset defaults after spritebatch is done
            GraphicsDevice.BlendState = BlendState.Opaque;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.RasterizerState = RasterizerState.CullClockwise;
        }

        private bool KeyReleased(Keys key)
        {
            return Keyboard.GetState().IsKeyUp(key) && previousKeyboardState.IsKeyDown(key);
        }
    }
}
