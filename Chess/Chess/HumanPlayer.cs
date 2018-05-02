using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public interface IHumanPlayerController
    {
        Position SelectPosition(PlayerKind playerKind, Board board);
        Position MoveThePiece(Piece piece, Position selectedPosition);
    }

    public class HumanPlayer : IPlayer
    {
        private readonly IHumanPlayerController controller;

        public PlayerKind PlayerKind { get;}
        public string Name { get; }

        public HumanPlayer(string name, PlayerKind color, IHumanPlayerController controller)
        {
            Name = name;
            PlayerKind = color;
            this.controller = controller;
        }

        public bool MakeAMove(Board board)
        {
            // Select a piece on the board
            Position selectedPosition = controller.SelectPosition(PlayerKind, board);
            Debug.Assert(board.IsValidPosition(selectedPosition), "Selected position must belong to a board");

            // The piece should of a correct kind (player A can move only specific pieces, like only Black pieces or White pieces).
            Piece piece = board.GetPieceByPosition(selectedPosition);
            Debug.Assert(piece.PlayerKind == PlayerKind, "Selected piece must belong to a current player.");

            // Get all possible moves for a selected piece.
            // (potentially display the set of possible moves to give hints to a human player)
            var possibleMoves = piece.GetPossibleMoves(selectedPosition, board);
            if (possibleMoves.Count == 0)
            {
                // Can't move a selected piece.
                return false;
            }

            // Wait for a player to "pick" a move.
            Position targetPosition = controller.MoveThePiece(piece, selectedPosition);
            // Maybe to use a linq? Do we want to create a custom type to represent all possible moves?
            // Debug.Assert(possibleMoves.IsInTheList(targetPosition), "Target position should be part of the possible list");

            // Make the move itself
            board.MoveThePiece(selectedPosition, targetPosition);
            return true;
        }
    }
}
