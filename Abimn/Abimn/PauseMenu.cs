using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Combat instancié
    /// </summary>
    public static class PauseMenu
    {
        private static Button resume, exit, option;
        private static Entity fond_menu;

        private static SpriteBatch spriteBatch;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public static void Initialize(SpriteBatch spriteBatch)
        {
            PauseMenu.spriteBatch = spriteBatch;
            resume = new Button();
            exit = new Button();
            option = new Button();

            fond_menu = new Entity();
            fond_menu.Initialize(new Pos(255, 105));
            fond_menu.LoadContent(1, ref G.pause_menuTiles);

            resume.Initialize(new Pos(fond_menu.Position.X + 60, fond_menu.Position.Y + 145));
            resume.LoadContent(2, 6, 8, ref G.pause_menuTiles);

            option.Initialize(new Pos(fond_menu.Position.X + 60, fond_menu.Position.Y + 195));
            option.LoadContent(3, 5, 9, ref G.pause_menuTiles);

            exit.Initialize(new Pos(fond_menu.Position.X + 60, fond_menu.Position.Y + 245));
            exit.LoadContent(4, 7, 10, ref G.pause_menuTiles);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static void Update(GameTime gameTime)
        {
            E.Update();
            if (E.LeftIsReleased())
            {
                if (resume.mouseOver())
                    G.currentGame.Pop();
                else if (exit.mouseOver())
                {
                    G.currentGame.Clear();
                    G.currentGame.Push(CurrentGame.Menu);
                    Menu.Initialize(spriteBatch);
                }
                else if (option.mouseOver())
                {
                    G.currentGame.Push(CurrentGame.OptionsMenu);
                    OptionsMenu.Initialize(spriteBatch);
                }
            }
            if (E.IsPushed(Keys.Escape))
                G.currentGame.Pop();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public static void Draw()
        {
            fond_menu.Draw(spriteBatch);
            resume.Draw(spriteBatch);
            exit.Draw(spriteBatch);
            option.Draw(spriteBatch);
        }
    }
}
