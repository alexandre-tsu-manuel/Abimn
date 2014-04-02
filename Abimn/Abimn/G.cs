using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    public enum CurrentGame { Menu, HeroCreator, Main, PauseMenu, OptionsMenu, Inventory, Fight, FightRecap, GameOver }

    /// <summary>
    /// Globals Manager
    /// Write : Nobody
    /// </summary>
    public static class G
    {
        public static Stack<CurrentGame> currentGame;
        public static Tile[] mainTiles;
        public static Tile[] mainDecoTiles;
        public static Tile[] fightTiles;
        public static Tile[] pause_menuTiles;
        public static Tile[] inventoryTiles;
        public static Tile[] heroTiles;
        public static Texture2D oldFrame;
        public static SpriteFont vie;
        public static Tile[] recapTiles;
        public static Tile[] buttonTiles;
    }
}
