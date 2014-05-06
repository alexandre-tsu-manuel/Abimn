using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    public class Cell
    {
        private Queue<byte> _id = new Queue<byte>();

        public bool Blocking
        {
            get { return _blocking; }
            set { _blocking = value; }
        }
        private bool _blocking;

        public Cell(string info)
        {
            string[] split = info.Split(':');
            byte[] id = new byte[split.Length - 1];

            Blocking = split[0][0] == 'y';
            for (int i = 0; i < split.Length - 1; i++)
                id[i] = Convert.ToByte(split[i+1]);

            foreach (byte item in id)
                _id.Enqueue(item);
        }

        public Cell(byte[] id, bool blocking = false)
        {
            Blocking = blocking;
            foreach (byte item in id)
                _id.Enqueue(item);
        }

        public void Draw(Pos pos, Center center = Center.None)
        {
            byte[] clone = _id.ToArray();
            byte i;

            for (i = 0; i < clone.Length; i++)
                G.tiles[(int)Tiles.Main][clone[i] - 1].Draw(pos, center);
        }

        public string ToString()
        {
            Queue<byte> clone = new Queue<byte>(_id);
            string ret = Blocking ? "y" : "n";

            try
            {
                while (true)
                    ret += ":" + clone.Dequeue().ToString();
            }
            catch (InvalidOperationException) { }

            return ret;
        }
    }
}
