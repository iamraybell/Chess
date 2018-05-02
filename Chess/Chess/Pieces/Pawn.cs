using System.Collections.Generic;

namespace Chess
{
    public class Pawn : Piece
    {
        protected Pawn(PieceType pieceType, PlayerKind playerKind)
            : base(pieceType, playerKind)
        {
        }

        public override List<PossibleMove> GetPossibleMoves(Position currentPosition, Board board)
        {
            List<PossibleMove> result = new List<PossibleMove>();

            // Construct a direction based on the player kind.
            int direction = PlayerKind == PlayerKind.White ? +1 : -1;

            // The one of move is always possible if the target position is free
            AddPositionIfNotOccupied(result, currentPosition.IncrementRow(direction), board);

            // If the pawn is on it's initial position we have another option.
            if (IsInitialPosition(currentPosition))
            {
                AddPositionIfNotOccupied(result, currentPosition.IncrementRow(2 * direction), board);
            }

            // First, checking the first diagonal
            Position firstDiagonal = currentPosition.Increment(rowIncrement: direction, columnIncrement: +1);
            AddPositionIfOccupiedByTheOpponent(result, firstDiagonal, board);

            // Now, the second diagonal
            Position secondDiagonal = currentPosition.Increment(rowIncrement: direction, columnIncrement: -1);
            AddPositionIfOccupiedByTheOpponent(result, secondDiagonal, board);

            // Checking 'en passat'.
            AddEnPassatMoveIfPossible(result, firstDiagonal, direction, board);
            AddEnPassatMoveIfPossible(result, secondDiagonal, direction, board);

            return result;
        }

        private void AddEnPassatMoveIfPossible(List<PossibleMove> result, Position firstDiagonal, int direction, Board board)
        {
            if (board.IsValidPosition(firstDiagonal))
            {
                Position possibleOpponentsPawnPosition = firstDiagonal.IncrementRow(FlipDirection(direction));
                var targetPiece = board.GetPieceByPosition(possibleOpponentsPawnPosition);
                if (targetPiece != null &&
                    targetPiece.PlayerKind == OpponentKind &&
                    targetPiece.PieceType == PieceType.Pawn &&
                    board.LastMoveTargetLocation(possibleOpponentsPawnPosition))
                {
                    result.Add(PossibleMove.Attack(firstDiagonal, possibleOpponentsPawnPosition));
                }
            }
        }

        private static int FlipDirection(int direction)
        {
            return direction * -1;
        }

        private bool IsInitialPosition(Position position)
        {
            // TODO: this needs to be changed! Because we would like to have "higher"-level methods to determine that.
            return (position.Row == 1 && PlayerKind == PlayerKind.White) ||
                (position.Row == 6 && PlayerKind == PlayerKind.Black);
        }

        private void AddPositionIfOccupiedByTheOpponent(List<PossibleMove> positions, Position targetPositionCandidate, Board board)
        {
            if (board.IsValidPosition(targetPositionCandidate) && board.IsOccupiedBy(OpponentKind, targetPositionCandidate))
            {
                positions.Add(PossibleMove.Attack(targetPositionCandidate));
            }
        }

        private void AddPositionIfNotOccupied(List<PossibleMove> positions, Position targetPositionCandidate, Board board)
        {
            if (!board.IsOccupied(targetPositionCandidate))
            {
                positions.Add(PossibleMove.Move(targetPositionCandidate));
            }
        }

        private PlayerKind OpponentKind => PlayerKind == PlayerKind.Black ? PlayerKind.White : PlayerKind.Black;
    }
}
