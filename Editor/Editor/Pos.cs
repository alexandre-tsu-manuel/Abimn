using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Abimn
{
    public class Pos
    {
        public int X, Y;

        public Pos(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Pos(int p)
        {
            X = Y = p;
        }

        public Pos()
        {
            X = Y = 0;
        }

        public Vector2 ToVector2()
        {
            return new Vector2((float)X, (float)Y);
        }

        public static Pos operator +(Pos p1, Pos p2)
        {
            return new Pos(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Pos operator +(Pos p, Vector2 v)
        {
            return new Pos((int)(p.X + v.X), (int)(p.Y + v.Y));
        }

        public static Pos FromVector2(Vector2 v)
        {
            return new Pos((int)v.X, (int)v.Y);
        }
    }
}
