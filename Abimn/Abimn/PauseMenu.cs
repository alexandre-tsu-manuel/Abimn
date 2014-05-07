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
    public class PauseMenu : GameType
    {
        private Button resume, exit, option;
        private Entity fond_menu;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public PauseMenu() : base(false)
        {
            Cursor.SetVisibility(true);
            resume = new Button();
            exit = new Button();
            option = new Button();

            fond_menu = new Entity();
            fond_menu.Initialize(new Pos(fond_menu.Pos.X+112,fond_menu.Pos.Y+ 94));
            fond_menu.LoadContent(1, Tiles.PauseMenu);
			/*Peut-etre que un joli cadre pause serait bienvenue non obligatoire*/
            resume.Initialize(new Pos(fond_menu.Pos.X + 250, fond_menu.Pos.Y + 195));
            resume.LoadContent(2, 6, 2, Tiles.PauseMenu);

            option.Initialize(new Pos(fond_menu.Pos.X + 250, fond_menu.Pos.Y + 275));
            option.LoadContent(3, 5, 3, Tiles.PauseMenu);

            exit.Initialize(new Pos(fond_menu.Pos.X + 250, fond_menu.Pos.Y + 355));
            exit.LoadContent(4, 7, 4, Tiles.PauseMenu);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (E.LeftIsReleased())
            {
                if (resume.mouseOver())
                    G.currentGame.Pop();
                else if (exit.mouseOver())
                {
                    G.currentGame.Clear();
                    G.currentGame.Push(new Menu());
                }
                else if (option.mouseOver())
                    G.currentGame.Push(new OptionsMenu());
            }
            if (E.IsPushed(Keys.Escape))
                G.currentGame.Push(new Main());
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw()
        {
            fond_menu.Draw();
            resume.Draw();
            exit.Draw();
            option.Draw();
        }
    }
}
