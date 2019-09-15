using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using SharpSDL;
using Thread = System.Threading.Thread;

namespace GameEngineCore
{
    internal class Program
    {
        //private static int screenWidth = 160;
        //private static int screenHeight = 100;

        private static void Main(string[] args)
        {
            var engine = new Demo3d();
            engine.Run();

            //var tetris = new Tetris();
            //tetris.Run();
        }
    }
}