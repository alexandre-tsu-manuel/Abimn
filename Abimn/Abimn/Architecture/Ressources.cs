using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Abimn
{
    public static class Ressources
    {
        private static ContentManager _content;

        public static void Load(ContentManager content)
        {
            _content = content;
            LoadDirectory<Texture2D>(content.RootDirectory + "/" + C.imagesFolder + "/");
            LoadDirectory<Song>(content.RootDirectory + "/" + C.musicsFolder + "/");
            LoadDirectory<SpriteFont>(content.RootDirectory + "/" + C.spriteFontsFolder + "/");
        }

        private static void LoadDirectory<T>(string path)
        {
            string[] folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            LoadFilesInDirectory<T>(path);
            foreach (string folder in folders)
                LoadFilesInDirectory<T>(folder + "/");
        }

        private static void LoadFilesInDirectory<T>(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                string filePath = path.Remove(0, _content.RootDirectory.Length + 1) + Path.GetFileNameWithoutExtension(file.Name);
                if (!G.content.ContainsKey(filePath))
                    G.content.Add(filePath, _content.Load<T>(filePath));
            }
        }

        public static Texture2D GetImage(string path)
        {
            string key = C.imagesFolder + "/" + path;
            if (G.content.ContainsKey(key))
                return (Texture2D)G.content[key];
            else
                return (Texture2D)G.content[C.imagesFolder + "/" + "void"];
        }
    }
}
