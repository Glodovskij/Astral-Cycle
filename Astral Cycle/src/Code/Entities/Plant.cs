using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral_Cycle.src.Code.Entities
{
    class Plant : Organism
    {
        public Plant(string name, int hpTicks, Texture2D texture)
            :base(name, hpTicks, texture)
        {

        }
    }
}
