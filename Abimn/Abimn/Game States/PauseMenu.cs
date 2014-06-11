using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Abimn
{
    /// <summary>
    /// Menu de pause
    /// </summary>
    public class PauseMenu : GameType
    {
        private Entity resume, exit, option;
        private Entity fond_menu;

        public PauseMenu() : base(false) { }

        public override void Initialize()
        {
            Cursor.SetVisibility(true);

            fond_menu = new Entity();
            fond_menu.Initialize(new Pos(fond_menu.Pos.X+112,fond_menu.Pos.Y+ 94));
            fond_menu.LoadContent("pause menu", "1");

            resume = new Entity(new Pos(fond_menu.Pos.X + 250, fond_menu.Pos.Y + 195));
            resume.LoadContent("pause menu", "2", "6", "2");
            exit = new Entity(new Pos(fond_menu.Pos.X + 250, fond_menu.Pos.Y + 355));
            exit.LoadContent("pause menu", "4", "7", "4");
            option = new Entity(new Pos(fond_menu.Pos.X + 250, fond_menu.Pos.Y + 275));
            option.LoadContent("pause menu", "3", "5", "3");
        }

        public override void Update(GameTime gameTime)
        {
            if (resume.IsClicked())
                this.State = State.Exit;
            else if (option.IsClicked())
                G.currentGame.Push(new OptionsMenu());
            else if (exit.IsClicked())
            {
                G.currentGame.Clear();
                G.currentGame.Push(new Menu());
            }
            if (E.IsPushed(Keys.Escape))
                this.State = State.Exit;
        }

        public override void Draw()
        {
            fond_menu.Draw();
            resume.Draw();
            exit.Draw();
            option.Draw();
        }
    }
}
