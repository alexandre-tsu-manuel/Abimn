using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Abimn
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public Game()
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
            Rand.Init();
            G.currentGame = new Stack<GameType>();

            Cursor.setCursor(Tiles.Cursor, 1, 2, new Pos(15, 5));
            //this.IsMouseVisible = true;
            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferWidth = C.Screen.Width;
            this.graphics.PreferredBackBufferHeight = C.Screen.Height;
            this.graphics.ApplyChanges();
            this.Window.Title = "Abimn";
            this.Window.AllowUserResizing = true;

            base.Initialize();

            G.currentGame.Push(new Menu());
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            G.spriteBatch = new SpriteBatch(GraphicsDevice);
            TilesManager.Initialize(Content);
            G.vie = Content.Load<SpriteFont>("vie");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || G.currentGame.Count == 0)
            {
                this.Exit();
                return;
            }

            E.Update();

            G.currentGame.Peek().Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (G.currentGame.Count == 0)
                return;

            Stack<GameType> buffer = new Stack<GameType>();

            GraphicsDevice.Clear(Color.Black);

            while (G.currentGame.Count != 1 && !G.currentGame.Peek().IsFullScreen)
                buffer.Push(G.currentGame.Pop());
            buffer.Push(G.currentGame.Pop());
            G.spriteBatch.Begin();
            while (buffer.Count != 0)
            {
                buffer.Peek().Draw();
                G.currentGame.Push(buffer.Pop());
            }
            Cursor.Draw();
            G.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
