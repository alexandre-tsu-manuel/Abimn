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
    /// Ecran de fin de jeu
    /// </summary>
    public class GameOver : GameType
    {
        private Entity background;
        private Entity exit;

        public GameOver() : base(true) { }

        public override void Initialize()
        {
            background = new Entity();
            background.LoadContent(Tiles.Fight, 7);

            exit = new Entity(new Pos(C.Screen.Width / 2, 400));
            exit.LoadContent(Tiles.Recap, 2, 2, 2, Center.All);
        }

        public override void Update(GameTime gameTime)
        {
            if (exit.IsClicked())
            {
                G.currentGame.Clear();
                G.currentGame.Push(new Menu());
            }
        }

        public override void Draw()
        {
            background.Draw();
            exit.Draw();
        }
    }
}
