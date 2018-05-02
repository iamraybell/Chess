using System.Collections.Generic;

namespace Chess
{
    public interface IPiece
    {

        bool Continuous { get; }
        PieceType PieceType { get; }
        List<MoveSet> MoveSet{ get; }
        IPlayer Owner { get; }
        Position Position { get; set; }
 
    }
}