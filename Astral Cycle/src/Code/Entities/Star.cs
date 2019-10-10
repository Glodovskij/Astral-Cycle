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

    public class Star : AstronomicalObject
    {
        private StarType type;
        public StarType Type
        {
            get { return type; }
            set { type = value; }
        }

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

        public void SetTemperatureZones()
        {
            CriticalHotZone = new Tuple<double, double>(
                Temperature,
                Temperature - Temperature * _criticalHotPercent
                );

            HotZone = new Tuple<double, double>(
                CriticalHotZone.Item2,
                CriticalHotZone.Item2 - Temperature * _hotPercent
                );
            SuitableZone = new Tuple<double, double>(
                HotZone.Item2,
                HotZone.Item2 - Temperature * _suitablePercent
                );
            ColdZone = new Tuple<double, double>(
                SuitableZone.Item2,
                SuitableZone.Item2 - Temperature * _coldPercent
                );
            CriticalColdZone = new Tuple<double, double>(
                ColdZone.Item2,
                ColdZone.Item2 - Temperature * _criticalColdPercent
                );

            //Console.WriteLine("Extreme hot zone = {0} - {1}\nHot zone = {2} - {3}\nSuitable zone ={4} - {5}\nCold zone={6} - {7}\nExtreme cold zone = {8} - {9}",
            //    CriticalHotZone.Item1, CriticalHotZone.Item2, 
            //    HotZone.Item1, HotZone.Item2,
            //    SuitableZone.Item1, SuitableZone.Item2,
            //    ColdZone.Item1,ColdZone.Item2,
            //    CriticalColdZone.Item1, CriticalColdZone.Item2);
        }

        #endregion

        public override double Temperature
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
                base.Temperature = temperatureValue;

                return base.Temperature;
            }

        }

        public Star(string name, double radius, double weight, StarType starType, Point position)
            : base(name, radius, weight, position)
        {
            type = starType;
            SetTemperatureZones();
        }
        public Star()
        {

        }
    }
}
