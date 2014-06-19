using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    class FightMap
    {
        private Texture2D map;
        private Color[] data;

        public FightMap()
        {
            data = new Color[C.Screen.Width * C.Screen.Height];
            map = Ressources.GetImage("black");
            map.GetData(data);
            int height = 500;
            for (int i = 0; i < C.Screen.Width; i++)
            {
                Color c1 = new Color(78, 66, 97);
                Color c2 = new Color(24, 18, 34);
                this.SetPixel(new Pos(i, height), c1);
                this.SetPixel(new Pos(i, height + 1), c1);
                this.SetPixel(new Pos(i, height + 2), c1);
                this.SetPixel(new Pos(i, height + 3), c1);
                this.SetPixel(new Pos(i, height + 4), c1);
                for (int j = C.Screen.Height; j > height + 4; j--)
                {
                    c2.R = (byte)(48 + Rand.Int(-10, 11));
                    c2.G = (byte)(36 + Rand.Int(-10, 11));
                    c2.B = (byte)(67 + Rand.Int(-10, 11));

                    SetPixel(new Pos(i, j), c2);
                }
                for (int j = height - 1; j >= 0; j--)
                    SetPixel(new Pos(i, j), Color.Transparent);
                int variation = Rand.Int(-2, 10);
                if (variation > 2) variation = 0;
                height += variation;
            }
        }

        public bool CanMoveOn(Pos pos)
        {
            if (pos.X < 0 || pos.Y < 0 || pos.X >= C.Screen.Width || pos.Y >= C.Screen.Height)
                return false;
            return data[pos.J * C.Screen.Width + pos.I] == Color.Black;
        }

        public void Draw()
        {
            map.SetData(data);
            Tile.Draw("black", new Pos());
        }

        private void SetPixel(Pos pos, Color c)
        {
            if (pos.I >= 0 && pos.I < C.Screen.Width && pos.J >= 0 && pos.J < C.Screen.Height)
                data[pos.J * C.Screen.Width + pos.I] = c;
        }

        public int GetHeight(int x)
        {
            int y = 0;
            try
            {
                while (data[y++ * C.Screen.Width + x] == Color.Transparent) ;
            }
            catch (IndexOutOfRangeException)
            {
                return C.Screen.Height - 10;
            }
            return C.Screen.Height - y;
        }

        public int GetHeightByHero(int x)
        {
            return GetHeight(x + 7);
        }

        public void Destruct(Pos pos, int radius)
        {
            int radiusSquare = radius * radius;

            for (int i = -radius; i < radius; i++)
                for (int j = -radius; j < radius; j++)
                    if (i * i + j * j <= radiusSquare)
                        SetPixel(new Pos(i + pos.I, j + pos.J), Color.Transparent);
            map.SetData(data);

            for (int i = pos.I - radius; i < pos.I + radius; i++)
            {
                Color c3 = new Color(255, 210, 91);
                int height = C.Screen.Height - GetHeight(i);
                SetPixel(new Pos(i, height), c3);
                SetPixel(new Pos(i, height + 1), c3);
                SetPixel(new Pos(i, height + 2), c3);
                SetPixel(new Pos(i, height + 3), c3);
                SetPixel(new Pos(i, height + 4), c3);
            }
        }
    }
}
