using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Abimn
{

    /// <summary>
    /// Ecran de shop
    /// </summary>
    public class Shop : GameType
    {
        public Shop() : base(true) { }

        public override void Initialize()
        {
            Cursor.SetVisibility(true);
        }

        public override void Update(GameTime gameTime)
        {
            if (E.IsPushed(Keys.Escape) || E.IsPushed(Keys.Space))
                this.State = State.Exit;
        }

        public override void Draw()
        {
            
        }
    }
}