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
        private Map map;
        private byte slot;
        private Pos camera;

        public MapEditor(Map map, byte slot) : base(true)
        {
            this.map = map;
            this.slot = slot;
            this.camera = new Pos(map.Dimensions.X * C.sizeCell / 2, map.Dimensions.Y * C.sizeCell / 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (E.IsPushed(Keys.S))
                save();
            else if (E.IsPushed(Keys.Q))
                G.currentGame.Pop();

            if (E.GetMousePosX() < C.sizeCell && camera.X > -C.sizeCell)
                camera.X -= 10 * (C.sizeCell - E.GetMousePosX()) / C.sizeCell;
            if (E.GetMousePosX() > C.Screen.Width - C.sizeCell && camera.X < (map.Dimensions.X + 1) * C.sizeCell)
                camera.X += 10 * (E.GetMousePosX() - C.Screen.Width + C.sizeCell) / C.sizeCell;
            if (E.GetMousePosY() < C.sizeCell && camera.Y > -C.sizeCell)
                camera.Y -= 10 * (C.sizeCell - E.GetMousePosY()) / C.sizeCell;
            if (E.GetMousePosY() > C.Screen.Height - C.sizeCell && camera.Y < (map.Dimensions.Y + 1) * C.sizeCell)
                camera.Y += 10 * (E.GetMousePosY() - C.Screen.Height + C.sizeCell) / C.sizeCell;
        }

        public override void Draw()
        {
            map.Draw(camera/50, camera%50);
        }

        public void save()
        {
            string[] maps = System.IO.File.ReadAllLines(C.mapsPath);

            maps[slot] = map.save();
            System.IO.File.WriteAllLines(C.mapsPath, maps);
        }
    }
}
