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
        private Cell[][] cells;

        public FightMap()
        {
            cells = new Cell[650][];

            for (int i = 0; i < 500; i++)
            {
                cells[i] = new Cell[850];
                for (int j = 0; j < 850; j++)
                    cells[i][j] = new Cell(false, 4, 0);
            }
            for (int i = 500; i < 520; i++)
            {
                cells[i] = new Cell[850];
                for (int j = 0; j < 850; j++)
                    cells[i][j] = new Cell(true, 5, 0);
            }
            for (int i = 520; i < 650; i++)
            {
                cells[i] = new Cell[850];
                for (int j = 0; j < 850; j++)
                    cells[i][j] = new Cell(true, 6, 0);
            }
        }

        public FightMap(Pos dimensions, int sizeCell)
        {
            cells = new Cell[dimensions.Y][];

            for (int i = 0; i < dimensions.Y; i++)
            {
                cells[i] = new Cell[dimensions.X];
                for (int j = 0; j < C.nbCellsHorizontal; j++)
                {
                    cells[i][j] = new Cell(false, 1, 0);
                    if (cells[i][j].IdFloor == 2)
                        cells[i][j].Blocking = true;
                }
            }
        }

        public int Decoration(Pos pos)
        {
            return cells[pos.X][pos.Y].IdDeco;
        }

        public void SetCell(Pos pos, Cell cell)
        {
            cells[pos.X][pos.Y] = cell;
        }

        public bool CanMoveOn(Pos pos)
        {
            if (pos.X < 0 || pos.Y < 0 || pos.X >= C.nbCellsHorizontal || pos.Y >= C.nbCellsVertical)
                return false;
            return !cells[pos.Y][pos.X].Blocking;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Pos pos = new Pos();

            for (pos.X = 0; pos.X < 850; pos.X++)
                for (pos.Y = 0; pos.Y < 650; pos.Y++ )
                    cells[pos.Y][pos.X].Draw(spriteBatch, pos, Center.None, true);
        }
    }
}
