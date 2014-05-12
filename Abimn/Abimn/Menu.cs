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
    /// Menu principal
    /// </summary>
    public class Menu : GameType
    {
        private Entity play;
        private Entity options;
        private Entity quit;
        private Entity background;

        public Menu() : base(true)
        {
            MediaPlayer.Play(G.one);
            Hero.LifeMax = 10000;
            Hero.Life = 10000;
            Cursor.SetVisibility(true);

            play = new Entity(new Pos(C.Screen.Width * 0.15, C.Screen.Height * 0.30));
            play.LoadContent(Tiles.Button, 1, 2, 1);

            options = new Entity(new Pos(C.Screen.Width * 0.15, C.Screen.Height * 0.45));
            options.LoadContent(Tiles.Button, 3, 4, 3);

            quit = new Entity(new Pos(C.Screen.Width * 0.15, C.Screen.Height * 0.60));
            quit.LoadContent(Tiles.Button, 5, 6, 5);

            background = new Entity();
            background.LoadContent(Tiles.Button, 7);
        }

        public override void Update(GameTime gameTime)
        {
            if (quit.MouseIsOver() && E.LeftIsReleased())
                G.currentGame.Clear();

            if (options.MouseIsOver() && E.LeftIsReleased())
                G.currentGame.Push(new OptionsMenu());
            if (play.MouseIsOver() && E.LeftIsReleased())
                G.currentGame.Push(new HeroCreator());
        }

        public override void Draw()
        {
            background.Draw();
            play.Draw();
            options.Draw();
            quit.Draw();
        }
    }
}
