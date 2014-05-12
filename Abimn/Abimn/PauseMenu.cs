﻿using System;
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
        private Entity resume, exit, option;
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

            fond_menu = new Entity();
            fond_menu.Initialize(new Pos(fond_menu.Pos.X+112,fond_menu.Pos.Y+ 94));
            fond_menu.LoadContent(Tiles.PauseMenu, 1);

            resume = new Entity(new Pos(fond_menu.Pos.X + 250, fond_menu.Pos.Y + 195));
            resume.LoadContent(Tiles.PauseMenu, 2, 6, 2);
            exit = new Entity(new Pos(fond_menu.Pos.X + 250, fond_menu.Pos.Y + 355));
            exit.LoadContent(Tiles.PauseMenu, 4, 7, 4);
            option = new Entity(new Pos(fond_menu.Pos.X + 250, fond_menu.Pos.Y + 275));
            option.LoadContent(Tiles.PauseMenu, 3, 5, 3);
        }

        public override void Update(GameTime gameTime)
        {
            if (resume.IsClicked())
                G.currentGame.Pop();
            else if (option.IsClicked())
                G.currentGame.Push(new OptionsMenu());
            else if (exit.IsClicked())
            {
                G.currentGame.Clear();
                G.currentGame.Push(new Menu());
            }
            if (E.IsPushed(Keys.Escape))
                G.currentGame.Push(new Main());
        }

        public override void Draw()
        {
            fond_menu.Draw();
            resume.Draw();
            exit.Draw();
            option.Draw();
        }
    }
}
