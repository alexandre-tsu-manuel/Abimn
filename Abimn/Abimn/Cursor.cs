using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abimn
{
    public static class Cursor
    {
        private static Entity that;

        public static void SetCursor(Tiles reference, int IdNormal, int IdPushed, Pos delta)
        {
            that.LoadContent(reference, IdNormal, IdNormal, IdPushed);
            that.Delta = delta;
        }

        public static void SetVisibility(bool visible)
        {
            that.Visible = visible;
        }

        public static void SetScale(float scale)
        {
            that.Scale = scale;
        }

        public static void Draw()
        {
            that.Draw();
        }
    }
}
