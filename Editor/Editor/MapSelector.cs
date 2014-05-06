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
    /// Edition de la map
    /// </summary>
    public class MapSelector : GameType
    {
        private Button[] slots = new Button[8];
        private bool[] slotIsEmpty = new bool[8];
        private string[] maps;
        private bool creating;

        public MapSelector(bool creating) : base(true)
        {
            this.creating = creating;
            maps = System.IO.File.ReadAllLines(@"Files/Maps.txt");
            int i = 0;

            while (i < maps.Length && i < slots.Length)
                slotIsEmpty[i++] = false;
            while (i < slots.Length)
                slotIsEmpty[i++] = true;

            for (i = 0; i < slots.Length; i++)
            {
                slots[i] = new Button(new Pos(C.Screen.Width / 2 + (i < slots.Length / 2 ? -200 : 200), C.Screen.Height / 2 - 150 + (i%(slots.Length/2)) * 100));
                slots[i].LoadContent(slotIsEmpty[i] ? 9 : i + 1, Tiles.Slot, Center.All);
            }

            //id = id >= maps.Length ? maps.Length - 1 : id;
            //this.load(maps[id]);
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = 0; i < slots.Length; i++)
                if (creating && slotIsEmpty[i] && slots[i].IsClicked())
                {
                    G.currentGame.Push(new MapEditor(Map.Generate()));
                }
                else if (!creating && !slotIsEmpty[i] && slots[i].IsClicked())
                    G.currentGame.Push(new MapEditor(new Map().Load(maps[i])));
            //G.currentGame.Pop();
        }

        public override void Draw()
        {
            for (int i = 0; i < slots.Length; i++)
                slots[i].Draw();
        }
    }
}
