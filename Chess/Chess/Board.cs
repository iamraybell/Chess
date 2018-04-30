using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board : IBoard
    {
        public int NumRows { get;  }
        public int NumColumns { get; }

        public List<IMoveSet> GetPossibleMoves(IPiece Piece)
        {

            throw new NotImplementedException();
        }
    }
}
