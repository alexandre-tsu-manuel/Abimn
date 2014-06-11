namespace Abimn
{
    class FightMap
    {
        private Cell cells;

        public FightMap()
        {
            cells = new Cell(false, 5, 0);
        }

        public int Decoration(Pos pos)
        {
            return cells.IdDeco;
        }


        public bool CanMoveOn(Pos pos)
        {
            if (pos.X < 0 || pos.Y < 0 || pos.X >= C.nbCellsHorizontal || pos.Y >= C.nbCellsVertical)
                return false;
            return !cells.Blocking;
        }

        public void Draw()
        {
            Pos pos = new Pos();
            Cell ciel = new Cell(false, 9, 0);
           
            ciel.Draw(new Pos(0, 0), Center.None, true);
            cells.Draw(new Pos(0, 450), Center.None, true);
            
        }
    }
}
