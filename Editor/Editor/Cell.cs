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

        public void setBackground(byte back)
        {
            byte[] clone = _id.ToArray();
            _id.Clear();
            _id.Enqueue(back);
            for (byte i = 1; i < clone.Length; i++)
                _id.Enqueue(clone[i]);
        }

        public void addDecoration(byte deco)
        {
            _id.Enqueue(deco);
        }

        public void ClearDecoration()
        {
            byte buff = _id.Dequeue();

            _id.Clear();
            _id.Enqueue(buff);
        }

        public byte[] GetArray()
        {
            return _id.ToArray();
        }

        public void Draw(Pos pos, Center center = Center.None)
        {
            byte[] clone = _id.ToArray();

            G.tiles[(int)Tiles.Main][clone[0] - 1].Draw(pos, center);
            for (byte i = 1; i < clone.Length; i++)
                G.tiles[(int)Tiles.MainDeco][clone[i] - 1].Draw(pos, center);
        }

        public string Save()
        {
            byte[] clone = _id.ToArray();
            string ret = Blocking ? "y" : "n";

            for (byte i = 0; i < clone.Length; i++)
                ret += ":" + clone[i].ToString();

            return ret;
        }
    }
}
