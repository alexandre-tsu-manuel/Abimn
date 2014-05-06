using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    class FightMap
    {
        private Cell cells;

        public FightMap()
        {
            cells = new Cell(false, 5, 0);
        }

        public int Decoration(Pos pos)
        {
            return cells.IdDeco;
        }


        public bool CanMoveOn(Pos pos)
        {
            if (pos.X < 0 || pos.Y < 0 || pos.X >= C.nbCellsHorizontal || pos.Y >= C.nbCellsVertical)
                return false;
            return !cells.Blocking;
        }

        public void Draw()
        {
            Pos pos = new Pos();
            Cell ciel = new Cell(false, 9, 0);
           
            ciel.Draw(new Pos(0, 0), Center.None, true);
            for (pos.X = 0; pos.X < C.Screen.Width; pos.X+=32)
                for (pos.Y = 480; pos.Y < C.Screen.Height; pos.Y+=32 )
                    cells.Draw(pos, Center.None, true);
            
        }
    }
}
