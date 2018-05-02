using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    /// <summary>
    /// An absolution position on a board.
    /// </summary>
    public class Position
    {
        public int Row { get; }

        public int Column { get; }

        // TODO: open question: what the requirements for row and column? Can they be out of board range?
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Position IncrementColumn(int columnIncrement)
        {
            return Increment(0, columnIncrement);
        }

        public Position Increment(int rowIncrement, int columnIncrement)
        {
            return new Position(Row + rowIncrement, Column + columnIncrement);
        }

        public Position IncrementRow(int rowIncrement)
        {
            return Increment(rowIncrement, 0);
        }
    }
}
