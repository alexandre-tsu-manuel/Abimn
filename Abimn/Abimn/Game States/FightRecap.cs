using Microsoft.Xna.Framework;

namespace Abimn
{
    /// <summary>
    /// Récapitulatif du combat
    /// </summary>
    public class FightRecap : GameType
    {
        private Entity fond;
        private Entity exit;

        public FightRecap() : base(false) { }

        public override void Initialize()
        {
            fond = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2));
            fond.LoadContent("fight recap", "1", Center.All);

            exit = new Entity(new Pos(fond.Pos.X + 70, fond.Pos.Y + 370));
            exit.LoadContent("fight recap", "2");
        }

        public override void Update(GameTime gameTime)
        {
            if (exit.IsClicked())
            {
                Music.PlayOld();
                this.State = State.Exit;
            }
        }

        public override void Draw()
        {
            fond.Draw();
            exit.Draw();
            Text.Write("vie", (Hero.Life/100).ToString() + "/100", new Vector2(fond.Pos.X + 120, fond.Pos.Y + 165), Color.Red);
            Text.Write("vie", "37", new Vector2(fond.Pos.X + 162, fond.Pos.Y + 233), Color.Yellow);
            Text.Write("vie", "75", new Vector2(fond.Pos.X + 162, fond.Pos.Y + 308), Color.Green);
        }
    }
}
