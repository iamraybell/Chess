using System.Collections.Generic;

namespace Chess
{
    public interface IBoard
    {
        int NumColumns { get; }
        int NumRows { get; }
        IPiece[,] contents { get; }
        
        List<Position> GetPossibleMoves(IPiece Piece);
        bool CheckSpaceforOpposingTeamPiece(Position position, IPiece piece);
    }
}