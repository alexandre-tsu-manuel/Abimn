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
        private Ennemy _ennemy;
        private FightMap _map;
        private Rectangle _one;
        private bool _fightContact;
        private bool _jumping;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public Fight() : base(true)
        {
            _hero = new Entity(new Pos(50, 450));
            _ennemy = new Ennemy(new Pos(550, 450), new Vector2(-1, 0), 0.02F);

            _map = new FightMap();

            _one = new Rectangle(100, 400, 200, 50);
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
        public override void Update(GameTime gameTime)
        {
            if (_fightContact)
            {
                _ennemy.Life -= 30;
                Hero.Life -= 20;
            }
            if (Hero.Life <= 0)
            {
                Hero.Life = 0;
                G.currentGame.Push(new GameOver());
            }
            if (_ennemy.Life <= 0)
            {
                _ennemy.Life = 0;
                G.currentGame.Push(new FightRecap());
            }

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
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public override void Draw()
        {
            _map.Draw();
            _ennemy.Draw();
            _hero.Draw();
            G.spriteBatch.DrawString(G.vie, (Hero.Life / 100).ToString() + "/100", new Vector2(10, 10), Color.Red);
            G.spriteBatch.DrawString(G.vie, (_ennemy.Life / 100).ToString() + "/100", new Vector2(750, 10), Color.Red);
        }
    }
}
