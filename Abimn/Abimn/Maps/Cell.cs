using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Abimn
{
    class Cell
    {

        /// <summary>
        /// Recupere ou definit si une case permet de passer sur une autre carte
        /// </summary>
        public bool Travel
        {
            get { return travel; }
            set { travel = value; }
        }
        private bool travel;

        public byte IdFloor
        {
            get { return _idFloor; }
            set { _idFloor = value; }
        }
        private byte _idFloor;

        public byte IdDeco
        {
            get { return _idDeco; }
            set { _idDeco = value; }
        }
        private byte _idDeco;

        public bool Blocking
        {
            get { return _blocking; }
            set { _blocking = value; }
        }
        private bool _blocking;

        public Cell(bool blocking, byte idFloor, byte idDeco = 0)
        {
            Blocking = blocking;
            IdFloor = idFloor;
            IdDeco = idDeco;
            Travel = travel;
        }

        public void Draw(Pos pos, Center center = Center.None, bool fighting = false)
        {
            if (fighting)
                Tile.Draw("fight/" + IdFloor, pos);
            else
            {
                Tile.Draw("main/" + IdFloor, pos);
                if (IdDeco != 0)
                    Tile.Draw("main deco/" + IdDeco, pos);
            }
        }
    }
}
