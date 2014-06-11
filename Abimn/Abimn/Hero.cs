namespace Abimn
{
    public enum Sin { Orgueil, Luxure, Gourmandise, Colere, Paresse, Envie, Cupidite }

    /// <summary>
    /// 
    /// </summary>
    public static class Hero
    {
        /// <summary>
        /// Récupère ou définit la vie max du hero
        /// </summary>
        public static int LifeMax
        {
            get { return _lifeMax; }
            set { _lifeMax = value; }
        }
        private static int _lifeMax;

        /// <summary>
        /// Récupère ou définit la vie du hero
        /// </summary>
        public static int Life
        {
            get { return _life; }
            set
            {
                if (value > Hero.LifeMax)
                    _life = Hero.LifeMax;
                else
                    _life = value;
            }
        }
        private static int _life;

        /// <summary>
        /// Récupère ou définit l'épée du hero
        /// </summary>
        public static Weapon Sword
        {
            get { return _sword; }
            set { _sword = value; }
        }
        private static Weapon _sword;

        /// <summary>
        /// Récupère ou définit les sin du hero
        /// </summary>
        public static int[] Carac
        {
            get { return _carac; }
            set { _carac = value; }
        }
        private static int[] _carac;

        public static void Initialize()
        {
            Hero.Carac = new int[7];
        }
    }
}
