using Astral_Cycle.src.Code.Entities;
using System;
using Microsoft.Xna.Framework;

namespace Astral_Cycle.src.Code.Generator
{
    public class Generator
    {
        private Random randomizer = new Random();

        public int GetPlanetNumber()
        {
            return randomizer.Next(1, 10);
        }

        public static void GenerateStar(out Star star)
        {
            Random randomizer = new Random();
            double starRadius = randomizer.Next(347755, 1391020);
            double starWeight = (starRadius * 1.989E30) / 695510;
            star = new Star() {
                Type = (StarType)randomizer.Next(0, Enum.GetValues(typeof(StarType)).Length),
                Name = "Object-" + randomizer.Next(1, 100),
                Radius = starRadius,
                Weight = 1.989E30 * starWeight,
                Position = Point.Zero
            };

        }
        
    }
}
