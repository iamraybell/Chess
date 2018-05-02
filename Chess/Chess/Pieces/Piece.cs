using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class Piece { //: IPiece    {

        public PlayerKind PlayerKind { get; }
        public PieceType PieceType { get;}
 
        //public bool Continuous { get; private set; }
        // public IPlayer Owner { get; }
        // public Position Position { get; set; }

        protected Piece(PieceType pieceType, PlayerKind playerKind)
        {
            PieceType = pieceType;
            PlayerKind = playerKind;
        }

        public abstract List<PossibleMove> GetPossibleMoves(Position currentPosition, Board board);
    }
}
