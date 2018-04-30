using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Piece : IPiece
    {

        
         public List<MoveSet> MoveSet { get; }

        public PieceType PieceType { get; private set; }
        public bool Continuous { get; private set; }
        public IPlayer Owner { get; }
        public IPosition Position { get; set; }

        /// <summary>
        /// Constructor. Takes in the  pieceType, moveSet, and continuous.
        /// </summary>
        public Piece(PieceType pieceType, List<MoveSet> moveSet, bool continuous, IPosition position, IPlayer owner)
        {
            this.PieceType = pieceType;
            this.MoveSet = moveSet;
            this.Continuous = continuous;
            Position = position;
            Owner = owner;
        }
         


    }
    
}
