using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Abimn
{
    public enum Tiles
    {
        Main,
        MainDeco,
        Button,
        Slot,
        Cursor,
		Menu
    }

    public class TileProperty
    {
        public int Size;
        public string Tag;

        public static TileProperty getFrom(Tiles type)
        {
            TileProperty ret = new TileProperty();

            switch (type)
            {
                case Tiles.Main:
                    ret.Size = 10;
                    ret.Tag = "m";
                    break;
                case Tiles.MainDeco:
                    ret.Size = 10;
                    ret.Tag = "md";
                    break;
                case Tiles.Button:
                    ret.Size = 6;
                    ret.Tag = "button";
                    break;
                case Tiles.Slot:
                    ret.Size = 22;
                    ret.Tag = "slot";
					break;
				case Tiles.Cursor:
					ret.Size = 2;
					ret.Tag = "cursor";
					break;
				case Tiles.Menu:
					ret.Size = 1;
					ret.Tag = "menu";
					break;
            }

            return ret;
        }
    }

    public static class TilesManager
    {
        public static int nbArrays;

        public static void Initialize(ContentManager content)
        {
            TilesManager.nbArrays = Enum.GetNames(typeof(Tiles)).Length;

            G.tiles = new Tile[TilesManager.nbArrays][];

            for (int id = 0; id < TilesManager.nbArrays; id++)
            {
                TileProperty properties = TileProperty.getFrom((Tiles)id);
                G.tiles[id] = new Tile[properties.Size];
                for (int i = 0; i < properties.Size; i++)
                    G.tiles[id][i] = new Tile(content, properties.Tag + (i + 1).ToString());
            }
        }
    }
}
