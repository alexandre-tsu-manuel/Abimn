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
    /// Ecran de shop
    /// </summary>
    public class Shop : GameType
    {
        public Shop() : base(true)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            if (E.IsPushed(Keys.Escape))
                G.currentGame.Pop();
        }

        public override void Draw()
        {
            
        }
    }
}