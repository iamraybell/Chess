using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Pawn : IPiece
    {
        private int row;
        private int column;
        private List<List<int>> possibleMoves;
        private List<int[]> moveSet;
        

        /// <summary>
        /// Constructor. Takes in the row the piece will be and the column. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Pawn(int row, int column, int rowLimit, int ColumnLimit, List<int[]> moveSet)
        {
            this.row = row;
            this.column = column;
            GenerateMoves(rowLimit,ColumnLimit);
            this.moveSet = moveSet;
        }
         





        /// <summary>
        /// returns the array of the possible moves this piece can make. 
        /// </summary>
        /// <returns></returns>
        public List<List<int>> GetPossibleMoves()
        {
            return possibleMoves;
        }


        /// <summary>
        /// Sets row and column for this piece. 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void SetPosition(int row, int column)
        {
            this.row = row;
            this.column = column;

        }
        // resets possible moves list, and makes a new move list based on moveset passed into Constructor.
        private void GenerateMoves(int rowLimit, int ColumnLimit)
        {
            possibleMoves = new List<List<int>>();
            
            foreach(var move in moveSet)
            {
                if (move[0] + row < rowLimit && move[0] + row >= 0 && move[1] < ColumnLimit && move[1] >= 0)
                {
                    possibleMoves.Add(new List<int> { move[0], move[1] });
                }
            }

        }
        
    }
}
