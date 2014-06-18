using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Abimn
{
    public static class Music
    {
        private static string old = "";
        private static string current = "";
        public static float Volume
        {
            get { return volume; }
            set
            {
                volume = MathHelper.Clamp(value, 0f, 100f);
                MediaPlayer.Volume = MathHelper.Clamp((float)(Math.Log(volume + 1) / Math.Log(101)), 0.0f, 1.0f);
            }
        }
        private static float volume = 100;
        public static bool Allowed
        {
            get { return allowed; }
            set
            {
                allowed = value;
                if (allowed)
                    Music.Volume = Music.Volume;
                else
                    MediaPlayer.Volume = 0;
            }
        }
        private static bool allowed = true;

        public static void Play(string path, bool force = false)
        {
            if (current != path || force)
            {
                MediaPlayer.IsRepeating = true;
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
