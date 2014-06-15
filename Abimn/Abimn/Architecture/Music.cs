using Microsoft.Xna.Framework.Media;

namespace Abimn
{
    public static class Music
    {
        private static string old = "";
        private static string current = "";

        public static void Play(string path, bool force = false)
        {
            if (current != path || force)
            {
                old = current;
                current = path;
                MediaPlayer.Play((Song)G.content[C.musicsFolder + "/" + path]);
            }
        }

        public static void PlayOld()
        {
            current = old;
            old = "";
            MediaPlayer.Play((Song)G.content[C.musicsFolder + "/" + current]);
        }

        public static void Stop()
        {
            MediaPlayer.Stop();
        }
    }
}
