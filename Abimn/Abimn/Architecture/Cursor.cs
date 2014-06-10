using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abimn
{
    public static class Cursor
    {
        private static Entity that;

        public static void Initialize()
        {
            that = new Entity();
        }

        public static void SetCursor(string folder, string keyNormal, string keyPushed, Pos delta)
        {
            that.LoadContent(folder + "/" + keyNormal, "", folder + "/" + keyPushed);
            that.Delta = delta;
        }

        public static void SetCursor(string keyNormal, string keyPushed, Pos delta)
        {
            that.LoadContent(keyNormal, "", keyPushed);
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

        public static void Update()
        {
            that.Pos = E.GetMousePos();
        }

        public static void Draw()
        {
            that.Draw();
        }
    }
}
