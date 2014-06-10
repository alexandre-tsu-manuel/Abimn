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

        public Inventory() : base(false) { }

        public override void Initialize()
        {
            Cursor.SetVisibility(true);
            armor = new Entity(new Pos(230, 14));
            armor.LoadContent("inventory", "2", "3", "3");

            weapons = new Entity(new Pos(260, 15));
            weapons.LoadContent("inventory", "10", "11", "11");

            div = new Entity(new Pos(314, 13));
            div.LoadContent("inventory", "6", "7", "7");

            quest = new Entity(new Pos(340, 16));
            quest.LoadContent("inventory", "8", "9", "9");

            cons = new Entity(new Pos(287, 8));
            cons.Initialize();
            cons.LoadContent("inventory", "4", "5", "5");

            _inv = new Entity(new Pos(15, 10));
            _inv.LoadContent("inventory", "1");

            shit = new Entity(new Pos(225, 50), false);
            shit.LoadContent("inventory", "12");

            overshit = new Ennemy(new Pos(225, 50), false);
            overshit.LoadContent("inventory", "13");
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
                this.State = State.Exit;
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
