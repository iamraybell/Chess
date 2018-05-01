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
        public List<IPosition> possibleMoves;
        IPiece curPiece;


        public Board()
        {
            this.NumColumns = 8;
            this.NumRows = 8;
            this.contents = new IPiece[NumRows,NumColumns];
        }
        


        public List<IPosition> GetPossibleMoves(IPiece Piece)
        {

            return possibleMoves;
        }
        private bool PositionValid(IPosition position)
        {
            if ( position.Row >= NumRows || position.Column >= NumColumns || position.Row < 0 || position.Column < 0)
            {
                return false;
            }
            return true;
        }
        private bool CheckMoveValid(IPiece curPiece, IPiece pieceAtPosition)
        {
            if (pieceAtPosition == null || pieceAtPosition.Owner != curPiece.Owner)
            {
                return true;
            }
            return false;
        }


        public void GenerateMoves(IPosition position)
        {
            if (!PositionValid(position))
            {
                throw new IndexOutOfRangeException();
            }
            possibleMoves = new List<IPosition>();

            if ( contents[position.Row, position.Column] == null)
            {
                return;
            }

            curPiece = contents[position.Row, position.Column];

            foreach (var move in curPiece.MoveSet)
            {
                int rowInQuestion = move.RowModifier + position.Row;
                int columnInQuestion = move.ColumnModifier + position.Column;
                IPosition positionToCheck = new Position(rowInQuestion, columnInQuestion);
                var positionValidResults = PositionValid(positionToCheck);
                if (positionValidResults == true)
                {
                    var resultsFromMoveValidator = move.RunValidator(this, curPiece);
                    if (resultsFromMoveValidator == true && CheckMoveValid(curPiece, contents[rowInQuestion, columnInQuestion]) == true)
                    {
                        possibleMoves.Add(positionToCheck);
                        if (curPiece.Continuous == true)
                        {
                            ContinuousDirectionChecker(positionToCheck, move);
                        }
                    }
                }

            }

        }

        private void ContinuousDirectionChecker(IPosition position, MoveSet move)
        {
            var nextPositionToCheck = new Position(position.Row + move.RowModifier, position.Column + move.ColumnModifier);

            if (PositionValid(nextPositionToCheck) && CheckMoveValid(curPiece, contents[nextPositionToCheck.Row, nextPositionToCheck.Column]))
            {
                possibleMoves.Add(nextPositionToCheck);
                ContinuousDirectionChecker(nextPositionToCheck, move);
            }
            return;
        }

        public bool CheckSpaceforOpposingTeamPiece(Position position, IPiece piece)
        {
            return this.contents[position.Row, position.Column] != null
                   && this.contents[position.Row, position.Column].Owner.Color != piece.Owner.Color;
        }
    }
}
