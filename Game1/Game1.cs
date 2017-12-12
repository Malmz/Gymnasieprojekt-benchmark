using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        List<Sprite> sprites;
        int frames;
        double time;
        string frameString;
        SpriteFont arial;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            frames = 0;
            frameString = "";
            sprites = new List<Sprite>();
            graphics.PreferredBackBufferWidth = 854;
            graphics.PreferredBackBufferHeight = 480;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("FeelsBadMan");
            arial = Content.Load<SpriteFont>("Arial");
            LateInit();
        }

        private void LateInit()
        {
            var pos = new Vector2();
            var scale = new Vector2(0.03f, 0.03f);
            var rot = 0.0001f;
            Sprite sprite;
            for (int i = 0; i < 271; i++)
            {
                for (int j = 0; j < 196; j++)
                {
                    pos.X = i * 2;
                    pos.Y = j * 2;
                    sprite = new Sprite(texture, pos, scale);
                    sprite.RotSpeed = rot;
                    sprites.Add(sprite);
                }
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime);
            }
          

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime.TotalSeconds;
            if (time < 1)
            {
                frames += 1;
            }
            else
            {
                frameString = frames.ToString();
                frames = 0;
                time = 0;
                
            }

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }

            spriteBatch.DrawString(arial, frameString, new Vector2(50, 50), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
