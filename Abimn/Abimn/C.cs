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
        public const int sizeCell = 50;
        public const int nbCellsVertical = 50;
        public const int nbCellsHorizontal = 50;
        public const int nbCellsVerticalOnScreen = C.Screen.Height / sizeCell;
        public const int nbCellsHorizontalOnScreen = C.Screen.Width / sizeCell;
    }
}
