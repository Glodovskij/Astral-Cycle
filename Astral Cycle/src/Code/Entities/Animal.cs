using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral_Cycle.src.Code.Entities
{
    enum AnimalsType
    {
       /*травоядный*/ Herbivorous, Predatory
    }
    class Animal : Organism
    {
        public AnimalsType AnimalType { get; set; }

        public Animal(AnimalsType animalType, string name, int hpTicks, Texture2D texture)
            :base(name, hpTicks, texture)
        {
            AnimalType = animalType;
        }

        public bool Eat(Animal animal)
        {
            //Animan eats another animal with 50 % chanse if:
            //  1.Predator eats herbivorous
            //  2.Predator eats another predator if victim is another kind of predator
            // returning value: 
            // true - eats
            // false - not
            Random rand = new Random();
            if(AnimalType.Equals(AnimalsType.Predatory))
            {
                if(animal.AnimalType.Equals(AnimalsType.Herbivorous))
                {
                    if (rand.Next(1, 2) == 1)
                    {
                        HPTicks = 2;
                        return true;
                    }
                }
                else
                {
                    if (animal.Name != Name)
                        if (rand.Next(1, 2) == 1)
                        {
                            HPTicks = 2;
                            return true;
                        }
                }
            }
            return false;
        }
        public bool Eat(Plant plant)
        {
            Random rand = new Random();

            if (rand.Next(1, 2) == 1)
                return true;

            return false;
        }
    }
}
