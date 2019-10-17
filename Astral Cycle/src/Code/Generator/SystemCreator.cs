using Astral_Cycle.src.Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral_Cycle.src.Code.Generator
{
    public class SystemCreator
    {
        //генерация тиков должна быть здесь
        public void LifeCycle()
        {
            foreach (var planet in planetsList)
            {
                if (planet.IsLifePossible)
                {
                    if (planet.IsHabitable)
                    {
                        PlantTick(planet);
                        AnimalTick(planet);
                    }
                    else
                    {
                        //generate life here
                    }
                }

            }
        }

        void PlantTick(Planet planet)
        {
            //generate plant tick
            //It can reproduce itself or do nothing
        }

        void AnimalTick(Planet planet)
        {
            Random rnd = new Random();
            foreach (var animal in planet.Herbivorous)
            {
                if (animal.Eat(planet.Plants[rnd.Next(0, planet.Plants.Count)]))
                {
                    //plant dies
                    animal.HPTicks++;
                    Console.WriteLine("Herbivorous " + animal.Name + " eats plant.");
                }
                else
                {
                    animal.HPTicks--;
                    Console.WriteLine("Herbivorous " + animal.Name + " starving.");
                }
            }
            foreach (var animal in planet.Predatory)
            {
                if (Convert.ToBoolean(rnd.Next(0, 2)))
                {
                    var huntedAnimal = planet.Herbivorous[rnd.Next(0, planet.Herbivorous.Count)];
                    if (animal.Eat(huntedAnimal))
                    {
                        //hunted animal dies
                        animal.HPTicks++;
                        Console.WriteLine("Predator eats Herbivorous " + huntedAnimal.Name);
                    }
                    else
                    {
                        //hunted animal escapes
                        animal.HPTicks--;
                        Console.WriteLine("Predator " + animal.Name + " starving.");
                    }
                }
                else
                {
                    var huntedAnimal = planet.Omnivores[rnd.Next(0, planet.Omnivores.Count)];
                    if (animal.Eat(huntedAnimal))
                    {
                        //hunted animal dies and injures predator
                        animal.HPTicks--;
                        //if predator stays alive
                        animal.HPTicks++;
                        Console.WriteLine("Predator " + animal.Name + " battles Omnivorous " + huntedAnimal.Name);
                    }
                    else
                    {
                        //hunted animal escapes
                        animal.HPTicks--;
                        Console.WriteLine("Predator " + animal.Name + " starving.");
                    }
                }

            }
            foreach (var animal in planet.Omnivores)
            {
                if (Convert.ToBoolean(rnd.Next(0, 2)))
                {
                    if (animal.Eat(planet.Plants[rnd.Next(0, planet.Plants.Count)]))
                    {
                        //plant dies
                        animal.HPTicks++;
                        Console.WriteLine("Omnivorous " + animal.Name + " eats plant.");
                    }
                    else
                    {
                        animal.HPTicks--;
                        Console.WriteLine("Omnivorous " + animal.Name + " starving.");
                    }
                }
                else
                {
                    if (Convert.ToBoolean(rnd.Next(0, 2)))
                    {
                        var huntedAnimal = planet.Herbivorous[rnd.Next(0, planet.Herbivorous.Count)];
                        if (animal.Eat(huntedAnimal))
                        {
                            //hunted animal dies
                            animal.HPTicks++;
                            Console.WriteLine("Omnivorous eats Herbivorous " + huntedAnimal.Name);
                        }
                        else
                        {
                            //hunted animal escapes
                            animal.HPTicks--;
                            Console.WriteLine("Omnivorous " + animal.Name + " starving.");
                        }
                    }
                    else
                    {
                        var huntedAnimal = planet.Predatory[rnd.Next(0, planet.Predatory.Count)];
                        if (animal.Eat(huntedAnimal))
                        {
                            //hunted animal dies and injures predator
                            animal.HPTicks--;
                            //if predator stays alive
                            animal.HPTicks++;
                            Console.WriteLine("Omnivorous " + animal.Name + " battles Predator " + huntedAnimal.Name);
                        }
                        else
                        {
                            //hunted animal escapes
                            animal.HPTicks--;
                            Console.WriteLine("Omnivorous " + animal.Name + " starving.");
                        }
                    }
                }
            }
            //switch (animal.AnimalType)
            //{
            //    case AnimalsType.Herbivorous:
            //        animal.Eat(plant);
            //        //eats plant, or loses 1 health
            //        break;
            //    case AnimalsType.Predatory:
            //        //hurts herbivorous, or loses 1 health
            //        break;
            //    case AnimalsType.Omnivores:
            //        //eats plant or hurts other animals, or loses 1 health
            //        break;
            //}
        }
        //
        static List<Planet> planetsList = new List<Planet>();
        static Star star;

        public void DisplayStarInfo()
        {
            Console.WriteLine("Star :{0} ({1})\n Radius :{2}\n Weight :{3}\n Average temperature :{4}", star.Name, star.Type, star.Radius, star.Weight, star.Temperature);
        }

        public void DisplayPlanetsInfo()
        {
            int counter = 0;
            foreach (var item in planetsList)
            {
                counter++;
                if (item.IsHabitable)
                {
                    Console.WriteLine("Found life on {0}", counter);
                    Console.WriteLine("Planet :{0} ({1})\n Radius :{2}\n Weight :{3}\n Average temperature :{4} \n Is habitant {5}", item.Name, item.PlanentsType,
                    item.Radius, item.Weight, item.Temperature, item.IsHabitable);
                    Console.WriteLine("Plants: {0} \n Animals: \n Omnivores {1}, Herbivorous {2}, Predators {3}", item.Plants.Count, item.Omnivores.Count, item.Herbivorous.Count,
                        item.Predatory.Count);
                }
            }

        }

        void SpawnStar()
        {
            Generator.GenerateStar(out star);
        }

        void SpawnPlanet()
        {
            Planet planet;
            Generator.GeneratePlanet(out planet, star);
            planetsList.Add(planet);
        }

        public void SpawnSystem(int planetsAmount)
        {
            SpawnStar();
            for (int i = 0; i < planetsAmount; i++)
            {
                SpawnPlanet();
            }
            DisplayStarInfo();
            DisplayPlanetsInfo();
            LifeCycle();
        }
    }
}
