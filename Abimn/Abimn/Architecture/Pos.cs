using Microsoft.Xna.Framework;

namespace Abimn
{
    public class Pos
    {
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        private float _x;

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        private float _y;

        public int I
        {
            get { return (int)_x; }
            set { _x = value; }
        }

        public int J
        {
            get { return (int)_y; }
            set { _y = value; }
        }

        public Pos(double x, double y)
        {
            X = (float)x;
            Y = (float)y;
        }

        public Pos(double p)
        {
            X = Y = (float)p;
        }

        public Pos(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Pos(float p)
        {
            X = Y = p;
        }

        public Pos()
        {
            X = Y = 0;
        }

        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        public static Pos FromVector2(Vector2 v)
        {
            return new Pos(v.X, v.Y);
        }

        public static Pos operator +(Pos p1, Pos p2) { return new Pos(p1.X + p2.X, p1.Y + p2.Y); }
        public static Pos operator +(Pos p, Vector2 v) { return new Pos(p.X + v.X, p.Y + v.Y); }
        public static Pos operator -(Pos p1, Pos p2) { return new Pos(p1.X - p2.X, p1.Y - p2.Y); }
        public static Pos operator -(Pos p, Vector2 v) { return new Pos(p.X - v.X, p.Y - v.Y); }
        public static Pos operator *(Pos p, float m) { return new Pos(p.X * m, p.Y * m); }
        public static Pos operator /(Pos p, float d) { return new Pos(p.X / d, p.Y / d); }
        public static Pos operator %(Pos p, float m) { return new Pos(p.X % m, p.Y % m); }
    }
}
