using System.Collections.Generic;

namespace Chess
{
    public interface IBoard
    {
        int NumColumns { get; }
        int NumRows { get; }
        List<IMoveSet> GetPossibleMoves(IPiece Piece);
    }
}