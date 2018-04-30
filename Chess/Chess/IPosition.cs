using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    interface IPosition
    {
         int Row { get; }
         int Column { get; }
    }
}
