using Microsoft.Xna.Framework.Media;

namespace Abimn
{
    public static class Music
    {
        public static void Play(string path)
        {
            MediaPlayer.Play((Song)G.content[C.musicsFolder + "/" + path]);
        }
    }
}
