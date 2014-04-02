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
    public static class Fight
    {
        private static SpriteBatch spriteBatch;
        private static Entity _hero;
        private static Ennemy _ennemy;
        private static FightMap _map;
        private static Rectangle _one;
        private static bool _fightContact;
        private static bool _jumping;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public static void Initialize(SpriteBatch spriteBatch)
        {
            Fight.spriteBatch = spriteBatch;

            _hero = new Entity();
            _ennemy = new Ennemy();

            _map = new FightMap();

            _one = new Rectangle(100, 400, 200, 50);
            _hero.Initialize();
            _hero.Position = new Pos(50, 450);
            _ennemy.Initialize(new Vector2(-1, 0), 0.02F);
            _ennemy.Position = new Pos(550, 450);
            _hero.LoadContent(1, ref G.fightTiles);
            _ennemy.LoadContent(3, ref G.fightTiles);
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
        public static void Update(GameTime gameTime)
        {
            if (_fightContact)
            {
                _ennemy.Life -= 30;
                Hero.Life -= 20;
            }
            if (Hero.Life <= 0)
            {
                Hero.Life = 0;
                G.currentGame.Push(CurrentGame.GameOver);
                GameOver.Initialize(spriteBatch);
            }
            if (_ennemy.Life <= 0)
            {
                _ennemy.Life = 0;
                G.currentGame.Push(CurrentGame.FightRecap);
                FightRecap.Initialize(spriteBatch);
            }

            E.Update();

            _ennemy.Update(gameTime);
            if (_ennemy.Position.X < _hero.Position.X + 50)
            {
                _ennemy.Speed = 0;
                _fightContact = true;
            }

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
            if (E.IsDown(Keys.Right))
            {
                _hero.LoadContent(1, ref G.fightTiles);
                _hero.Position.X++;
            }
            if (E.IsDown(Keys.Left))
            {
                _hero.LoadContent(2, ref G.fightTiles);
                _hero.Position.X--;
            }
            else if (E.IsReleased(Keys.Left) || E.IsReleased(Keys.Right))
                _hero.Speed = 0;

            //_hero.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        public static void Draw()
        {
            _map.Draw(spriteBatch);
            _ennemy.Draw(spriteBatch);
            _hero.Draw(spriteBatch);
            spriteBatch.DrawString(G.vie, (Hero.Life/100).ToString() + "/100", new Vector2(10, 10), Color.Red);
            spriteBatch.DrawString(G.vie, (_ennemy.Life/100).ToString() + "/100", new Vector2(750, 10), Color.Red);
        }
    }
}
