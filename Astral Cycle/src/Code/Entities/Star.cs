using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral_Cycle.src.Code.Entities
{
    public enum StarType
    {
        Blue,
        Yellow,
        Red
    }

    public struct StarCharacteristics
    {
        const double KelvinCelsiusDifference = 273.15;
        private StarType type;

        public StarType Type
        {
            get { return type; }
            set { type = value; }
        }
        
        public double KelvinTemperature
        {
            get
            {
                double temperatureValue = 0;
                Random rnd = new Random();
                switch(this.Type)
                {
                    case StarType.Blue:
                        temperatureValue = rnd.Next(7500, 10000);
                        break;
                    case StarType.Yellow:
                        temperatureValue = rnd.Next(5000, 7499);
                        break;
                    case StarType.Red:
                        temperatureValue = rnd.Next(2000, 4999);
                        break;
                }
                return temperatureValue;
            }
        }

        public double CelsiusTemperature
        {
            get { return KelvinTemperature - KelvinCelsiusDifference; }
        }

        public double FarenheitTemperature
        {
            get { return (KelvinTemperature - KelvinCelsiusDifference) * 9/5 + 32; }
        }

        public StarCharacteristics(StarType type)
        {
            this.type = type;
        }
    }




    public class Star: AstronomicalObject
    {
        public StarCharacteristics Characteristics;

        public Star(string name, double radius, double weight, StarCharacteristics characteristics, Point position)
            :base(name,radius,weight, characteristics.KelvinTemperature, position)
        {
            Characteristics = characteristics;
        }
    }
}
