using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MoveSet
    {
        public delegate bool validatorFunction(IBoard board);
        public validatorFunction Validator{ get; }
        public int RowModifier{ get; }
        public int ColumnModifier{ get; }

        public MoveSet(int rowModifier, int columnModifier, validatorFunction validator)
        {
            RowModifier = rowModifier;
            ColumnModifier = columnModifier;
            Validator = validator;
        }

    }
}
