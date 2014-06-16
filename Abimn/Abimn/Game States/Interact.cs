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

namespace Abimn.Game_States
{
    class Interact: GameType
    {
        private Entity fond_interact;
        private Color color_font;
        private Vector2 vect;


        public Interact() : base(false) { }

        public override void Initialize()
        {
            Cursor.SetVisibility(true);

            fond_interact = new Entity();
            fond_interact.Initialize(new Pos(fond_interact.Pos.X,fond_interact.Pos.Y+ 470));
            fond_interact.LoadContent("interact", "boite_dialogue");

            color_font = Color.White;
            vect.X = 30;
            vect.Y = 500;
        }

        public override void Update(GameTime gameTime)
        {

            if (E.IsPushed(Keys.Escape))
                this.State = State.Exit;

            if (E.IsPushed(Keys.Space))
                this.State = State.Exit;
        }

        public override void Draw()
        {
            fond_interact.Draw();
            Text.Write("vie", "Bonjour voyageur!", vect, color_font);
        }
    }
}



