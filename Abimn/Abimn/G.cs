using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    /// <summary>
    /// Globals Manager
    /// Write : Nobody
    /// </summary>
    public static class G
    {
        public static Stack<GameType> currentGame;
        public static SpriteBatch spriteBatch;
        public static Tile[][] tiles;
        public static SpriteFont vie;
    }
}
