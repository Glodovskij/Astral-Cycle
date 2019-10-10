using Astral_Cycle.src.Code.Entities;
using Astral_Cycle.src.Code.Generator;
using System;

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
            Star star;
            Generator.GenerateStar(out star);

            Console.WriteLine(star.ColdZone);
            Console.WriteLine(star.CriticalColdZone);
            Console.WriteLine(star.CriticalHotZone);
            Console.WriteLine(star.HotZone);
            Console.WriteLine(star.Name);
            Console.WriteLine(star.Position);
            Console.WriteLine(star.Radius);
            Console.WriteLine(star.SuitableZone);
            Console.WriteLine(star.Temperature);
            Console.WriteLine(star.Type);
            Console.WriteLine(star.Weight);
            //using (var game = new Game1())
              //  game.Run();
        }
    }
}
