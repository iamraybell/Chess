using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class MainGameApp
    {


        private IBoard curBoard;
        private IPiece curPiece;
        private List<IPosition> possibleMoves;

        public MainGameApp(Board board)
        {
            curBoard = board;
        }

        private bool PositionValid(IPosition position)
        {
            if(curBoard == null || position.Row >= curBoard.NumRows || position.Column >= curBoard.NumColumns)
            {
                return false;
            }
            return true;
        }
        private bool CheckMoveValid(IPiece curPiece, IPiece pieceAtPosition)
        {
             if( pieceAtPosition == null ||  pieceAtPosition.Owner != curPiece.Owner)
            {
                return true;
            }
            return false;
        }


        private void GenerateMoves(IPosition position)
        {
            if (!PositionValid(position))
            {
                throw new IndexOutOfRangeException();
            }
            possibleMoves = new List<IPosition>();
            
            if(curBoard == null || curBoard.contents[position.Row, position.Column] == null)
            {
                return;
            }

            curPiece = curBoard.contents[position.Row, position.Column];

            foreach(var move in curPiece.MoveSet)
            {
                int rowInQuestion = move.RowModifier + position.Row;
                int columnInQuestion = move.ColumnModifier + position.Column;
                IPosition positionToCheck = new Position(rowInQuestion, columnInQuestion);
                var results = PositionValid(positionToCheck);
                if (results == true && CheckMoveValid(curPiece, curBoard.contents[rowInQuestion, columnInQuestion]))
                {
                    possibleMoves.Add( positionToCheck);
                    if (curPiece.Continuous == true)
                    {
                        ContinuousDirectionChecker(positionToCheck, move);
                    }
                }
            }

        }

        private void ContinuousDirectionChecker(IPosition position, MoveSet move)
        {
            var nextPositionToCheck = new Position(position.Row + move.RowModifier, position.Column + move.ColumnModifier);

            if (PositionValid(nextPositionToCheck) && CheckMoveValid(curPiece, curBoard.contents[nextPositionToCheck.Row, nextPositionToCheck.Column]))
            {
                possibleMoves.Add(nextPositionToCheck);
                ContinuousDirectionChecker(nextPositionToCheck, move);
            }
            return;
        }
    }
}
