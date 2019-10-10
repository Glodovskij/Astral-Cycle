using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral_Cycle.src.Code.Entities
{
    public enum PlanentsType
    {
        EarthLike, //Подобные земле
        GiantLike, //Планеты гиганты
        DwarfLike //Карлики
    }
    public class Planet : AstronomicalObject
    {
        public PlanentsType PlanentsType { get; set; }

        private Dictionary<string, float> atmosphere = new Dictionary<string, float>();
        private List<Animal> herbivorous = new List<Animal>();
        private List<Animal> omnivores = new List<Animal>();
        private List<Animal> predatory = new List<Animal>();
        private List<Plant> plants = new List<Plant>();

        public override double Temperature { get => base.Temperature; set => base.Temperature = value; }

        public bool IsHabitable { get; set; }



        public List<Animal> Herbivorous
        {
            get
            {
                return herbivorous;
            }
            set
            {
                if (IsHabitable)
                    herbivorous = value;
            }
        }
        public List<Animal> Omnivores {
            get { return omnivores; }
            set
            {
                if (IsHabitable)
                    omnivores = value;
            }
        }
        public List<Animal> Predatory {
            get { return predatory; }
            set
            {
                if (IsHabitable)
                    predatory = value;
            }
        }
        public List<Plant> Plants
        {
            get { return plants; }
            set
            {
                if (IsHabitable)
                    plants = value;
            }

        }

        public Planet(string name, double radius, double weight, double temperature, Point position,
            bool isHabitable, Dictionary<string, float> atmosphere)
            : base(name, radius, weight, position)
        {
            Temperature = temperature;

            IsHabitable = isHabitable;

            this.atmosphere = atmosphere;
        }
        public Planet()
        {

        }

    }
}
