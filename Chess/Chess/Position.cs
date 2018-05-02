using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Position
    {
        public int Row { get; }

        public int Column { get; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Position Move(int rowModifier, int columnModifier)
        {
            return new Position(Row + rowModifier, Column + columnModifier);
        }
    }
}
