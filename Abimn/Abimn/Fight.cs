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
    public class Fight : GameType
    {
        private Entity _hero;
        private int movinTill = 0;
        private int heroAttack = 20;
        private int ennemyAttack = 100;
        private Ennemy _ennemy;
         
        private FightMap _map;
        private bool _fightContact;
        private bool _jumping;
        private bool movinRight;

        private Pos renardDelta;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public Fight() : base(true)
        {
            MediaPlayer.Play(G.two);
            Cursor.SetVisibility(false);
            _hero = new Entity(new Pos(C.Screen.Width/2 - 25, 420));
            _ennemy = new Ennemy(new Pos(550, 412), new Vector2(-1, 0), 0.02F);

            _map = new FightMap();
            _hero.LoadContent(1, Tiles.Fight);
            _ennemy.LoadContent(3, Tiles.Fight);
            _ennemy.Life = 10000;

            _fightContact = false;
            _jumping = false;
            /*
            G.currentGame.Push(CurrentGame.FightRecap);
            FightRecap.Initialize(spriteBatch);/**/
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// +
        /// 
        


        public void moveHero()
        {
            if (E.IsDown(Keys.Right))
            {
                movinTill++;
                movinRight = true;
                _hero.Pos += new Vector2(2, 0);
            }
            else if (E.IsDown(Keys.Left))
            {
                movinTill++;
                movinRight = false;
                _hero.Pos += new Vector2(-2, 0);
            }
            else
                movinTill = 0;
            if (E.IsPushed(Keys.Space) && heroAttack == 20)
                heroAttack--;
            if (heroAttack < 20)
            {
                int movStep = heroAttack;
                if (movStep > 16)
                    movStep = 7;
                else
                    movStep = 8;
                if (!movinRight)
                    movStep += 2;
                _hero.LoadContent(movStep, Tiles.NewHero);
            }
            else
            {
                if (movinTill == 0)
                    _hero.LoadContent(movinRight ? 1 : 4, Tiles.NewHero);
                else
                {
                    int movStep = movinTill / 3 % 4;
                    if (movStep == 3)
                        movStep -= 2;
                    _hero.LoadContent((movinRight ? 1 : 4) + movStep, Tiles.NewHero);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            _ennemy.Pos = _ennemy.Pos + getDirection(_ennemy, _hero, Math.Abs(_ennemy.Pos.X - _hero.Pos.X) > 40);
            moveHero();

            if (Math.Abs(_ennemy.Pos.X - _hero.Pos.X) <= 40 && ennemyAttack == 100)
                ennemyAttack--;
            if (ennemyAttack < 100)
                ennemyAttack--;
            if (ennemyAttack == 0)
                ennemyAttack = 100;
            if (ennemyAttack == 90)
                Hero.Life -= 1000;
            if (ennemyAttack == 100)
                renardDelta = new Pos(0);
            else if (ennemyAttack >= 90)
                renardDelta = new Pos(ennemyAttack - 100, -ennemyAttack % 10);
            /*else if (ennemyAttack > 80)
                renardDelta = new Pos(ennemyAttack - 100, -10 + (10 - ennemyAttack % 10));
            /*else if (ennemyAttack > 70)
                renardDelta = new Pos(100 - ennemyAttack - 30, 0);
            else if (ennemyAttack > 60)
                renardDelta = new Pos(-70 + ennemyAttack, 0);*/
            else
                renardDelta = new Pos();

            if (heroAttack < 20)
                heroAttack--;
            if (heroAttack == 0)
                heroAttack = 20;

            if (heroAttack == 10 && Math.Abs(_ennemy.Pos.X - _hero.Pos.X) < 50)
                _ennemy.Life -= 10000 / 14;

            if (Hero.Life <= 0)
            {
                Hero.Life = 0;
                Cursor.SetVisibility(true);
                G.currentGame.Push(new GameOver());
            }
            if (_ennemy.Life <= 0)
            {
                _ennemy.Life = 0;
                Cursor.SetVisibility(true);
                G.currentGame.Push(new FightRecap());
            }
            /*
            _ennemy.Update(gameTime);
            if (_ennemy.Pos.X < _hero.Pos.X + 50)
            {
                _ennemy.Speed = 0;
                _fightContact = true;
            }

            if (E.IsPushed(Keys.Escape))
                G.currentGame.Push(new PauseMenu());
            if (E.IsPushed(Keys.I))
            {
                G.currentGame.Push(new Inventory());
            }
            if (E.IsDown(Keys.Right))
            {
                _hero.LoadContent(1, Tiles.Fight);
                _hero.Pos.X++;
            }
            if (E.IsDown(Keys.Left))
            {
                _hero.LoadContent(2, Tiles.Fight);
                _hero.Pos.X--;
            }
            if (!_jumping && E.IsPushed(Keys.Space))
            {
                _jumping = true;
            }
            else if (E.IsReleased(Keys.Left) || E.IsReleased(Keys.Right))
                _hero.Speed = 0;

            //_hero.Update(gameTime);
             */

        }

        public Vector2 getDirection(Entity needMove, Entity e2, bool move)
        {
            Vector2 left = new Vector2(-1, 0f);
            Vector2 right = new Vector2(1, 0f);
            if (move)
            {
                if (needMove.Pos.X < e2.Pos.X)
                {
                    needMove.LoadContent(10, Tiles.Fight);
                    return right;
                }
                else if (needMove.Pos.X > e2.Pos.X)
                {
                    needMove.LoadContent(3, Tiles.Fight);
                    return left;
                }
                else
                    return new Vector2(0, 0);
            }
            else
                return new Vector2(0, 0);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw()
        {
            _map.Draw();
            _ennemy.Draw(renardDelta);
            _hero.Draw();
            G.spriteBatch.DrawString(G.vie, (Hero.Life / 100).ToString() + "/100", new Vector2(10, 10), Color.Red);
            G.spriteBatch.DrawString(G.vie, (_ennemy.Life / 100).ToString() + "/100", new Vector2(750, 10), Color.Red);
        }
    }
}
