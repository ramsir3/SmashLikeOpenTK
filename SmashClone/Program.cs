using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPlatformFighter.Driver;
using static OpenPlatformFighter.Common.Constants;

namespace OpenPlatformFighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(GameWidth, GameHeight);
            game.Run(60.0, 60.0);
        }
    }
}
