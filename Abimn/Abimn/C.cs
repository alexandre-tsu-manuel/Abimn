using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abimn
{
    /// <summary>
    /// Constants Manager
    /// Write : Nobody
    /// </summary>
    public static class C
    {
        public struct Screen
        {
            public const int Width = 850;
            public const int Height = 650;
        }
        public const int nbMainTiles = 10;
        public const int nbMainDecoTiles = 10;
        public const int nbFightTiles = 10;
        public const int sizeCell = 50;
        public const int nbCellsVertical = 50;
        public const int nbCellsHorizontal = 50;
        public const int nbCellsVerticalOnScreen = C.Screen.Height / sizeCell;
        public const int nbCellsHorizontalOnScreen = C.Screen.Width / sizeCell;
        public const int nbpause_menuTiles = 10;
        public const int nbinventoryTiles = 13;
        public const int nbheroTiles = 4;
        public const int nbrecapTiles = 2;
        public const int nbButtonTiles = 7;
    }
}
