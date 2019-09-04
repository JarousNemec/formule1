using System;

namespace formule1
{
    public class Stone
    {
        public int x;
        public int y = 1;
        private string znak = "X";
        private bool NaSmazani = false;

        static Random r = new Random();

        public Stone()
        {
            int pozice = Animation.sizeX;
            x = r.Next(1, pozice);
        }

        public bool VykresliSe(string[,] dest)
        {
            if (dest.GetLength(0) > y && dest.GetLength(1) > x)
            {
                dest[y, x] = znak;
                return ((x + 1) < dest.GetLength(1));
            }
            return false;
        }

        public void Fall(string[,] dest)
        {
            y = y + 1;
        }

        public void SetToRemove()
        {
            NaSmazani = true;
        }

        public bool IsStoneToDelete()
        {
            return NaSmazani;
        }

        public int GetPositionX()
        {
            return x;
        }
        public int GetPositionY()
        {
            return y;
        }
    }
}