using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Abimn
{
    /// <summary>
    /// Menu principal
    /// </summary>
    public class Menu : GameType
    {
        private Button create, load, quit;
        //private Entity background;

        public Menu() : base(true)
        {
            Cursor.setCursor(Tiles.Cursor, 1, 2, new Pos(15, 5));

            create = new Button(new Pos((int)(C.Screen.Width * 0.15), (int)(C.Screen.Height * 0.30)));
            create.LoadContent(1, Tiles.Button);

            load = new Button(new Pos((int)(C.Screen.Width * 0.15), (int)(C.Screen.Height * 0.45)));
            load.LoadContent(2, Tiles.Button);

            quit = new Button(new Pos((int)(C.Screen.Width * 0.15), (int)(C.Screen.Height * 0.60)));
            quit.LoadContent(3, Tiles.Button);

            //background = new Entity();
            //background.LoadContent(4, Tiles.Button);
        }

        public override void Update(GameTime gameTime)
        {
            if (create.IsClicked())
                G.currentGame.Push(new MapSelector(true));
            else if (load.IsClicked())
                G.currentGame.Push(new MapSelector(false));
            else if (quit.IsClicked())
                G.currentGame.Clear();
        }

        public override void Draw()
        {
            //background.Draw();
            create.Draw();
            load.Draw();
            quit.Draw();
        }
    }
}
