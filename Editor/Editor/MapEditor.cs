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
    /// Edition de la map
    /// </summary>
    public class MapEditor : GameType
    {
        Map map;

        public MapEditor(Map map) : base(true)
        {
            this.map = map;
        }

        public override void Update(GameTime gameTime)
        {
            //G.currentGame.Pop();
        }

        public override void Draw()
        {
            map.Draw(new Pos(1));
        }
    }
}
