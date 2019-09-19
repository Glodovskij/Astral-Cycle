using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral_Cycle.src.Code.Entities
{
    enum PlanentsType
    {
        EarthLike, //Подобные земле
        GiantLike, //Планеты гиганты
        DwarfLike //Карлики
    }
    class Planet : AstronomicalObject
    {
        public PlanentsType PlanentsType { get; set; }

        private Dictionary<string, float> atmosphere = new Dictionary<string, float>();

        public bool IsHabitable { get; set; }

        public List<Animal> Herbivorous { get; set; } = new List<Animal>();
        public List<Animal> Omnivores { get; set; } = new List<Animal>();
        public List<Animal> Predatory { get; set; } = new List<Animal>();
        public List<Plant> Plants { get; set; } = new List<Plant>();

        public Planet(string name, double radius, double weight, double temperature, Point position, 
            bool isHabitable, Dictionary<string, float> atmosphere, List<Animal> herbivorous,
            List<Animal> omnivores, List<Animal> predatory, List<Plant> plants)
            :base(name, radius, weight, temperature, position)
        {
            Herbivorous = herbivorous;
            Omnivores = omnivores;
            Predatory = predatory;
            Plants = plants;

            IsHabitable = isHabitable;

            this.atmosphere = atmosphere;
        }

    }
}
