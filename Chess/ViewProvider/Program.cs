using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;

namespace ViewProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Black;
            MainView.Welcome();
            var name = MainView.GetName();
            var color = MainView.GetColor();
            var curMainView = new MainView(new MainGameApp(new Board(), new TopPlayerPieceRulesProvider(), new HumanPlayer(name, color)));
            curMainView.StartDraw();
            Console.Read();
        }
    }
}
