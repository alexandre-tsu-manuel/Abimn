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
        private int one, two;

        public FightRecap() : base(false) { }

        public override void Initialize()
        {
            fond = new Entity(new Pos(C.Screen.Width / 2, C.Screen.Height / 2));
            fond.LoadContent("fight recap", "1", Center.All);

            exit = new Entity(new Pos(fond.Pos.X + 70, fond.Pos.Y + 370));
            exit.LoadContent("fight recap", "2");

            one = Rand.Int(20, 60);
            two = Rand.Int(75, 100);
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
            Text.Write("vie", (Hero.Life / 100).ToString() + "/100", new Vector2(fond.Pos.X + 115, fond.Pos.Y + 160), Color.Red, 0.9f);
            Text.Write("vie", one + "", new Vector2(fond.Pos.X + 158, fond.Pos.Y + 228), Color.Yellow, 0.9f);
            Text.Write("vie", two + "", new Vector2(fond.Pos.X + 158, fond.Pos.Y + 303), Color.Green, 0.9f);
        }
    }
}
