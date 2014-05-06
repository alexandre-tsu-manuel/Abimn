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
        byte slot;

        public MapEditor(Map map, byte slot) : base(true)
        {
            this.map = map;
            this.slot = slot;
        }

        public override void Update(GameTime gameTime)
        {
            if (E.IsPushed(Keys.S))
                save();
            else if (E.IsPushed(Keys.Q))
                G.currentGame.Pop();
        }

        public override void Draw()
        {
            map.Draw(new Pos(1));
        }

        public void save()
        {
            string[] maps = new string[C.nbSlots];
            for (byte i = 0; i < C.nbSlots; i++)
                maps[i] = "";
            string[] buffer = System.IO.File.ReadAllLines(C.mapsPath);
            for (byte i = 0; i < buffer.Length; i++)
                maps[i] = buffer[i];

            maps[slot] = map.save();
            System.IO.File.WriteAllLines(C.mapsPath, maps);
        }
    }
}
