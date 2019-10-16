using Astral_Cycle.src.Code.Entities;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Astral_Cycle.src.Code.Generator
{
    using Atmos = Dictionary<AtmosphereElement, int>;
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
            star = new Star()
            {
                Type = (StarType)randomizer.Next(0, Enum.GetValues(typeof(StarType)).Length),
                Name = "Object-" + randomizer.Next(1, 100),
                Radius = starRadius,
                Weight = 1.989E30 * starWeight,
                Position = Point.Zero
            };
            star.SetTemperatureZones();

        }

        public static void GeneratePlanet(out Planet planet, Star star)
        {
            Random randomizer = new Random();
            Atmos atmosphere = new Atmos();
            GenerateCarbonDioxide(ref atmosphere);
            GenerateAtmosphere(ref atmosphere);

            planet = new Planet()
            {
                PlanentsType = (PlanentsType)randomizer.Next(0, Enum.GetValues(typeof(PlanentsType)).Length),
                Name = "Object-" + randomizer.Next(1, 100),
                Atmosphere = atmosphere,
                Position = new Point(randomizer.Next(10, 100), 0),
                Radius = randomizer.Next(2000, 70000),
                Temperature = 100,
                Weight = randomizer.NextDouble() * (1.898E27 - 3.285E23 + 3.285E23),
                
        };
           // planet.Temperature = ((star.CriticalHotZone.Item1 + star.CriticalColdZone.Item2) / 100 * )
            planet.IsLifePossible = CheckTempZone(planet.Position, star);
            planet.IsHabitable = CheckAtmosphere(planet.IsLifePossible, planet.Atmosphere);
            if(planet.IsHabitable)
            {
                List<Animal> kek = new List<Animal>(), bek = new List<Animal>(), mek = new List<Animal>();
                List<Plant> puk = new List<Plant>();
                HabitatePlanet(ref kek, AnimalsType.Herbivorous);
                HabitatePlanet(ref bek, AnimalsType.Omnivores);
                HabitatePlanet(ref mek, AnimalsType.Predatory);
                HabitatePlanet(ref puk);

                planet.Herbivorous = kek;
                planet.Omnivores = bek;
                planet.Predatory = mek;

                planet.Plants = puk;

            }
        }

        private static bool CheckTempZone(Point point, Star star)
        {
            double temperatureForPoint = (star.CriticalHotZone.Item1 + star.CriticalColdZone.Item2) / 100;
            if (point.X * temperatureForPoint <= star.SuitableZone.Item1 && point.X * temperatureForPoint >= star.SuitableZone.Item2)
                return true;
            return false;
        }

        /// <summary>
        /// First parameter is planet.IsLifePossible second is planet.Atmosphere
        /// </summary>
        private static bool CheckAtmosphere(bool isLifePossible, Atmos atmosphere)
        {
            if (atmosphere.ContainsKey(AtmosphereElement.Oxygen) && isLifePossible == true)
                if (atmosphere[AtmosphereElement.Oxygen] > 15)
                    return true;
            return false;
        }

        public static void GenerateCarbonDioxide(ref Atmos atmosphere)
        {
            Random randomizer = new Random();
            atmosphere.Add(AtmosphereElement.CarbonDioxide, randomizer.Next(1, 100));
        }

        public static void GenerateAtmosphere(ref Atmos atmosphere)
        {
            StackTrace stackTrace = new StackTrace();           // get call stack
            if(stackTrace.FrameCount > 1000)
            {
                atmosphere[AtmosphereElement.CarbonDioxide] = atmosphere[AtmosphereElement.CarbonDioxide] + 100 - atmosphere.Sum(x => x.Value);
                return;
            }

            Random randomizer = new Random();
            if (atmosphere.Sum(x => x.Value) >= 100)
            {
                return;
            }
            KeyValuePair<AtmosphereElement, int> atmospherePart = new KeyValuePair<AtmosphereElement, int>
                ((AtmosphereElement)randomizer.Next(0, Enum.GetValues(typeof(AtmosphereElement)).Length), randomizer.Next(1, 100 - atmosphere.Sum(x => x.Value) + 1));

            if (!atmosphere.ContainsKey(atmospherePart.Key))
                atmosphere.Add(atmospherePart.Key, atmospherePart.Value);

            GenerateAtmosphere(ref atmosphere);
        }
        public static void HabitatePlanet(ref List<Animal> thing, AnimalsType animalsType)
        {
            Random randomizer = new Random();
            int things = randomizer.Next(0, 1000);
            for(int i = 0; i < things; i++)
            {
                thing.Add(new Animal(animalsType, "Object_" + things, 10, null));
            }
        }
        public static void HabitatePlanet(ref List<Plant> thing)
        {
            Random randomizer = new Random();
            int things = randomizer.Next(0, 1000);
            for (int i = 0; i < things; i++)
            {
                thing.Add(new Plant("Object_" + things, 10, null));
            }
        }
    }
}

