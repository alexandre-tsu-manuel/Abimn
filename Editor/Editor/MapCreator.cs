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
    /// Initialisation d'une map
    /// </summary>
    public class MapCreator : GameType
    {
        public MapCreator() : base(true)
        {
            // Writing in file

            //G.currentGame.Push(new MapEditor());
        }

        public override void Update(GameTime gameTime)
        {
            G.currentGame.Pop();
        }

        public override void Draw()
        {
        }
    }
}
