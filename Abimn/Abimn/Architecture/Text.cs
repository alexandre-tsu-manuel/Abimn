using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    public static class Text
    {
        public static void Write(string path, string text, Vector2 pos, Color color, float scale = 1)
        {
            G.spriteBatch.DrawString((SpriteFont)G.content[C.spriteFontsFolder + "/" + path], text, pos, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
