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
        private static Center center;

        public static void setCursor(Tiles dim1, int dim2, int dim2Pushed, Center center = Abimn.Center.None)
        {
            Cursor.dim1 = dim1;
            Cursor.dim2 = dim2;
            Cursor.dim2Pushed = dim2Pushed;
            Cursor.center = center;
        }

        public static void Draw()
        {
            that = new Entity(new Pos(E.GetMousePosX(), E.GetMousePosY()));
            if (E.LeftIsDown())
                that.LoadContent(Cursor.dim2Pushed, dim1, center);
            else
                that.LoadContent(Cursor.dim2, dim1, center);
            that.Draw();
        }
    }
}
