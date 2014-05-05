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
    public class Main : GameType
    {
        private Map _backmap;
        private Pos _poshero;
        private int _idhero;
        float _timeSinceMove = 0f;
        float _timeSinceStart = 0f;



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public Main()
            : base(true)
        {
            this._poshero = new Pos(8, 6);
            this._backmap = new Map();
            this._idhero = 4;


            // TODO: Add your initialization logic here
            /*  G.currentGame.Push(CurrentGame.PauseMenu);
              G.currentGame.Push(CurrentGame.Fight);*/
        }

        /// <summary>
        /// permet de bouger le HERO d'une case à l'autre en fonction de la touche
        /// fonctionne avec zqsd et flèches(haut, bas, gauche, droite)
        /// </summary>
        public void MoveHeros()
        {
            _timeSinceMove = 0f;

            if (E.IsPushed(Keys.Q) || E.IsPushed(Keys.Left) || E.IsDown(Keys.Q) || E.IsDown(Keys.Left))
            {
                Pos NextStep = new Pos(_poshero.X - 1, _poshero.Y);
                if (_backmap.CanMoveOn(NextStep))
                { _poshero.X = _poshero.X - 1; }
            }

            if (E.IsPushed(Keys.D) || E.IsPushed(Keys.Right) || E.IsDown(Keys.D) || E.IsDown(Keys.Right))
            {
                Pos NextStep = new Pos(_poshero.X + 1, _poshero.Y);
                if (_backmap.CanMoveOn(NextStep))
                { _poshero.X = _poshero.X + 1; }
            }
            if (E.IsPushed(Keys.Z) || E.IsPushed(Keys.Up) || E.IsDown(Keys.Z) || E.IsDown(Keys.Up))
            {
                Pos NextStep = new Pos(_poshero.X, _poshero.Y - 1);
                if (_backmap.CanMoveOn(NextStep))
                { _poshero.Y = _poshero.Y - 1; }
            }
            if (E.IsPushed(Keys.S) || E.IsPushed(Keys.Down) || E.IsDown(Keys.S) || E.IsDown(Keys.Down))
            {
                Pos NextStep = new Pos(_poshero.X, _poshero.Y + 1);
                if (_backmap.CanMoveOn(NextStep))
                { _poshero.Y = _poshero.Y + 1; }
            }
        }














        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            _timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timeSinceStart += (float)gameTime.TotalGameTime.TotalSeconds;


            //Change CurrentGame
            if (E.IsPushed(Keys.Escape))
                G.currentGame.Push(new PauseMenu());

            if (E.IsPushed(Keys.I))
                G.currentGame.Push(new Inventory());

            if (_backmap.Decoration(_poshero) == 1)
            {
                G.currentGame.Push(new Fight());
                _backmap.SetCell(_poshero, new Cell(false, 1, 0));
            }


            if (E.IsDown(Keys.B)) //courrir
            {
                if (_timeSinceMove > 0.15f)//règle la vitesse de défilement
                    MoveHeros(); //Vérifie les touches de mouvements

            }

            else
            {
                if (_timeSinceMove > 0.3f)//règle la vitesse de défilement
                    MoveHeros(); //Vérifie les touches de mouvements
            }



            //mouv NPCs

            //mouv ennemys

            //check 4 cases autour du Heros + press espace = interaction

            //check présence ennemys pour lancer Fight: dans la classe ennemy en fonction de l'ennemy? post figth: unload?

            /* G.currentGame.Pop();
             Main.UnloadContent();*/
        }





        /// <summary>
        /// permet de bouger le HERO sans changer de case
        /// A utiliser pour bouger de façon continue et fluide
        /// </summary>
        public void DrawMoveHeros(Entity EntHero)
        {

            if (E.IsPushed(Keys.Q) || E.IsPushed(Keys.Left) || E.IsDown(Keys.Q) || E.IsDown(Keys.Left))
            {
                _idhero = 1;
                EntHero.Position.X -= 5;
            }
            if (E.IsPushed(Keys.D) || E.IsPushed(Keys.Right) || E.IsDown(Keys.D) || E.IsDown(Keys.Right))
            {
                _idhero = 2;
                EntHero.Position.X += 5;
            }
            if (E.IsPushed(Keys.Z) || E.IsPushed(Keys.Up) || E.IsDown(Keys.Z) || E.IsDown(Keys.Up))
            {
                _idhero = 3;
                EntHero.Position.Y -= 5;
            }
            if (E.IsPushed(Keys.S) || E.IsPushed(Keys.Down) || E.IsDown(Keys.S) || E.IsDown(Keys.Down))
            {
                _idhero = 4;
                EntHero.Position.Y += 5;
            }
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw()
        {
            _backmap.Draw(_poshero);
            Entity EntityHero = new Entity(new Pos((8 * 50), (6 * 50)));



            EntityHero.LoadContent(_idhero, Tiles.Hero);
            DrawMoveHeros(EntityHero);
            EntityHero.Draw();
            base.Draw();
        }
    }
}