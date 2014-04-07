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
    public class Inventory : GameType
    {
        private Button armor, weapons, div, quest, cons;
        private Entity _inv, shit, overshit;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public Inventory() : base(false)
        {
            armor = new Button(new Pos(230, 14));
            armor.LoadContent(2, 3, 3, Tiles.Inventory);

            weapons = new Button(new Pos(260, 15));
            weapons.LoadContent(10, 11, 11, Tiles.Inventory);

            div = new Button(new Pos(314, 13));
            div.LoadContent(6, 7, 7, Tiles.Inventory);

            quest = new Button(new Pos(340, 16));
            quest.LoadContent(8, 9, 9, Tiles.Inventory);

            cons = new Button(new Pos(287, 8));
            cons.Initialize();
            cons.LoadContent(4, 5, 5, Tiles.Inventory);

            _inv = new Entity(new Pos(15, 10));
            _inv.LoadContent(1, Tiles.Inventory);

            shit = new Entity(new Pos(225, 50), false);
            shit.LoadContent(12, Tiles.Inventory);

            overshit = new Ennemy(new Pos(225, 50), false);
            overshit.LoadContent(13, Tiles.Inventory);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
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
        public override void Draw()
        {
            _inv.Draw();
            shit.Draw();
            overshit.Draw();

            armor.Draw();
            weapons.Draw();
            cons.Draw();
            div.Draw();
            quest.Draw();

            // TODO: Add your drawing code here
        }
    }
}
