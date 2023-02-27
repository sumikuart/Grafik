using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TK_FirstWindow.GameCode;

namespace TK_FirstWindow
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //This makes a Window, from the class you made (Look under GameCode folder)
            using (Game game = new Game(800,600, "LearnOpTK"))
            {
                game.Run(60.0);
            }
        }
    }
}
