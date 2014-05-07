using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abimn
{
    public static class Cursor
    {
        private static Entity that;
        private static Tiles dim1;
        private static int dim2;
        private static int dim2Pushed;
        private static Pos delta;
        private static bool visible;

        public static void setCursor(Tiles dim1, int dim2, int dim2Pushed, Pos delta)
        {
            Cursor.dim1 = dim1;
            Cursor.dim2 = dim2;
            Cursor.dim2Pushed = dim2Pushed;
            Cursor.delta = delta;
            visible = true;
        }

        public static void SetVisibility(bool visible)
        {
            Cursor.visible = visible;
        }

        public static void Draw()
        {
            if (visible)
            {
                that = new Entity(new Pos(E.GetMousePosX(), E.GetMousePosY()) - delta);
                if (E.LeftIsDown())
                    that.LoadContent(Cursor.dim2Pushed, dim1);
                else
                    that.LoadContent(Cursor.dim2, dim1);
                that.Draw();
            }
        }
    }
}
