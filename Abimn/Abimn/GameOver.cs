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
    public class GameOver : GameType
    {
        private Entity fond;
        private Button exit;


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public GameOver() : base(true)
        {
            fond = new Entity();
            fond.LoadContent(7, Tiles.Fight);

            exit = new Button(new Pos(C.Screen.Width / 2, 400));
            exit.LoadContent(2, 2, 2, Tiles.Recap, Center.All);


            // TODO: Add your initialization logic here

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
                G.currentGame.Clear();
                G.currentGame.Push(new Menu());
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
            // TODO: Add your drawing code here
        }
    }
}
