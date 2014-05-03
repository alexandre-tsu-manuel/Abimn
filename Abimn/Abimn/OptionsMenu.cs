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
    public class OptionsMenu : GameType
    {

        private Button sonEnabled;
        private Button sonDisabled;
        private Button retour;
        private Entity background;

        bool son; // vrai si l'utilisateur veux entendre de la musique.

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public OptionsMenu() : base(false)
        {
            background = new Entity(new Pos(C.Screen.Width/2, C.Screen.Height/2));
            background.LoadContent(1, Tiles.Button2, Center.All);

            sonEnabled = new Button(new Pos(background.Pos.X + background.Rect.Width / 2, background.Pos.Y + background.Rect.Height / 2));
            sonEnabled.LoadContent(2, 3, 2, Tiles.Button2, Center.All);

            sonDisabled = new Button(sonEnabled.Pos, false);
            sonDisabled.LoadContent(4, 5, 4, Tiles.Button2);

            retour = new Button(new Pos(background.Pos.X + background.Rect.Width / 2, background.Pos.Y + background.Rect.Height / 2 + 100));
            retour.LoadContent(2, 6, 2, Tiles.PauseMenu, Center.All);

            son = true; // de base, la musique est activee
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (retour.mouseOver() && E.LeftIsReleased())
                G.currentGame.Pop();

            if (sonEnabled.mouseOver() && E.LeftIsReleased() && sonEnabled.Visible)
            {
                sonEnabled.Visible = false;
                sonDisabled.Visible = true;
                son = false;
            }
            else if (sonDisabled.mouseOver() && E.LeftIsReleased() && sonDisabled.Visible)
            {
                sonEnabled.Visible = true;
                sonDisabled.Visible = false;
                son = true;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw()
        {
            background.Draw();
            sonEnabled.Draw();
            sonDisabled.Draw();
            retour.Draw();
            
        }
    }
}
