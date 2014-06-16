using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abimn.Game_States
{
    class Transition: GameType
    {
        private Entity fond_transition;

        public Transition() : base(false) { }

        public override void Initialize()
        {

            fond_transition = new Entity();
            fond_transition.Initialize(new Pos(fond_transition.Pos.X ,fond_transition.Pos.Y));
            fond_transition.LoadContent("transition", "spirale");

        }

        public override void Update(Microsoft.Xna.Framework.GameTime gametime)
        {

            System.Threading.Thread.Sleep(1100);
                this.State = State.Exit;
        }

        public override void Draw()
        {
            fond_transition.Draw();
        }
    }
}

    

