using Microsoft.Xna.Framework;

namespace Abimn
{
    /// <summary>
    /// Menu principal
    /// </summary>
    public class Menu : GameType
    {
        private Entity play;
        private Entity options;
        private Entity quit;
        private Entity background;
        private bool NewsLoaded = false;

        public Menu() : base(true) { }

        public override void Initialize()
        {
            Music.Play("lullaby");
            Hero.LifeMax = 10000;
            Hero.Life = 10000;
            Cursor.SetVisibility(true);

            play = new Entity(new Pos(C.Screen.Width * 0.15, C.Screen.Height * 0.30));
            play.LoadContent("menu principal", "1", "2", "1");

            options = new Entity(new Pos(C.Screen.Width * 0.15, C.Screen.Height * 0.45));
            options.LoadContent("menu principal", "3", "4", "3");

            quit = new Entity(new Pos(C.Screen.Width * 0.15, C.Screen.Height * 0.60));
            quit.LoadContent("menu principal", "5", "6", "5");

            background = new Entity();
            background.LoadContent("menu principal/7");

        }

        public override void Update(GameTime gameTime)
        {
            if (play.IsClicked())
                G.currentGame.Push(new Main());
            else if (options.IsClicked())
                G.currentGame.Push(new OptionsMenu());
            else if (quit.IsClicked())
                G.currentGame.Clear();
            if (!NewsLoaded)
            {
                News.Load();
                NewsLoaded = true;
            }
        }

        public override void Draw()
        {
            background.Draw();
            play.Draw();
            options.Draw();
            quit.Draw();
            if (News.LoadFinished)
                News.Draw(new Pos(610, 170));
        }
    }
}
