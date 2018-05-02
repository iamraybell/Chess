using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MainGameApp
    {
        public List<Position> possibleMoves;
        List<IPlayer> players;
        public  IBoard curBoard;
        private static int playerCap  = 1;

        public int PlayerCap {
            get { return playerCap; }
         }
        

        public MainGameApp(Board board, IPieceRulesProvider topPlayerSetup, IPlayer player)
        {
            List<IPlayer> players = new List<IPlayer>();
            curBoard = board;
            topPlayerSetup.Init(curBoard, player);
            players.Add(player);
        }

        public List<Position> GetPossibleMoves(Position position)
        {
            return  curBoard.GetPossibleMoves(position);
        }
    }
}
