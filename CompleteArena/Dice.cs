using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteArena
{
    public class Dice
    {
        private Random random;
        private int WallNumber;

        public Dice()
        {
            WallNumber = 6;
            random = new Random();
        }

        public Dice(int pocetSten)
        {
            WallNumber = pocetSten;
            random = new Random();
        }

        public int GiveWallNumber()
        {
            return WallNumber;
        }

        public int Roll()
        {
            return random.Next(1, WallNumber + 1);
        }

        public override string ToString()
        {
            return String.Format("Kostka s {0} stěnami", WallNumber);
        }
    }
}
