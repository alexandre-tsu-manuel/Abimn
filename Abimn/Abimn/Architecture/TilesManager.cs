using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Abimn
{
    public static class TilesManager
    {
        private static ContentManager _content;
        private static string _currentFolder;

        public static void Initialize(ContentManager content)
        {
            _content = content;

            SetFolder("");
            Add("void");

            SetFolder("char edit");
            Add("background");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");
            Add("8");
            Add("9");
            Add("10");
            Add("11");
            Add("12");
            Add("13");
            Add("14");
            Add("15");
            Add("16");
            Add("17");
            Add("18");
            Add("19");
            Add("20");
            Add("21");
            Add("22");
            Add("23");
            Add("24");
            Add("25");
            Add("26");
            Add("27");
            Add("28");
            Add("29");
            Add("30");
            Add("31");
            Add("32");
            Add("33");

            SetFolder("cursor");
            Add("default");
            Add("clicked");

            SetFolder("fight");
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");
            Add("8");
            Add("9");
            Add("10");

            SetFolder("fight recap");
            Add("1");
            Add("2");

            SetFolder("hero");
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");
            Add("8");
            Add("9");

            SetFolder("inventory");
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");
            Add("8");
            Add("9");
            Add("10");
            Add("11");
            Add("12");
            Add("13");

            SetFolder("main");
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");
            Add("8");
            Add("9");
            Add("10");

            SetFolder("main deco");
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");
            Add("8");
            Add("9");
            Add("10");

            SetFolder("marchand");
            Add("1");
            Add("2");
            Add("3");

            SetFolder("menu principal");
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");

            SetFolder("new hero");
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");
            Add("8");
            Add("9");
            Add("10");

            SetFolder("options menu");
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");
            Add("8");
            Add("9");
            Add("10");

            SetFolder("pause menu");
            Add("1");
            Add("2");
            Add("3");
            Add("4");
            Add("5");
            Add("6");
            Add("7");
        }

        private static void SetFolder(string folder)
        {
            _currentFolder = folder;
        }

        private static void Add(string name)
        {
            string path = _currentFolder == "" ? name : _currentFolder + "/" + name;
            G.tiles.Add(path, new Tile(_content, path));
        }
    }
}
