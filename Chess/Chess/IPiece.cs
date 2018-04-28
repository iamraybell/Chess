using System.Collections.Generic;

namespace Chess
{
    public interface IPiece
    {
        int Row { get; }
        int Column { get; }
        int RowLimit { get;  }
        int ColumnLimit { get; }
        bool Continuous { get; }
        PieceType PieceType { get; }

        List<List<int>> GetPossibleMoves();
        void SetPosition(int row, int column);
    }
}