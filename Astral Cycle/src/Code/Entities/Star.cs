using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astral_Cycle.src.Code.Entities
{
    enum StarType
    {
        Blue,
        Yellow,
        Red
    }

    struct StarCharacteristics
    {
        const double _KelvinCelsiusDifference = 273.15;

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
                switch (this.Type)
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
            get { return KelvinTemperature - _KelvinCelsiusDifference; }
        }

        public double FarenheitTemperature
        {
            get { return (KelvinTemperature - _KelvinCelsiusDifference) * 9 / 5 + 32; }
        }

        public StarCharacteristics(StarType type)
        {
            this.type = type;
        }
    }




    class Star : AstronomicalObject
    {
        public StarCharacteristics Characteristics;

        #region Temperature zones
        #region Zones percentage
        //TODO: do temperature amplifier for every star type
        const double _criticalHotPercent = 0.1;
        const double _hotPercent = 0.3;
        const double _suitablePercent = 0.2;
        const double _coldPercent = 0.3;
        const double _criticalColdPercent = 0.1;
        #endregion

        Tuple<double, double> _criticallyHotTemperatureZone;
        Tuple<double, double> _hotTemperatureZone;
        Tuple<double, double> _suitableTemperatureZone;
        Tuple<double, double> _coldTemperatureZone;
        Tuple<double, double> _criticallyColdTemperatureZone;

        public Tuple<double, double> CriticalHotZone
        {
            get { return _criticallyHotTemperatureZone; }
            set { _criticallyHotTemperatureZone = value; }
        }
        public Tuple<double, double> HotZone
        {
            get { return _hotTemperatureZone; }
            set { _hotTemperatureZone = value; }
        }
        public Tuple<double, double> SuitableZone
        {
            get { return _suitableTemperatureZone; }
            set { _suitableTemperatureZone = value; }
        }
        public Tuple<double, double> ColdZone
        {
            get { return _coldTemperatureZone; }
            set { _coldTemperatureZone = value; }
        }
        public Tuple<double, double> CriticalColdZone
        {
            get { return _criticallyColdTemperatureZone; }
            set { _criticallyColdTemperatureZone = value; }
        }
        #endregion

        public void SetTemperatureZones()
        {
            CriticalHotZone = new Tuple<double, double>(
                Characteristics.KelvinTemperature,
                Characteristics.KelvinTemperature - Characteristics.KelvinTemperature * _criticalHotPercent
                );

            HotZone = new Tuple<double, double>(
                CriticalHotZone.Item2,
                CriticalHotZone.Item2 - Characteristics.KelvinTemperature * _hotPercent
                );
            SuitableZone = new Tuple<double, double>(
                HotZone.Item2,
                HotZone.Item2 - Characteristics.KelvinTemperature * _suitablePercent
                );
            ColdZone = new Tuple<double, double>(
                SuitableZone.Item2,
                SuitableZone.Item2 - Characteristics.KelvinTemperature * _coldPercent
                );
            CriticalColdZone = new Tuple<double, double>(
                ColdZone.Item2,
                ColdZone.Item2 - Characteristics.KelvinTemperature * _criticalColdPercent
                );

            //Console.WriteLine("Extreme hot zone = {0} - {1}\nHot zone = {2} - {3}\nSuitable zone ={4} - {5}\nCold zone={6} - {7}\nExtreme cold zone = {8} - {9}",
            //    CriticalHotZone.Item1, CriticalHotZone.Item2, 
            //    HotZone.Item1, HotZone.Item2,
            //    SuitableZone.Item1, SuitableZone.Item2,
            //    ColdZone.Item1,ColdZone.Item2,
            //    CriticalColdZone.Item1, CriticalColdZone.Item2);
        }

        public Star(string name, double radius, double weight, StarCharacteristics characteristics, Point position)
            : base(name, radius, weight, characteristics.KelvinTemperature, position)
        {
            Characteristics = characteristics;
            SetTemperatureZones();
        }
    }
}
