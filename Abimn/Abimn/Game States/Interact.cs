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
        private int _idtext;
        private string talk;
        public int conv;


        public Interact(int n)
            : base(false)
        {
            conv = n;
        }

        public override void Initialize()
        {
            Cursor.SetVisibility(true);

            fond_interact = new Entity();
            fond_interact.Initialize(new Pos(fond_interact.Pos.X, fond_interact.Pos.Y+ 470));
            fond_interact.LoadContent("interact", "boite_dialogue");


            talk = "";
            _idtext = 1;
            color_font = Color.White;
            vect.X = 30;
            vect.Y = 500;
        }

        public string Choice(int conv)
        {
            switch (conv)
            {
            case 1: switch (_idtext)
            {
                case 1: return "Ou suis-je?";
                case 2: return "Le noir... \n Impossible de me souvenir d'autre chose...";
                case 3: return "Qui suis-je?";
                case 4: return "Il ne me reste rien. Meme pas un nom...";
                case 5: return "Mais... J'entends du bruit au loin... Il y a quelqu'un?";
                default:
                    return "";

            }
                default:
                return "";
            }
            
        }

        public override void Update(GameTime gameTime)
        {
            talk = Choice(conv);

            if (E.IsPushed(Keys.Escape))
                this.State = State.Exit;

            if (E.IsPushed(Keys.Space))
                _idtext++;

            if (talk == "")
                this.State = State.Exit;
        }

        



        public override void Draw()
        {
            fond_interact.Draw();
            Text.Write("vie", talk, vect, color_font);
        }
    }
}



