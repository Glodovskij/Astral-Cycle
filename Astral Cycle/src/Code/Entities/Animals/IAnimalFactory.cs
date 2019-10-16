using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral_Cycle.src.Code.Entities.Animals
{
    public interface IAnimalFactory
    {
        IOrganism Create();
    }
}
