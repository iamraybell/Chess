using System.Collections.Generic;

namespace Chess
{
    public interface IPiece
    {
        int Row { get; }
        int Column { get; }

        List<List<int>> GetPossibleMoves();
        void SetPosition(int row, int column);
    }
}