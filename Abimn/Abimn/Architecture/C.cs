namespace Abimn
{
    /// <summary>
    /// Constants Manager
    /// </summary>
    public static class C
    {
        public struct Screen
        {
            public const int Width = 950;
            public const int Height = 750;
        }
        public const string imagesFolder = "images";
        public const string musicsFolder = "musics";
        public const string spriteFontsFolder = "spritefonts";
        public const int sizeCell = 50;
        public const int nbCellsVertical = 50;
        public const int nbCellsHorizontal = 50;
        public const int nbCellsVerticalOnScreen = C.Screen.Height / sizeCell;
        public const int nbCellsHorizontalOnScreen = C.Screen.Width / sizeCell;
    }
}
