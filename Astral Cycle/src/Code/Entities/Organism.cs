using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Astral_Cycle.src.Code.Entities
{
    public class Organism
    {
        public string Name { get; set; }
        public int HPTicks { get; set; }
        public Texture2D Texture { get; set; }

        public Organism(string name, int hpTicks, Texture2D texture)
        {
            Name = name;
            HPTicks = hpTicks;
            Texture = texture;
        }
        public Organism()
        {

        }

        protected bool Breed(Organism organism)
        {
            //Chanse of birth of new animal if pair of  existence made love :D
            return true;
        }

        //protected virtual bool Eat(Organism organism)
    }
}
