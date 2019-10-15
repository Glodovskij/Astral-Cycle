using Astral_Cycle.src.Code.Entities;
using Astral_Cycle.src.Code.Generator;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Astral_Cycle
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
