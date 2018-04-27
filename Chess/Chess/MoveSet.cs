using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{

    /// <summary>
    /// Possible Move for a Piece.
    /// </summary>
    public class MoveSet: IMoveSet

    {
        public int y { get; }
        public int x { get; }


        private MoveSet (int y, int x)
        {
            this.y = y;
            this.x = x;
        }
        public static IMoveSet Set(int y, int x)
        {
            return new MoveSet(y, x); 

        }

    }
}
