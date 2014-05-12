using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Abimn
{
    /// <summary>
    /// Classe représentant une arme
    /// </summary>
    public class Weapon
    {
        /// <summary>
        /// Récupère ou définit les dégâts de la weapon
        /// </summary>
        public int Damages
        {
            get { return _damages; }
            set { _damages = value; }
        }
        private int _damages;

        /// <summary>
        /// Récupère ou définit le nom de la weapon
        /// </summary>
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private String _name;
    }
}
