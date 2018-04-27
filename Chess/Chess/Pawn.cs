using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Pawn : IPiece
    {
        
        public int Row { get; private set; }
        public int Column { get; private set; }
        private List<List<int>> possibleMoves;
        private List<List<int>> moveSet;
        

        /// <summary>
        /// Constructor. Takes in the Row the piece will be and the column. 
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        public Pawn(int row, int column, int rowLimit, int ColumnLimit, List<List<int>> moveSet)
        {
            this.Row = row;
            this.Column = column;
            this.moveSet = moveSet;
            GenerateMoves(rowLimit,ColumnLimit);
            

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
            this.Row = row;
            this.Column = column;

        }
        // resets possible moves list, and makes a new move list based on moveset passed into Constructor.
        private void GenerateMoves(int rowLimit, int ColumnLimit)
        {
            possibleMoves = new List<List<int>>();
            
            foreach(var move in moveSet)
            {
                if (move[0] + Row < rowLimit && move[0] + Row >= 0 && move[1]+Column < ColumnLimit && move[1]+ Column >= 0)
                {
                    possibleMoves.Add(new List<int> { move[0]+Row, move[1]+Column });
                }
            }

        }
        
    }
}
