using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;

namespace ViewProvider
{
    class MainView: IViewProvider
    {
        public  MainGameApp GameApp;
        public Dictionary<PieceType, string> whiteImages;
        public List<IPosition> highlightedMoves;
        public MainView(MainGameApp gameApp)
        {
            GameApp = gameApp;
            whiteImages = new Dictionary<PieceType, string>();
            whiteImages.Add(PieceType.Pawn, "\u2659");
            whiteImages.Add(PieceType.King, "\u2654");
            whiteImages.Add(PieceType.Queen, "\u2655");
            whiteImages.Add(PieceType.Rook, "\u2656");
            whiteImages.Add(PieceType.Bishop, "\u2657");
            whiteImages.Add(PieceType.Knight, "\u2658");

        }

        public  static string GetName()
        {
            Console.WriteLine("What is your name?");
            string playerName = string.Empty;
            while (String.IsNullOrEmpty(playerName))
            {
                playerName = Console.ReadLine();
                if (playerName.Length < 1)
                {
                    Console.WriteLine("Name must be 1 char or more.");
                }


            }
            return playerName;
        }

        internal static ColorType GetColor()
        {
            
            string color = string.Empty;
            while (color.ToLower() != "white" || color.ToLower() != "black")
            {
                Console.WriteLine("What is your Color?");
                color = Console.ReadLine();
                color = color.ToString().ToLower();
                if (color == "white")
                {
                    return ColorType.White;
                }
                if (color == "black")
                {
                    return ColorType.Black;
                }
            }

            return ColorType.Black;
        }

        public static void Welcome()
        {
            Console.WriteLine("Welcome To Chess Game!");
            Console.Read();
        }
        public void StartDraw()
        {
            highlightedMoves = GameApp.GetPossibleMoves(2, 0);
            
            for(var RowIdx = 0; RowIdx < GameApp.curBoard.NumRows; RowIdx++)
            {
                for (var ColumnIdx = 0; ColumnIdx < GameApp.curBoard.NumColumns; ColumnIdx++)
                {
                    GenBorderStart();
                    DrawPiece(GameApp.curBoard.contents[RowIdx, ColumnIdx]);
                    GenBorderEnd();
                    if(ColumnIdx == GameApp.curBoard.NumColumns - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }
        }

        private void DrawPiece(IPiece piece)
        {
            
            if (piece == null)
            {
                
                Console.Write("  ");
                
            }
            else if(piece.Owner.Color == ColorType.White)
            {
                Console.Write(whiteImages[piece.PieceType]);
            }
            
        }

        private void GenBorderStart()
        {
            Console.Write("[");
        }
        private void GenBorderEnd()
        {
            Console.Write("]");
        }
    }
}
