using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MainGameApp
    {


        public  IBoard curBoard;
        private static int playerCap  = 1;
        public int PlayerCap {
            get { return playerCap; }
                }
        public List<IPosition> possibleMoves;
        List<IPlayer> players;

        public MainGameApp(Board board, IPlayerSetUpProvider topPlayerSetup, IPlayer player)
        {
            List<IPlayer> players = new List<IPlayer>();
            curBoard = board;
            topPlayerSetup.Init(curBoard, player);
            players.Add(player);
        }


    }
}
