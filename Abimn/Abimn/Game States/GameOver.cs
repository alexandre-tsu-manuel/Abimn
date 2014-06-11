using Microsoft.Xna.Framework;

namespace Abimn
{
    /// <summary>
    /// Ecran de fin de jeu
    /// </summary>
    public class GameOver : GameType
    {
        private Entity background;
        private Entity exit;

        public GameOver() : base(true) { }

        public override void Initialize()
        {
            background = new Entity();
            background.LoadContent("fight", "7");

            exit = new Entity(new Pos(C.Screen.Width / 2, 400));
            exit.LoadContent("fight recap", "2", Center.All);
        }

        public override void Update(GameTime gameTime)
        {
            if (exit.IsClicked())
            {
                G.currentGame.Clear();
                G.currentGame.Push(new Menu());
            }
        }

        public override void Draw()
        {
            background.Draw();
            exit.Draw();
        }
    }
}
