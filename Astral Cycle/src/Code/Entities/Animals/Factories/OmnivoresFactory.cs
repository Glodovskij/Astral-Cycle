using Astral_Cycle.src.Code.Entities.Animals.Animals;

namespace Astral_Cycle.src.Code.Entities.Animals.Factories
{
    class OmnivoresFactory : IAnimalFactory
    {
        public IOrganism Create()
        {
            return new Omnivores();
        }
    }
}
