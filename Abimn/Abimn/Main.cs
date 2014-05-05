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
        private Pos _shift;
        private Entity EntityHero;



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public Main()
            : base(true)
        {
            this._poshero = new Pos(9, 7);
            this._backmap = new Map();
            this._idhero = 4;
            this._shift = new Pos();
            EntityHero = new Entity(new Pos((9 * 50), (7 * 50)));
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
                _idhero = 1;
                Pos NextStep = new Pos(_poshero.X - 1, _poshero.Y);
                if (_backmap.CanMoveOn(NextStep))
                { _shift.X -= 3; }

                else
                {
                    _shift.X = 0;
                    EntityHero.Pos.X -= 5;
                }


            }

            else
            {
                if (E.IsPushed(Keys.D) || E.IsPushed(Keys.Right) || E.IsDown(Keys.D) || E.IsDown(Keys.Right))
                {
                    _idhero = 2;
                    Pos NextStep = new Pos(_poshero.X + 1, _poshero.Y);
                    if (_backmap.CanMoveOn(NextStep))
                    { _shift.X += 3; }

                    else
                    {
                        _shift.X = 0;
                        EntityHero.Pos.X += 5;
                    }
                }
                else
                {
                    if (E.IsPushed(Keys.Z) || E.IsPushed(Keys.Up) || E.IsDown(Keys.Z) || E.IsDown(Keys.Up))
                    {
                        _idhero = 3;
                        Pos NextStep = new Pos(_poshero.X, _poshero.Y - 1);
                        if (_backmap.CanMoveOn(NextStep))
                        { _shift.Y -= 3; }

                        else
                        {
                            _shift.Y = 0;
                            EntityHero.Pos.Y -= 5;
                        }
                    }
                    else
                    {
                        if (E.IsPushed(Keys.S) || E.IsPushed(Keys.Down) || E.IsDown(Keys.S) || E.IsDown(Keys.Down))
                        {
                            _idhero = 4;
                            Pos NextStep = new Pos(_poshero.X, _poshero.Y + 1);
                            if (_backmap.CanMoveOn(NextStep))
                            { _shift.Y += 3; }

                            else
                            {
                                _shift.Y = 0;
                                EntityHero.Pos.Y += 5;
                            }
                        }
                    }
                }
            }
        }
       



        public void MoveTile()
        {
            if (_shift.X <= -30)
            {
                _shift.X = 20;
                _poshero.X--;
            }

            if (_shift.X >= 30)
            {
                _shift.X = -20;
                _poshero.X++;
            }

            if (_shift.Y <= -50)
            {
                _shift.Y = 0;
                _poshero.Y--;
            }

            if (_shift.Y >= 10)
            {
                _shift.Y = -40;
                _poshero.Y++;
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
            EntityHero = new Entity(new Pos((9 * 50), (7 * 50)));

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
                if (_timeSinceMove > 0.002f)//règle la vitesse de défilement
                    MoveHeros(); //Vérifie les touches de mouvements

            }

            else
            {
                if (_timeSinceMove > 0.01f)//règle la vitesse de défilement
                    MoveHeros(); //Vérifie les touches de mouvements
            }
            EntityHero.LoadContent(_idhero, Tiles.Hero);
            MoveTile();


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
        public override void Draw()
        {
            _backmap.Draw(_poshero, _shift);
<<<<<<< HEAD
=======
            Entity EntityHero = new Entity(new Pos((9 * 50), (7 * 50)));
            EntityHero.LoadContent(_idhero, Tiles.Hero);
            DrawMoveHeros(EntityHero);
>>>>>>> 472f81002a79529938dc45fe4cecab49b5b60918
            EntityHero.Draw();
            base.Draw();
        }
    }
}