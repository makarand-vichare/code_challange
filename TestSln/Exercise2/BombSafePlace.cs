using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    public class BombSafePlace
    {
        public int NumberOfBombs { get; set; }
        public int[] XPositions { get; set; }
        public int[] YPositions { get; set; }
        public int[] ZPositions { get; set; }

        public int SafeXPostion { get; set; }
        public int SafeYPostion { get; set; }
        public int SafeZPostion { get; set; }
        public double SafeDistance { get; set; }
    }
}
