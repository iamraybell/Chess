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
        public IPiece[,] contents { get; }


        public Board()
        {
            this.NumColumns = 8;
            this.NumRows = 8;
            this.contents = new IPiece[NumRows,NumColumns];
        }
        


        public List<MoveSet> GetPossibleMoves(IPiece Piece)
        {

            throw new NotImplementedException();
        }
    }
}
