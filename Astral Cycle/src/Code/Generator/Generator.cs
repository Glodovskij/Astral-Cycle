using Astral_Cycle.src.Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral_Cycle.src.Code.Generator
{
    public class Generator
    {
        private Random randomizer = new Random();

        public int GetPlanetNumber()
        {
            return randomizer.Next(1, 10);
        }

        /*public void GenerateStar(out Star star)
        {
            double starRadius = randomizer.Next(347755, 1391020);
            double starWeight = (starRadius * 1.989E30) / 695510;
            star = new Star() {
                Name = "Object-" + randomizer.Next(1, 100),
                Radius = starRadius,
                Weight = 1.989E30 * starWeight,
                //Temperature = StarCharacteristics,
                
                
            };

        }*/
        
    }
}
