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
    public class FightRecap : GameType
    {
        private Entity fond;
        private Button exit;


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public FightRecap() : base(false)
        {
            fond = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2));
            fond.LoadContent(1, Tiles.Recap, Center.All);

            exit = new Button(new Pos(fond.Pos.X + 70, fond.Pos.Y + 370));
            exit.LoadContent(2, 2, 2, Tiles.Recap);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (E.LeftIsReleased() & exit.mouseOver())
            {
                G.currentGame.Pop();
                G.currentGame.Pop();
            }

            // TODO: Add your update logic here

            //G.currentGame.Pop();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw()
        {
            fond.Draw();
            exit.Draw();
            G.spriteBatch.DrawString(G.vie, (Hero.Life/100).ToString() + "/100", new Vector2(fond.Pos.X + 120, fond.Pos.Y + 165), Color.Red);
            G.spriteBatch.DrawString(G.vie, "37", new Vector2(fond.Pos.X + 162, fond.Pos.Y + 233), Color.Yellow);
            G.spriteBatch.DrawString(G.vie, "75", new Vector2(fond.Pos.X + 162, fond.Pos.Y + 308), Color.Green);
            // TODO: Add your drawing code here
        }
    }
}
