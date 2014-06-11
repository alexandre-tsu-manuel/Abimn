using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Abimn
{
    /// <summary>
    /// Globals Manager
    /// </summary>
    public static class G
    {
        public static Stack<GameType> currentGame;
        public static SpriteBatch spriteBatch;
        public static Hashtable content;
    }
}
