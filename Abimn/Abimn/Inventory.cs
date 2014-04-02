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
    public static class Inventory
    {
        private static Button armor, weapons, div, quest, cons;
        private static Entity _inv, shit, overshit;
        private static SpriteBatch spriteBatch;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public static void Initialize(SpriteBatch spriteBatch)
        {
            Inventory.spriteBatch = spriteBatch;

            armor = new Button();
            armor.Initialize(new Pos(230, 14));
            armor.LoadContent(2, 3, 3, ref G.inventoryTiles);

            weapons = new Button();
            weapons.Initialize(new Pos(260, 15));
            weapons.LoadContent(10, 11, 11, ref G.inventoryTiles);

            div = new Button();
            div.Initialize(new Pos(314, 13));
            div.LoadContent(6, 7, 7, ref G.inventoryTiles);
            quest = new Button();
            quest.Initialize(new Pos(340, 16));
            quest.LoadContent(8, 9, 9, ref G.inventoryTiles);

            cons = new Button();
            cons.Initialize(new Pos(287, 8));
            cons.LoadContent(4, 5, 5, ref G.inventoryTiles);

            _inv = new Entity();
            _inv.Initialize(new Pos(15, 10));
            _inv.LoadContent(1, ref G.inventoryTiles);

            shit = new Entity();
            shit.Initialize(new Pos(225, 50), false);
            shit.LoadContent(12, ref G.inventoryTiles);

            overshit = new Ennemy();
            overshit.Initialize(new Pos(225, 50), false);
            overshit.LoadContent(13, ref G.inventoryTiles);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static void Update(GameTime gameTime)
        {
            E.Update();
            if (E.LeftIsPushed() & armor.mouseOver())
                shit.Visible = true;
            if (E.LeftIsPushed() & weapons.mouseOver())
                overshit.Visible = true;
            if (E.LeftIsPushed() & (cons.mouseOver() | armor.mouseOver()))
                overshit.Visible = false;


            // TODO: Add your update logic here
            if (E.IsPushed(Keys.Escape) | E.IsPushed(Keys.I))
                G.currentGame.Pop();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public static void Draw()
        {
            _inv.Draw(spriteBatch);
            shit.Draw(spriteBatch);
            overshit.Draw(spriteBatch);

            armor.Draw(spriteBatch);
            weapons.Draw(spriteBatch);
            cons.Draw(spriteBatch);
            div.Draw(spriteBatch);
            quest.Draw(spriteBatch);

            // TODO: Add your drawing code here
        }
    }
}
