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
    public static class FightRecap
    {
        private static SpriteBatch spriteBatch;
        private static Entity fond;
        private static Button exit;


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public static void Initialize(SpriteBatch spriteBatch)
        {
            FightRecap.spriteBatch = spriteBatch;
            fond = new Entity();
            fond.Initialize(new Pos(C.Screen.Width / 2, C.Screen.Height / 2));
            fond.LoadContent(1, ref G.recapTiles, Center.All);

            exit = new Button();
            exit.Initialize(new Pos(fond.Position.X + 70, fond.Position.Y + 370));
            exit.LoadContent(2, 2, 2, ref G.recapTiles);


            // TODO: Add your initialization logic here

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static void Update(GameTime gameTime)
        {
            E.Update();
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
        public static void Draw()
        {
            fond.Draw(spriteBatch);
            exit.Draw(spriteBatch);
            spriteBatch.DrawString(G.vie, (Hero.Life/100).ToString() + "/100", new Vector2(fond.Position.X + 120, fond.Position.Y + 165), Color.Red);
            spriteBatch.DrawString(G.vie, "37", new Vector2(fond.Position.X + 162, fond.Position.Y + 233), Color.Yellow);
            spriteBatch.DrawString(G.vie, "75", new Vector2(fond.Position.X + 162, fond.Position.Y + 308), Color.Green);
            // TODO: Add your drawing code here
        }
    }
}
