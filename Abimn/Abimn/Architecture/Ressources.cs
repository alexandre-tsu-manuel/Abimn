using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    public static class Ressources
    {
        private static ContentManager _content;

        public static void Load(ContentManager content)
        {
            _content = content;
            LoadDirectory<Texture2D>(content.RootDirectory + "/" + C.imagesFolder + "/");
        }

        private static void LoadDirectory<T>(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            string[] folders = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
            foreach (string folder in folders)
                LoadDirectory<T>(folder);

            path = path.Remove(0, _content.RootDirectory.Length + 1);
            FileInfo[] files = dir.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                string filePath = path + "/" + Path.GetFileNameWithoutExtension(file.Name);
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
