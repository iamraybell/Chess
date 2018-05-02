using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class HumanPlayer : IPlayer
    {
        public ColorType Color { get;}
        public string Name { get; }

        public HumanPlayer(string name,ColorType color)
        {
            Name = name;
            Color = color;

        }
    }
}
