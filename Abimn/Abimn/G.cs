using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Globals Manager
    /// Write : Nobody
    /// </summary>
    public static class G
    {
        public static Stack<GameType> currentGame;
        public static SpriteBatch spriteBatch;
        public static Tile[][] tiles;
        public static SpriteFont vie;
        public static Song one, two, three;
    }
}
