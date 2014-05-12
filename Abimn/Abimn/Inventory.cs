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
    /// Inventaire
    /// </summary>
    public class Inventory : GameType
    {
        private Entity armor, weapons, div, quest, cons;
        private Entity _inv, shit, overshit;

        public Inventory() : base(false)
        {
            Cursor.SetVisibility(true);
            armor = new Entity(new Pos(230, 14));
            armor.LoadContent(Tiles.Inventory, 2, 3, 3);

            weapons = new Entity(new Pos(260, 15));
            weapons.LoadContent(Tiles.Inventory, 10, 11, 11);

            div = new Entity(new Pos(314, 13));
            div.LoadContent(Tiles.Inventory, 6, 7, 7);

            quest = new Entity(new Pos(340, 16));
            quest.LoadContent(Tiles.Inventory, 8, 9, 9);

            cons = new Entity(new Pos(287, 8));
            cons.Initialize();
            cons.LoadContent(Tiles.Inventory, 4, 5, 5);

            _inv = new Entity(new Pos(15, 10));
            _inv.LoadContent(Tiles.Inventory, 1);

            shit = new Entity(new Pos(225, 50), false);
            shit.LoadContent(Tiles.Inventory, 12);

            overshit = new Ennemy(new Pos(225, 50), false);
            overshit.LoadContent(Tiles.Inventory, 13);
        }

        public override void Update(GameTime gameTime)
        {
            if (armor.IsClicked())
                shit.Visible = true;
            if (weapons.IsClicked())
                overshit.Visible = true;
            if (cons.IsClicked() || armor.IsClicked())
                overshit.Visible = false;

            if (E.IsPushed(Keys.Escape) || E.IsPushed(Keys.I))
                G.currentGame.Pop();
        }

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
        }
    }
}
