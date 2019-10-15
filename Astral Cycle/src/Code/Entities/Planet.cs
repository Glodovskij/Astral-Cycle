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
    public enum AtmosphereElement
    {
        CarbonDioxide,
        Nitrogen,
        SulfurDioxide,
        Argon,
        Watervapor,
        CarbonMonoxide,
        Helium,
        Neon,
        HydrogenChlodire,
        Oxygen,
        Methane,
        Krypton
    }
    public class Planet : AstronomicalObject
    {
        public PlanentsType? PlanentsType { get; set; }

        private Dictionary<AtmosphereElement, int> atmosphere = new Dictionary<AtmosphereElement, int>();
        private List<Animal> herbivorous = new List<Animal>();
        private List<Animal> omnivores = new List<Animal>();
        private List<Animal> predatory = new List<Animal>();
        private List<Plant> plants = new List<Plant>();


        public override double Temperature { get => base.Temperature; set => base.Temperature = value; }


        public Dictionary<AtmosphereElement, int> Atmosphere
        {
            get { return Atmosphere; }
            set { atmosphere = value; }
        }


        public bool IsHabitable { get; set; }
        public bool IsLifePossible { get; set; }

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
            bool isHabitable, Dictionary<AtmosphereElement, int> atmosphere)
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
