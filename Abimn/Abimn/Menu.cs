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
    public class Menu : GameType
    {
        private Button jouer;
        private Button options;
        private Button quitter;
        private Entity background;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public Menu() : base(true)
        {
            Hero.LifeMax = 10000;
            Hero.Life = 10000;

            jouer = new Button(new Pos((int)(C.Screen.Width * 0.1), (int)(C.Screen.Height * 0.40)));
            jouer.LoadContent(1, 2, 1, Tiles.Button);

            options = new Button(new Pos((int)(C.Screen.Width * 0.1), (int)(C.Screen.Height * 0.55)));
            options.LoadContent(3, 4, 3, Tiles.Button);

            quitter = new Button(new Pos((int)(C.Screen.Width * 0.1), (int)(C.Screen.Height * 0.70)));
            quitter.LoadContent(5, 6, 5, Tiles.Button);

            background = new Entity();
            background.LoadContent(7, Tiles.Button);


            // TODO: Add your initialization logic here
            // G.currentGame.Push(CurrentGame.HeroCreator);
            // HeroCreator.Initialize(spriteBatch);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (quitter.mouseOver() && E.LeftIsReleased())
                G.currentGame.Clear();

            if (options.mouseOver() && E.LeftIsReleased())
                G.currentGame.Push(new OptionsMenu());
            if (jouer.mouseOver() && E.LeftIsReleased())
                G.currentGame.Push(new HeroCreator());

            // G.currentGame.Pop();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw()
        {
            background.Draw();
            jouer.Draw();
            options.Draw();
            quitter.Draw();
        }
    }
}
