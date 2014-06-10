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
    /// Ecran de vue sur map
    /// </summary>
    public class Main : GameType
    {
        private Map _backmap;
        private Pos _poshero;
        private int _idhero;
        private int _idmap;
        float _timeSinceMove = 0f;
        float _timeSinceStart = 0f;
        private Pos _shift;
        private Entity EntityHero;

        public Main() : base(true) { }

        public override void Initialize()
        {
            MediaPlayer.Play(G.one);
            this._idmap = 1;
            this._backmap = new Map(_idmap);
            this._poshero = _backmap.StartPos;
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
                    _shift.X -= 3;
                else
                {
                    if (_shift.X <= 4)
                    {
                        _shift.X = 0;
                        EntityHero.Pos.X -= 5;
                    }
                    else
                        _shift.X -= 3;
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
                        if (_shift.X >= -4)
                        {
                            _shift.X = 0;
                            EntityHero.Pos.X += 5;
                        }
                        else
                            _shift.X += 3;
                    }
                }
                else
                {
                    if (E.IsPushed(Keys.Z) || E.IsPushed(Keys.Up) || E.IsDown(Keys.Z) || E.IsDown(Keys.Up))
                    {
                        _idhero = 3;
                        Pos NextStep = new Pos(_poshero.X, _poshero.Y - 1);
                        if (_backmap.CanMoveOn(NextStep))
                            _shift.Y -= 3;
                        else
                        {
                            if (_shift.Y <= 4)
                            {
                                _shift.Y = 0;
                                EntityHero.Pos.Y -= 5;
                            }
                            else
                                _shift.Y -= 3;
                        }
                    }
                    else
                    {
                        if (E.IsPushed(Keys.S) || E.IsPushed(Keys.Down) || E.IsDown(Keys.S) || E.IsDown(Keys.Down))
                        {
                            _idhero = 4;
                            Pos NextStep = new Pos(_poshero.X, _poshero.Y + 1);
                            if (_backmap.CanMoveOn(NextStep))
                                _shift.Y += 3;
                            else
                            {
                                if (_shift.Y >= -4)
                                {
                                    _shift.Y = 0;
                                    EntityHero.Pos.Y += 5;
                                }
                                else
                                    _shift.Y += 3;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ajustement de changement de case
        /// Necessaire pour des colisions nettes (plus ou moins)
        /// </summary>
        public void MoveTile()
        {
            if (_shift.X <= -25)
            {
                _shift.X = 25;
                _poshero.X--;
            }
            if (_shift.X >= 27)
            {
                _shift.X = -23;
                _poshero.X++;
            }
            if (_shift.Y <= -40)
            {
                _shift.Y = 10;
                _poshero.Y--;
            }
            if (_shift.Y >= 15)
            {
                _shift.Y = -35;
                _poshero.Y++;
            }
        }

        /// <summary>
        /// Regarde les trois cases en face du personnage
        /// Retourne vrai si elles sont occupées par un marchand
        /// </summary>
        public bool Interact()
        {
            Pos FrontTile = new Pos();

            if (FrontTile.X == 0 && FrontTile.X == 49)
            {
                if (_idhero == 1)
                    FrontTile = new Pos(_poshero.X - 1, _poshero.Y);
                if (_idhero == 2)
                    FrontTile = new Pos(_poshero.X + 1, _poshero.Y);
                if (_idhero == 3)
                    FrontTile = new Pos(_poshero.X, _poshero.Y + 1);
                if (_idhero == 4)
                    FrontTile = new Pos(_poshero.X, _poshero.Y - 1);
                if (FrontTile.X == 0 && FrontTile.X == 49 && _backmap.Decoration(FrontTile) == 4)
                    return true;
            }
            else
            {
                Pos FrontTileLeft = new Pos();
                Pos FrontTileRight = new Pos();
                Pos FrontTileFront = new Pos();

                if (_idhero == 1)
                {
                    FrontTile = new Pos(_poshero.X - 1, _poshero.Y);
                    FrontTileLeft = new Pos(FrontTile.X, FrontTile.Y - 1);
                    FrontTileRight = new Pos(FrontTile.X, FrontTile.Y + 1);
                    FrontTileFront = new Pos(FrontTile.X - 1, FrontTile.Y);
                }
                if (_idhero == 2)
                {
                    FrontTile = new Pos(_poshero.X + 1, _poshero.Y);
                    FrontTileLeft = new Pos(FrontTile.X, FrontTile.Y - 1);
                    FrontTileRight = new Pos(FrontTile.X, FrontTile.Y + 1);
                    FrontTileFront = new Pos(FrontTile.X + 1, FrontTile.Y);
                }
                if (_idhero == 4)
                {
                    FrontTile = new Pos(_poshero.X, _poshero.Y + 1);
                    FrontTileLeft = new Pos(FrontTile.X - 1, FrontTile.Y);
                    FrontTileRight = new Pos(FrontTile.X + 1, FrontTile.Y);
                    FrontTileFront = new Pos(FrontTile.X, FrontTile.Y + 1);
                }
                if (_idhero == 3)
                {
                    FrontTile = new Pos(_poshero.X, _poshero.Y - 1);
                    FrontTileLeft = new Pos(FrontTile.X - 1, FrontTile.Y);
                    FrontTileRight = new Pos(FrontTile.X + 1, FrontTile.Y);
                    FrontTileFront = new Pos(FrontTile.X, FrontTile.Y - 1);
                }

                if (_backmap.Decoration(FrontTile) == 5 ||
                    _backmap.Decoration(FrontTileLeft) == 5 ||
                    _backmap.Decoration(FrontTileRight) == 5 ||
                    _backmap.Decoration(FrontTileFront) == 5) //id du marchand pour la Soutenance2
                    return true;
            }
            return false;
        }



        /*  /// <summary>
          /// Appelle une nouvelle map
          /// </summary>
          public void Travel()
          {
              Pos HighTile = new Pos(_poshero.X, _poshero.Y + 1);
              if (_backmap.CanChangeMap(HighTile) && ( E.IsPushed(Keys.Up) || E.IsDown(Keys.Up)))
              {
                  if (_idmap == 1)
                  {
                      _idmap = 2;
                      _poshero = _backmap.StartPos;
                  }

                  else
                  {
                      _idmap = 1;
                      _poshero = new Pos(1, 7);
                  }

                  _idmap = 2;
                  _poshero = _backmap.StartPos;
                  _backmap = new Map(_idmap);
                  _idhero = _backmap.IdStartHero;
                  _shift = new Pos(0, 0);


                  //TODO: ajouter un freeze de quelques milisecondes pour recentrer le perso
              }
          }*/

        public override void Update(GameTime gameTime)
        {
            _timeSinceMove += (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timeSinceStart += (float)gameTime.TotalGameTime.TotalSeconds;
            EntityHero = new Entity(new Pos((9 * 50), (7 * 50)));

            Cursor.SetVisibility(false);
            //Change CurrentGame
            if (E.IsPushed(Keys.Escape))
                G.currentGame.Push(new PauseMenu());

            if (E.IsPushed(Keys.I))
                G.currentGame.Push(new Inventory());

            if (_backmap.Decoration(_poshero) == 2)
            {
                G.currentGame.Push(new Fight());
                _backmap.SetCell(_poshero, new Cell(false, 1, 0));
            }

            if (Interact() == true && E.IsPushed(Keys.Space))
                G.currentGame.Push(new Shop());

            //Change de map
            if (_backmap.Decoration(_poshero) == 3)
            {
                _idmap = 2;
                _backmap = new Map(_idmap);

                while (_timeSinceMove < 0.3f)
                {
                    _poshero = _backmap.StartPos;
                    _idhero = _backmap.IdStartHero;
                    _shift = new Pos(0, 0);
                }
            }

            if (_backmap.Decoration(_poshero) == 4)
            {
                _idmap = 1;
                _backmap = new Map(_idmap);
                _poshero = _backmap.StartPos;
                _idhero = _backmap.IdStartHero;
                _shift = new Pos(0, 0);
            }


            //Deplacement
            if (E.IsDown(Keys.B)) //courrir
            {
                if (_timeSinceMove > 0.002f)//règle la vitesse de défilement
                    MoveHeros();
                MoveHeros();
                MoveHeros();//Vérifie les touches de mouvements, accumulation pour course (update trop proches)

            }

            else
            {
                if (_timeSinceMove > 0.01f)//règle la vitesse de défilement
                    MoveHeros(); //Vérifie les touches de mouvements
            }
            EntityHero.LoadContent("hero", _idhero.ToString());
            MoveTile();


            //mouv NPCs

            //mouv ennemys

            //check présence ennemys pour lancer Fight: dans la classe ennemy en fonction de l'ennemy? post figth: unload?
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw()
        {
            _backmap.Draw(_poshero, _shift);
            EntityHero.Draw();
            base.Draw();
        }
    }
}