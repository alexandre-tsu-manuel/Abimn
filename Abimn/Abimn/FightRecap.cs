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
    /// Récapitulatif du combat
    /// </summary>
    public class FightRecap : GameType
    {
        private Entity fond;
        private Entity exit;

        public FightRecap() : base(false)
        {
            fond = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2));
            fond.LoadContent(Tiles.Recap, 1, 1, 1, Center.All);

            exit = new Entity(new Pos(fond.Pos.X + 70, fond.Pos.Y + 370));
            exit.LoadContent(Tiles.Recap, 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (exit.IsClicked())
            {
                G.currentGame.Pop();
                G.currentGame.Pop();
            }
        }

        public override void Draw()
        {
            fond.Draw();
            exit.Draw();
            G.spriteBatch.DrawString(G.vie, (Hero.Life/100).ToString() + "/100", new Vector2(fond.Pos.X + 120, fond.Pos.Y + 165), Color.Red);
            G.spriteBatch.DrawString(G.vie, "37", new Vector2(fond.Pos.X + 162, fond.Pos.Y + 233), Color.Yellow);
            G.spriteBatch.DrawString(G.vie, "75", new Vector2(fond.Pos.X + 162, fond.Pos.Y + 308), Color.Green);
        }
    }
}
