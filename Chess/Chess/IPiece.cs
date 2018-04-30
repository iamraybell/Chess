using System.Collections.Generic;

namespace Chess
{
    public interface IPiece
    {

        bool Continuous { get; }
        PieceType PieceType { get; }
        List<IMoveSet> MoveSet{ get; }
        IOwner Owner { get; }

        
    }
}