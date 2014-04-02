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
    public static class Menu
    {
        private static SpriteBatch spriteBatch;
        private static Button jouer;
        private static Button options;
        private static Button quitter;
        private static Entity background;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public static void Initialize(SpriteBatch spriteBatch)
        {
            Hero.LifeMax = 10000;
            Hero.Life = 10000;

            Menu.spriteBatch = spriteBatch;

            jouer = new Button();
            jouer.Initialize(new Pos((int)(C.Screen.Width * 0.1), (int)(C.Screen.Height * 0.40)));
            jouer.LoadContent(1, 2, 1, ref G.buttonTiles);

            options = new Button();
            options.Initialize(new Pos((int)(C.Screen.Width * 0.1), (int)(C.Screen.Height * 0.55)));
            options.LoadContent(3, 4, 3, ref G.buttonTiles);

            quitter = new Button();
            quitter.Initialize(new Pos((int)(C.Screen.Width * 0.1), (int)(C.Screen.Height * 0.70)));
            quitter.LoadContent(5, 6, 5, ref G.buttonTiles);

            background = new Entity();
            background.Initialize(new Pos());
            background.LoadContent(7, ref G.buttonTiles);


            // TODO: Add your initialization logic here
            // G.currentGame.Push(CurrentGame.HeroCreator);
            // HeroCreator.Initialize(spriteBatch);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static void Update(GameTime gameTime)
        {
            E.Update();

            if (quitter.mouseOver() && E.LeftIsReleased())
                G.currentGame.Clear();

            if (options.mouseOver() && E.LeftIsReleased())
            {
                G.currentGame.Push(CurrentGame.OptionsMenu);
                OptionsMenu.Initialize(spriteBatch);
            }
            if (jouer.mouseOver() && E.LeftIsReleased())
            {
                G.currentGame.Push(CurrentGame.HeroCreator);
                HeroCreator.Initialize(spriteBatch);
            }

            // G.currentGame.Pop();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public static void Draw()
        {
            background.Draw(spriteBatch);
            jouer.Draw(spriteBatch);
            options.Draw(spriteBatch);
            quitter.Draw(spriteBatch);
        }
    }
}
