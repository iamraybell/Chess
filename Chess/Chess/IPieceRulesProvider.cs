using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public interface IPieceRulesProvider
    {
        void Init(IBoard board, IPlayer player);

    }
}
