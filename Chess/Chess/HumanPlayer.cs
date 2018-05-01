using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class HumanPlayer : IPlayer
    {
        public PlayerKind Color { get; private set; }
        public string Name { get; private set; }


        public HumanPlayer(string name,PlayerKind color)
        {
            Name = name;
            Color = color;

        }
    }
}
