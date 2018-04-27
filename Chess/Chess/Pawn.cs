using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : IPiece
    {
        private int row;
        private int column;
        private List<List<int>> possibleMoves;
        private IMoveSet moveSet;
        

        /// <summary>
        /// Constructor. Takes in the row the piece will be and the column. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Pawn(int row, int column, IBoard board, IMoveSet moveSet)
        {
            this.row = row;
            this.column = column;
            GenerateMoves(board);
            this.moveSet = moveSet;
        }
      
        public List<List<int>> GetPossibleMoves()
        {
            return possibleMoves;
        }


        public void SetPosition(int row, int column)
        {
            this.row = row;
            this.column = column;

        }
        private void GenerateMoves(IBoard board)
        {
            possibleMoves = new List<List<int>>();
            
            foreach(var move in moveSet)
            {
                if (row + 1 < board.NumRows && column - 1 < board.NumColumns)
                {
                    possibleMoves.Add(new List<int> { row + 1, column - 1 });
                }
            }

        }
        
    }
}
