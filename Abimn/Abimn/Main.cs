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
    public static class Main
    {
        private static SpriteBatch spriteBatch;
        private static Map _backmap;
        private static Pos _poshero;
        private static int _idhero;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public static void Initialize(SpriteBatch spriteBatch)
        {
            Main.spriteBatch = spriteBatch;
            Main._poshero = new Pos(8, 6);
            Main._backmap = new Map();
            Main._idhero = 4;

            // TODO: Add your initialization logic here
            /*  G.currentGame.Push(CurrentGame.PauseMenu);
              G.currentGame.Push(CurrentGame.Fight);*/
        }

        /// <summary>
        /// permet de bouger le HERO d'une case à l'autre en fonction de la touche
        /// fonctionne avec zqsd et flèches(haut, bas, gauche, droite)
        /// </summary>
        public static void MoveHeros()
        {
            if (E.IsPushed(Keys.Q) || E.IsPushed(Keys.Left) || /*E.IsDown(Keys.Q) ||*/ E.IsDown(Keys.Left))
            {
                Pos NextStep = new Pos(_poshero.X - 1, _poshero.Y);
                _idhero = 1;

                if (_backmap.CanMoveOn(NextStep))
                { _poshero.X = _poshero.X - 1; }
            }
            if (E.IsPushed(Keys.D) || E.IsPushed(Keys.Right) || /*E.IsDown(Keys.D) ||*/ E.IsDown(Keys.Right))
            {
                Pos NextStep = new Pos(_poshero.X + 1, _poshero.Y);
                _idhero = 2;

                if (_backmap.CanMoveOn(NextStep))
                { _poshero.X = _poshero.X + 1; }
            }
            if (E.IsPushed(Keys.Z) || E.IsPushed(Keys.Up) || /*E.IsDown(Keys.Z) ||*/ E.IsDown(Keys.Up))
            {
                Pos NextStep = new Pos(_poshero.X, _poshero.Y - 1);
                _idhero = 3;

                if (_backmap.CanMoveOn(NextStep))
                {
                    _poshero.Y = _poshero.Y - 1;
                }
            }
            if (E.IsPushed(Keys.S) || E.IsPushed(Keys.Down) || /*E.IsDown(Keys.S) ||*/ E.IsDown(Keys.Down))
            {
                Pos NextStep = new Pos(_poshero.X, _poshero.Y + 1);
                _idhero = 4;

                if (_backmap.CanMoveOn(NextStep))
                { _poshero.Y = _poshero.Y + 1; }
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static void Update(GameTime gameTime)
        {
            E.Update();

            if (E.IsPushed(Keys.Escape))
            {
                G.currentGame.Push(CurrentGame.PauseMenu);
                PauseMenu.Initialize(spriteBatch);
            }

            if (E.IsPushed(Keys.I))
            {
                G.currentGame.Push(CurrentGame.Inventory);
                Inventory.Initialize(spriteBatch);
            }

            if (_backmap.Decoration(_poshero) == 1)
            {
                G.currentGame.Push(CurrentGame.Fight);
                Fight.Initialize(spriteBatch);
                _backmap.SetCell(_poshero, new Cell(false, 1, 0));
            }

            MoveHeros(); //Vérifie les touches de mouvements

            //mouv NPCs

            //mouv ennemys

            //check 4 cases autour du Heros + press espace = interaction

            //check présence ennemys pour lancer Fight: dans la classe ennemy en fonction de l'ennemy? post figth: unload?

            /* G.currentGame.Pop();
             Main.UnloadContent();*/
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public static void Draw()
        {
            _backmap.Draw(spriteBatch, _poshero);

            /*((_poshero.X) * 50), ((_poshero.Y * 50)))*/

            Entity EntityHero = new Entity();
            EntityHero.Initialize(new Pos((8 * 50), (6 * 50)));
            EntityHero.LoadContent(_idhero, ref G.heroTiles);
            EntityHero.Draw(spriteBatch);
        }
    }
}