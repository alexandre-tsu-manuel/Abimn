using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
        private Entity _background, _background2;
        private bool movinRight;

        private Entity _fireball;
        private Entity _ennemyFireball;

        public Fight() : base(true) { }

        public override void Initialize()
        {
            Hero.Mana = 100;
            if (G.willFightBoss)
                Music.Play("boss");
            else
                Music.Play("monster");
            Cursor.SetVisibility(false);
            _hero = new Entity(new Pos(100, 400));
            _ennemy = new Ennemy(new Pos(800, 400));

            _map = new FightMap();
            _hero.LoadContent("fight", "1");
            _ennemy.LoadContent("fight", "3");
            _ennemy.Life = 10000;
            if (G.willFightBoss)
            {
                _ennemy.LoadContent("main deco/9");
                _ennemy.Life = 20000;
            }

            _background = new Entity();
            _background.LoadContent("fight/9");
            _background2 = new Entity(new Pos(0, 450));
            _background2.LoadContent("fight/9");

            _fireball = new Entity();
            _fireball.LoadContent("fight/fireball");
            _fireball.Visible = false;

            _ennemyFireball = new Entity();
            _ennemyFireball.LoadContent("fight/fireball");
            _fireball.Visible = false;
        }

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
                _hero.LoadContent("new hero", movStep.ToString());
            }
            else
            {
                if (movinTill == 0)
                    _hero.LoadContent("new hero", movinRight ? "right0" : "left0");
                else
                {
                    int movStep = movinTill / 3 % 4;
                    if (movStep == 3)
                        movStep -= 2;
                    _hero.LoadContent("new hero", ((movinRight ? "right" : "left") + movStep).ToString());
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (_hero.Pos.I < -14)
            {
                _hero.Pos.I = -14;
                _hero.Movement = new Vector2(0, _hero.Movement.Y);
            }
            int heightByHero = _map.GetHeightByHero(_hero.Pos.I + 14);
            if (_hero.Pos.J + _hero.Rect.Height < C.Screen.Height - heightByHero)
                _hero.Movement = new Vector2(_hero.Movement.X, _hero.Movement.Y + 0.05f);
            else
            {
                _hero.Movement = Vector2.Zero;
                if (!G.willFightBoss)
                {
                    if (Math.Abs(_ennemy.Pos.X - _hero.Pos.X) <= 40 && ennemyAttack == 100)
                        ennemyAttack--;
                    if (ennemyAttack < 100)
                        ennemyAttack--;
                    if (ennemyAttack == 0)
                        ennemyAttack = 100;
                    if (ennemyAttack == 90)
                        Hero.Life -= 1000;
                    if (ennemyAttack == 100)
                        _ennemy.Delta = new Pos(0);
                    else if (ennemyAttack >= 90)
                        _ennemy.Delta = new Pos(ennemyAttack - 100, -ennemyAttack % 10);
                    else
                        _ennemy.Delta = new Pos();
                }

                if (heroAttack < 20)
                    heroAttack--;
                if (heroAttack == 0)
                    heroAttack = 20;

                if (heroAttack == 10 && Math.Abs(_ennemy.Pos.X - _hero.Pos.X) < 50)
                    _ennemy.Life -= 10000 / 14;
            }
            if (_hero.Pos.J + _hero.Rect.Height > C.Screen.Height - heightByHero)
                _hero.Pos.J = C.Screen.Height - heightByHero - _hero.Rect.Height;

            int heightByMonster = _map.GetHeightByHero(_ennemy.Pos.I + 17);
            if (_ennemy.Pos.J + _ennemy.Rect.Height + 7 < C.Screen.Height - heightByMonster)
                _ennemy.Movement = new Vector2(_ennemy.Movement.X, _ennemy.Movement.Y + 0.05f);
            else
                _ennemy.Movement = Vector2.Zero;
            if (_ennemy.Pos.J + _ennemy.Rect.Height + 7 > C.Screen.Height - heightByMonster)
                _ennemy.Pos.J = C.Screen.Height - heightByMonster - _ennemy.Rect.Height - 7;

            _hero.Update(gameTime);
                _ennemy.Update(gameTime);
            if (!G.willFightBoss)
            {
                _ennemy.Pos = _ennemy.Pos + getDirection(_ennemy, _hero, Math.Abs(_ennemy.Pos.X - _hero.Pos.X) > 40);
            }
            moveHero();

            

            if (Hero.Life < 100)
            {
                Hero.Life = 0;
                Cursor.SetVisibility(true);
                G.currentGame.Push(new GameOver());
            }
            else if (_ennemy.Life < 100)
            {
                _ennemy.Life = 0;
                Cursor.SetVisibility(true);
                G.currentGame.Push(new FightRecap());
                this.State = State.Exit;
            }

            if (E.IsPushed(Keys.A) && Hero.Mana > 13)
            {
                Hero.Mana -= 13;
                _fireball.Pos = new Pos(_hero.Pos.I, _hero.Pos.J - 32);
                _fireball.Visible = true;
                _fireball.Movement = (new Pos(_ennemy.Pos.I - _fireball.Pos.I, _ennemy.Pos.J + 50 - _fireball.Pos.J)).ToVector2() / 750;
            }
            _fireball.Update(gameTime);

            if (E.IsPushed(Keys.Up))
            {
                _hero.Movement = new Vector2(0, -0.8f);
                if (E.IsDown(Keys.Right))
                    _hero.Movement = new Vector2(0.2f, _hero.Movement.Y);
                if (E.IsDown(Keys.Left))
                    _hero.Movement = new Vector2(-0.2f, _hero.Movement.Y);
                _hero.Pos = new Pos(_hero.Pos.I, _hero.Pos.J - 4);
            }

            int heightByFireball = C.Screen.Height - _map.GetHeightByHero(_fireball.Pos.I + 9);

            if (_fireball.Pos.J + 32 >= heightByFireball)
            {
                if (Math.Abs(_hero.Pos.I - _fireball.Pos.I) < 50)
                    Hero.Life -= 1500;
                if (Math.Abs(_ennemy.Pos.I - _fireball.Pos.I) < 30)
                   _ennemy.Life -= 1000;
                _map.Destruct(new Pos(_fireball.Pos.I, heightByFireball), 30);
                _fireball.Movement = Vector2.Zero;
                _fireball.Pos = new Pos();
                _fireball.Visible = false;
            }

            if (G.willFightBoss)
            {
                if (_ennemyFireball.Visible)
                {
                    Vector2 buff = new Pos(_hero.Pos.I - _ennemyFireball.Pos.I, _hero.Pos.J + 50 - _ennemyFireball.Pos.J).ToVector2();
                    buff.Normalize();
                    _ennemyFireball.Movement = buff / 3;
                }
                else
                {
                    _ennemyFireball.Pos = new Pos(_ennemy.Pos.I, _ennemy.Pos.J - 32);
                    _ennemyFireball.Visible = true;
                }
                int heightByEnnemyFireball = C.Screen.Height - _map.GetHeightByHero(_ennemyFireball.Pos.I + 9);
                if (_ennemyFireball.Pos.J + 32 >= heightByEnnemyFireball)
                {
                    if (Math.Abs(_hero.Pos.I - _ennemyFireball.Pos.I) < 50)
                        Hero.Life -= 1000;
                    if (Math.Abs(_ennemy.Pos.I - _ennemyFireball.Pos.I) < 30)
                        _ennemy.Life -= 3000;
                    _map.Destruct(new Pos(_ennemyFireball.Pos.I, heightByEnnemyFireball), 30);
                    _ennemyFireball.Movement = Vector2.Zero;
                    _ennemyFireball.Pos = new Pos();
                    _ennemyFireball.Visible = false;
                }
                _ennemyFireball.Update(gameTime);
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
                    needMove.LoadContent("fight", "10");
                    return right;
                }
                else if (needMove.Pos.X > e2.Pos.X)
                {
                    needMove.LoadContent("fight", "3");
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
            _background.Draw();
            _background2.Draw(true);
            _map.Draw();
            _hero.Draw();
            _ennemy.Draw();
            _fireball.Draw();
            if (G.willFightBoss)
                _ennemyFireball.Draw();
            Text.Write("vie", (Hero.Life / 100).ToString() + "/100", new Vector2(10, 10), Color.Red);
            Text.Write("vie", (Hero.Mana).ToString() + "/100", new Vector2(10, 40), Color.DarkCyan);
            if (!G.willFightBoss)
                Text.Write("vie", (_ennemy.Life / 100).ToString() + "/100", new Vector2(850, 10), Color.Red);
            else
                Text.Write("vie", (_ennemy.Life / 100).ToString() + "/200", new Vector2(850, 10), Color.Red);
        }
    }
}
