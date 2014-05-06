using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    public class Map
    {
        private Cell[][] cells;
        private Pos dimensions;

        public static Map Generate(Pos dimensions = null)
        {
            dimensions = dimensions != null ? dimensions : new Pos(5);
            Map ret = new Map();
            ret.dimensions = dimensions;
            ret.cells = new Cell[dimensions.Y][];
            byte[] cell = new byte[1];
            cell[0] = 1;

            for (int i = 0; i < dimensions.Y; i++)
            {
                ret.cells[i] = new Cell[dimensions.X];
                for (int j = 0; j < dimensions.X; j++)
                    ret.cells[i][j] = new Cell(cell);
            }

            return ret;
        }

        public Map Load(int id = 0)
        {
            string[] maps = System.IO.File.ReadAllLines(C.mapsPath);
            id = id >= maps.Length ? maps.Length - 1 : id;
            return this.Load(maps[id]);
        }

        public Map Load(string map)
        {
            string[] mapElmts = map.Split(';');
            dimensions = new Pos(Convert.ToInt32(mapElmts[0]));
            dimensions.Y = (mapElmts.Length - 1) / dimensions.X;
            cells = new Cell[dimensions.Y][];

            for (int i = 0; i < dimensions.Y; i++)
            {
                cells[i] = new Cell[dimensions.X];
                for (int j = 0; j < dimensions.X; j++)
                    cells[i][j] = new Cell(mapElmts[i * dimensions.X + j + 1]);
            }
            return this;
        }

        public string save()
        {
            string ret = dimensions.X.ToString();

            for (int i = 0; i < dimensions.X * dimensions.Y; i++)
                ret += ";" + cells[i / dimensions.X][i % dimensions.X].ToString();

            return ret;
        }

        public void SetCell(Pos pos, Cell cell)
        {
            cells[pos.X][pos.Y] = cell;
        }

        public bool IsBlocking(Pos pos)
        {
            if (pos.X < 0 || pos.Y < 0 || pos.X >= dimensions.X || pos.Y >= dimensions.Y)
                return false;
            return !cells[pos.X][pos.Y].Blocking;
        }

        public void DrawCell(Pos cPos, Pos pos)
        {
            if (cPos.X < 0 || cPos.Y < 0 || cPos.X >= dimensions.X || cPos.Y >= dimensions.Y)
                return;
            cells[cPos.X][cPos.Y].Draw(pos);
        }
        
        public void Draw(Pos posHero, Pos shift = null)
        {
            Pos cPosIni = new Pos(posHero.X - C.nbCellsHorizontalOnScreen / 2, posHero.Y - C.nbCellsVerticalOnScreen / 2);
            Pos sPos = new Pos();
            Pos cPos = new Pos();
            shift = shift != null ? shift : new Pos();

            for (sPos.X = -shift.X, cPos.X = cPosIni.X; sPos.X < C.Screen.Width; sPos.X += 50, cPos.X++)
                for (sPos.Y = -shift.Y, cPos.Y = cPosIni.Y; sPos.Y < C.Screen.Height; sPos.Y += 50, cPos.Y++)
                    DrawCell(cPos, sPos);
        }
    }
}
