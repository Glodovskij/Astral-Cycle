using Astral_Cycle.src.Code.Entities.Animals.Animals;

namespace Astral_Cycle.src.Code.Entities.Animals.Factories
{
    class HerbivorousFactory : IAnimalFactory
    {
        public IOrganism Create()
        {
            return new Herbivorous();
        }
    }
}
