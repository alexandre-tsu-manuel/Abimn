using System;

namespace Abimn
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Rand.Init();
            using (Game game = new Game())
            {
                game.Run();
            }
        }
    }
#endif
}

