using System.Collections.Generic;

namespace Chess
{
    public interface IBoard
    {
        int NumColumns { get; }
        int NumRows { get; }
        IPiece[,] contents { get; }
        
        List<Position> GetPossibleMoves(Position position);
        bool CheckSpaceforOpposingTeamPiece(Position position, IPiece piece);
        bool SpaceIsEmpty(Position position);
    }
}