using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class Piece //: IPiece
    {
        private List<MoveSet> baseMoveSet;
        public PlayerKind PlayerKind { get; }
        public PieceType PieceType { get; private set; }
 
        //public bool Continuous { get; private set; }
        // public IPlayer Owner { get; }
        // public Position Position { get; set; }

        public Piece(PieceType pieceType, PlayerKind playerKind, List<MoveSet> moveSet)
        {
            PieceType = pieceType;
            baseMoveSet = moveSet;

            //this.Continuous = continuous;
            // Position = position;
            // Owner = owner;
        }


        public virtual List<MoveSet> GetPossibleMoves(Board board)
        {
            return baseMoveSet;
        }
    }

    public class Pawn : Piece
    {

    }
}
