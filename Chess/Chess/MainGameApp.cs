using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MainGameApp
    {


        private IBoard curBoard;
        private IPiece curPiece;
        public List<IPosition> possibleMoves;
        List<IPlayer> players;

        public MainGameApp(Board board, IPlayerSetUpProvider topPlayerSetup, IPlayer player)
        {
            List<IPlayer> players = new List<IPlayer>();
            curBoard = board;
            topPlayerSetup.Init(curBoard, player);
            players.Add(player);
        }

        private bool PositionValid(IPosition position)
        {
            if(curBoard == null || position.Row >= curBoard.NumRows || position.Column >= curBoard.NumColumns || position.Row < 0 || position.Column < 0)
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


        public void GenerateMoves(IPosition position)
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

            foreach(var move in curPiece.MoveSet )
            {
                int rowInQuestion = move.RowModifier + position.Row;
                int columnInQuestion = move.ColumnModifier + position.Column;
                IPosition positionToCheck = new Position(rowInQuestion, columnInQuestion);
                var positionValidResults = PositionValid(positionToCheck);
                if(positionValidResults == true)
                {
                    var resultsFromMoveValidator = move.RunValidator(curBoard, curPiece);
                    if (resultsFromMoveValidator== true && CheckMoveValid(curPiece, curBoard.contents[rowInQuestion, columnInQuestion]) == true)
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

            if (PositionValid(nextPositionToCheck) && CheckMoveValid(curPiece, curBoard.contents[nextPositionToCheck.Row, nextPositionToCheck.Column]))
            {
                possibleMoves.Add(nextPositionToCheck);
                ContinuousDirectionChecker(nextPositionToCheck, move);
            }
            return;
        }
    }
}
