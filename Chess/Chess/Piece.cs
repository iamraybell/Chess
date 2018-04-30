using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Piece : IPiece
    {

        
         public List<IMoveSet> MoveSet { get; }

        public PieceType PieceType { get; private set; }
        public bool Continuous { get; private set; }

        /// <summary>
        /// Constructor. Takes in the  pieceType, moveSet, and continuous.
        /// </summary>
        public Piece(PieceType pieceType, List<IMoveSet> moveSet, bool continuous)
        {
            this.PieceType = pieceType;
            this.MoveSet = moveSet;
            this.Continuous = continuous;

        }
         



        // resets possible moves list, and makes a new move list based on moveset passed into Constructor.
        //private void GenerateMoves()
        //{
        //    possibleMoves = new List<List<int>>();
            
        //    foreach(var move in moveSet)
        //    {
        //        int rowInQuestion = move[0] + Row;
        //        int columnInQuestion = move[1] + Column;
        //        var results = IsValidMove(rowInQuestion, columnInQuestion);
        //        if (results == true)
        //        {
        //            possibleMoves.Add(new List<int> { move[0]+Row, move[1]+Column });
        //            if(Continuous == true)
        //            {
        //                ContinuousDirectionChecker(rowInQuestion, columnInQuestion, move[0], move[1]);
        //            }
        //        }
        //    }

        //}

        /// <summary>
        /// This function will recursively check in a direction if a piece can move there. 
        /// </summary>
        //private void ContinuousDirectionChecker(int rowFrom, int columnFrom, int rowBuf,int columnBuf )
        //{

        //    var rowToCheck = rowFrom + rowBuf;
        //    var columnToCheck = columnFrom + columnBuf;
        //    var results = IsValidMove(rowToCheck, columnToCheck);
        //    if(results == true)
        //    {
        //        possibleMoves.Add(new List<int>() { rowToCheck, columnToCheck });
        //        ContinuousDirectionChecker(rowToCheck, columnToCheck, rowBuf, columnBuf);
        //    }
        //    return;
        //}


        /// <summary>
        /// Tells us if the row and column provide is a valid move. Takes board size into consideration. 
        /// </summary>
        //private bool IsValidMove(int rowInQuestion, int columnInQuestion)
        //{
        //    return rowInQuestion < RowLimit && rowInQuestion >= 0 && columnInQuestion < ColumnLimit && columnInQuestion >= 0;
        //}
    }
    
}
