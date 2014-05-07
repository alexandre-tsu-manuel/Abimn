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
        Fight,
        PauseMenu,
        Inventory,
        Hero,
        Recap,
        Button,
        Button2,
        Cursor,
        CharEdit
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
                case Tiles.Fight:
                    ret.Size = 10;
                    ret.Tag = "f";
                    break;
                case Tiles.PauseMenu:
                    ret.Size = 7;
                    ret.Tag = "pause_menu";
                    break;
                case Tiles.Inventory:
                    ret.Size = 13;
                    ret.Tag = "inventory";
                    break;
                case Tiles.Hero:
                    ret.Size = 4;
                    ret.Tag = "hero";
                    break;
                case Tiles.Recap:
                    ret.Size = 2;
                    ret.Tag = "recap";
                    break;
                case Tiles.Button:
                    ret.Size = 7;
                    ret.Tag = "menup";
                    break;
                case Tiles.Button2:
                    ret.Size = 10;
                    ret.Tag = "menus";
                    break;
                case Tiles.Cursor:
                    ret.Size = 2;
                    ret.Tag = "cursor";
                    break;
                case Tiles.CharEdit:
                    ret.Size = 33;
                    ret.Tag = "editC";
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
