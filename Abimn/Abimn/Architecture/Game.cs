using System;
using System.IO;
using System.Collections;
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
    /// Classe Game mère
    /// C'est elle qui switch entre tous les éléments de la pile de jeu
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Rand.Init();
            G.currentGame = new Stack<GameType>();
            G.content = new Hashtable();

            //this.IsMouseVisible = true;
            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferWidth = C.Screen.Width;
            this.graphics.PreferredBackBufferHeight = C.Screen.Height;
            this.graphics.ApplyChanges();
            this.Window.Title = "Abimn";
            this.Window.AllowUserResizing = true;

            base.Initialize();

            Cursor.Initialize();
            Cursor.SetCursor("cursor", "default", "clicked", new Pos(-15, -5));
            G.currentGame.Push(new Menu());
        }

        protected override void LoadContent()
        {
            G.spriteBatch = new SpriteBatch(GraphicsDevice);

            Ressources.Load(Content);
        }

        protected override void UnloadContent() {}

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

            while (G.currentGame.Count != 0 && G.currentGame.Peek().State == State.Exit)
                G.currentGame.Pop();
            if (G.currentGame.Count == 0)
                return;
            if (G.currentGame.Peek().State == State.Reload)
                G.currentGame.Peek().Initialize();

            Cursor.Update();

            base.Update(gameTime);
        }

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
