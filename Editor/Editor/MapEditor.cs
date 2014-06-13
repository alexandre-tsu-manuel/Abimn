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
        private bool decorating;
        private int currBlock;

        public MapEditor(Map map, byte slot) : base(true)
        {
            this.map = map;
            this.slot = slot;
            this.camera = new Pos(map.Dimensions.X * C.sizeCell / 2, map.Dimensions.Y * C.sizeCell / 2);
            this.decorating = false;
            this.currBlock = 1;
        }

        public override void Update(GameTime gameTime)
        {
            if (E.IsPushed(Keys.S))
                save();
            else if (E.IsPushed(Keys.Q))
                G.currentGame.Pop();

            if (E.GetMousePosX() < C.sizeCell && camera.X > 0)
                camera.X -= 10 * (C.sizeCell - E.GetMousePosX()) / C.sizeCell;
            if (E.GetMousePosX() > C.Screen.Width - C.sizeCell && camera.X < map.Dimensions.X * C.sizeCell)
                camera.X += 10 * (E.GetMousePosX() - C.Screen.Width + C.sizeCell) / C.sizeCell;
            if (E.GetMousePosY() < C.sizeCell && camera.Y > 0)
                camera.Y -= 10 * (C.sizeCell - E.GetMousePosY()) / C.sizeCell;
            if (E.GetMousePosY() > C.Screen.Height - C.sizeCell && camera.Y < map.Dimensions.Y * C.sizeCell)
                camera.Y += 10 * (E.GetMousePosY() - C.Screen.Height + C.sizeCell) / C.sizeCell;

            if (E.RightIsReleased())
                this.decorating = !this.decorating;

            if (E.getMouseWheel() != 0)
            {
                if (E.getMouseWheel() > 0)
                    currBlock++;
                else
                    currBlock--;
                currBlock--;
                currBlock += TileProperty.getFrom(decorating ? Tiles.MainDeco : Tiles.Main).Size;
                currBlock = currBlock % (TileProperty.getFrom(decorating ? Tiles.MainDeco : Tiles.Main).Size);
                currBlock++;
            }

            Pos under = new Pos((camera.X - C.Screen.Width/2 + E.GetMousePosX() + C.sizeCell/2) / 50, (camera.Y - C.Screen.Height/2 + E.GetMousePosY() + C.sizeCell/2) / 50);
            Cell buff = map.GetCell(under);
            if (E.LeftIsDown())
            {
                if (decorating)
                    buff.addDecoration((byte)currBlock);
                else
                    buff.setBackground((byte)currBlock);
                map.SetCell(under, buff);
            }
            else if (E.Button1IsDown() || E.Button2IsDown() || E.IsDown(Keys.Back))
            {
                buff.ClearDecoration();
                map.SetCell(under, buff);
            }
            else if (E.MiddleIsReleased())
                currBlock = buff.GetArray()[0];

            Cursor.setCursor(decorating ? Tiles.MainDeco : Tiles.Main, currBlock, currBlock, new Pos (C.sizeCell/2));

            if (E.IsReleased(Keys.Escape))
            {
                G.currentGame.Clear();
                G.currentGame.Push(new Menu());
            }
            
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
