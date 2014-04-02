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
        SpriteBatch spriteBatch;

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
            G.currentGame = new Stack<CurrentGame>();
            this.LoadContentFast();
            G.oldFrame = null;
            G.currentGame.Push(CurrentGame.Menu);
            Menu.Initialize(spriteBatch);

            this.IsMouseVisible = true;
            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferWidth = C.Screen.Width;
            this.graphics.PreferredBackBufferHeight = C.Screen.Height;
            this.graphics.ApplyChanges();

            this.Window.Title = "Abimn";

            this.Window.AllowUserResizing = true;

            base.Initialize();
        }

        private void LoadContentFast()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            G.mainTiles = new Tile[C.nbMainTiles];
            G.mainDecoTiles = new Tile[C.nbMainTiles];
            G.fightTiles = new Tile[C.nbFightTiles];
            G.pause_menuTiles = new Tile[C.nbpause_menuTiles];
            G.inventoryTiles = new Tile[C.nbinventoryTiles];
            G.heroTiles = new Tile[C.nbheroTiles];
            G.recapTiles = new Tile[C.nbrecapTiles];
            G.buttonTiles = new Tile[C.nbButtonTiles];

            for (int i = 1; i <= C.nbMainTiles; i++)
            {
                G.mainTiles[i - 1] = new Tile();
                G.mainTiles[i - 1].LoadContent(Content, "m" + i.ToString());
            }
            for (int i = 1; i <= C.nbMainDecoTiles; i++)
            {
                G.mainDecoTiles[i - 1] = new Tile();
                G.mainDecoTiles[i - 1].LoadContent(Content, "md" + i.ToString());
            }
            for (int i = 1; i <= C.nbFightTiles; i++)
            {
                G.fightTiles[i - 1] = new Tile();
                G.fightTiles[i - 1].LoadContent(Content, "f" + i.ToString());
            }
            for (int i = 1; i <= C.nbpause_menuTiles; i++)
            {
                G.pause_menuTiles[i - 1] = new Tile();
                G.pause_menuTiles[i - 1].LoadContent(Content, "pause_menu" + i.ToString());
            }
            for (int i = 1; i <= C.nbinventoryTiles; i++)
            {
                G.inventoryTiles[i - 1] = new Tile();
                G.inventoryTiles[i - 1].LoadContent(Content, "inventory" + i.ToString());
            }
            for (int i = 1; i <= C.nbheroTiles; i++)
            {
                G.heroTiles[i - 1] = new Tile();
                G.heroTiles[i - 1].LoadContent(Content, "hero" + i.ToString());
            }
            for (int i = 1; i <= C.nbrecapTiles; i++)
            {
                G.recapTiles[i - 1] = new Tile();
                G.recapTiles[i - 1].LoadContent(Content, "recap" + i.ToString());
            }
            for (int i = 1; i <= C.nbButtonTiles; i++)
            {
                G.buttonTiles[i - 1] = new Tile();
                G.buttonTiles[i - 1].LoadContent(Content, "menup" + i.ToString());
            }

            G.vie = Content.Load<SpriteFont>("vie");
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
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

            switch (G.currentGame.Peek())
            {
                case CurrentGame.Menu:
                    Menu.Update(gameTime);
                    break;
                case CurrentGame.HeroCreator:
                    HeroCreator.Update(gameTime);
                    break;
                case CurrentGame.Main:
                    Main.Update(gameTime);
                    break;
                case CurrentGame.PauseMenu:
                    PauseMenu.Update(gameTime);
                    break;
                case CurrentGame.OptionsMenu:
                    OptionsMenu.Update(gameTime);
                    break;
                case CurrentGame.Fight:
                    Fight.Update(gameTime);
                    break;
                case CurrentGame.FightRecap:
                    FightRecap.Update(gameTime);
                    break;
                case CurrentGame.Inventory:
                    Inventory.Update(gameTime);
                    break;
                case CurrentGame.GameOver:
                    GameOver.Update(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        private void DrawCurrentGame(CurrentGame curr)
        {
            switch (curr)
            {
                case CurrentGame.Menu:
                    Menu.Draw();
                    break;
                case CurrentGame.HeroCreator:
                    HeroCreator.Draw();
                    break;
                case CurrentGame.Main:
                    Main.Draw();
                    break;
                case CurrentGame.PauseMenu:
                    PauseMenu.Draw();
                    break;
                case CurrentGame.OptionsMenu:
                    OptionsMenu.Draw();
                    break;
                case CurrentGame.Fight:
                    Fight.Draw();
                    break;
                case CurrentGame.FightRecap:
                    FightRecap.Draw();
                    break;
                case CurrentGame.Inventory:
                    Inventory.Draw();
                    break;
                case CurrentGame.GameOver:
                    GameOver.Draw();
                    break;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (G.currentGame.Count == 0)
                return;

            int w = GraphicsDevice.PresentationParameters.BackBufferWidth;
            int h = GraphicsDevice.PresentationParameters.BackBufferHeight;

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            if (G.currentGame.Count != 1)
            {
                CurrentGame tmp = G.currentGame.Pop();
                DrawCurrentGame(G.currentGame.Peek());
                G.currentGame.Push(tmp);
            }
            DrawCurrentGame(G.currentGame.Peek());
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
