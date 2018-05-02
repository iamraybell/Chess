using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board : IBoard
    {
        public List<Position> possibleMoves;
        IPiece curPiece;

        public int NumRows { get;  }
        public int NumColumns { get; }
        public IPiece[,] contents { get; }
        
        public Board()
        {
            this.NumColumns = 8;
            this.NumRows = 8;
            this.contents = new IPiece[NumRows,NumColumns];
        }
        
        public List<Position> GetPossibleMoves(IPiece Piece)
        {
            return possibleMoves;
        }

        private bool PositionValid(Position position)
        {
            if ( position.Row >= NumRows || position.Column >= NumColumns || position.Row < 0 || position.Column < 0)
            {
                return false;
            }
            return true;
        }

        internal bool IsValidPosition(Position selectedPosition)
        {
            throw new NotImplementedException();
        }

        private bool CheckMoveValid(IPiece curPiece, IPiece pieceAtPosition)
        {
            if (pieceAtPosition == null || pieceAtPosition.Owner != curPiece.Owner)
            {
                return true;
            }
            return false;
        }

        internal Piece GetPieceByPosition(Position selectedPosition)
        {
            throw new NotImplementedException();
        }

        public void GenerateMoves(Position position)
        {
            if (!PositionValid(position))
            {
                throw new IndexOutOfRangeException();
            }
            possibleMoves = new List<Position>();

            if ( contents[position.Row, position.Column] == null)
            {
                return;
            }

            curPiece = contents[position.Row, position.Column];

            foreach (var move in curPiece.MoveSet)
            {
                int rowInQuestion = move.RowModifier + position.Row;
                int columnInQuestion = move.ColumnModifier + position.Column;
                Position positionToCheck = new Position(rowInQuestion, columnInQuestion);
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

        internal bool LastMoveTargetLocation(Position possibleOpponentsPawnPosition)
        {
            // TODO: no history so far!
            return false;
        }

        internal void MoveThePiece(Position selectedPosition, Position targetPosition)
        {
            throw new NotImplementedException();
        }

        private void ContinuousDirectionChecker(Position position, MoveSet move)
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
                   && this.contents[position.Row, position.Column].Owner.PlayerKind != piece.Owner.PlayerKind;
        }
    }
}
