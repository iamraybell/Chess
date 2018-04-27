using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Piece : IPiece
    {
        public PieceType PieceType { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        private List<List<int>> possibleMoves;
        private List<List<int>> moveSet;
        public int RowLimit { get; private set; }
        public int ColumnLimit { get; private set; }
        public bool Continuous { get; private set; }


        /// <summary>
        /// Constructor. Takes in the Row the piece will be and the column. 
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="Column"></param>
        public Piece(PieceType pieceType, int row, int column, int rowLimit, int columnLimit, List<List<int>> moveSet, bool continuous)
        {
            this.PieceType = pieceType;
            this.Row = row;
            this.Column = column;
            this.RowLimit = rowLimit;
            this.ColumnLimit = columnLimit;
            this.moveSet = moveSet;
            this.Continuous = continuous;
            GenerateMoves();


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
        private void GenerateMoves()
        {
            possibleMoves = new List<List<int>>();
            
            foreach(var move in moveSet)
            {
                int rowInQuestion = move[0] + Row;
                int columnInQuestion = move[1] + Column;
                var results = IsValidMove(rowInQuestion, columnInQuestion);
                if (results == true)
                {
                    possibleMoves.Add(new List<int> { move[0]+Row, move[1]+Column });
                    if(Continuous == true)
                    {
                        ContinuousDirectionChecker(rowInQuestion, columnInQuestion, move[0], move[1]);
                    }
                }
            }

        }

        /// <summary>
        /// This function will recursively check in a direction if a piece can move there. 
        /// </summary>
        /// <param name="rowFrom"></param>
        /// <param name="columnFrom"></param>
        /// <param name="rowBuf"></param>
        /// <param name="columnBuf"></param>
        private void ContinuousDirectionChecker(int rowFrom, int columnFrom, int rowBuf,int columnBuf )
        {

            var rowToCheck = rowFrom + rowBuf;
            var columnToCheck = columnFrom + columnBuf;
            var results = IsValidMove(rowToCheck, columnToCheck);
            if(results == true)
            {
                possibleMoves.Add(new List<int>() { rowToCheck, columnToCheck });
                ContinuousDirectionChecker(rowToCheck, columnToCheck, rowBuf, columnBuf);
            }
            return;
        }


        /// <summary>
        /// Tells us if the row and column provide is a valid move. Takes board size into consideration. 
        /// </summary>
        /// <param name="rowInQuestion"></param>
        /// <param name="columnInQuestion"></param>
        /// <returns></returns>
        private bool IsValidMove(int rowInQuestion, int columnInQuestion)
        {
            return rowInQuestion < RowLimit && rowInQuestion >= 0 && columnInQuestion < ColumnLimit && columnInQuestion >= 0;
        }
    }
}
