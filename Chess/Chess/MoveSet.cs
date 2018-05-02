using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MoveSet : IMoveSet
    {
        
        private validatorFunction Validator{ get; }
        public int RowModifier{ get; }
        public int ColumnModifier { get; }
        public delegate bool validatorFunction(IBoard board, IPiece piece);

        public MoveSet(int rowModifier, int columnModifier, validatorFunction validator)
        {
            RowModifier = rowModifier;
            ColumnModifier = columnModifier;
            Validator = validator;
        }

        public bool RunValidator(IBoard board, IPiece piece)
        {
            if(Validator == null)
            {
                return true;
            }
            bool resultsFromValidator = Validator(board, piece);
            return resultsFromValidator;
        }
    }
}
