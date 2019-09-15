using System;
using System.Collections.Generic;

namespace TestConsole
{
    public abstract class AstronomicalObject
    {
        public string Name { get; set; }
        public double Radius { get; set; }
        public double Weight { get; set; }
        public double Temperature { get; set; }

        public Dictionary<string, double> Composition = new Dictionary<string, double>();

        public double GetDiameter()
        {
            return this.Radius * 2;
        }
        public double GetEquatorLength()
        {
            return 2 * this.Radius * Math.PI;
        }
        public void GetAxisRotationSpeed()
        {
            return;
        }
        public void GetOrbitRotationSpeed()
        {
            return;
        }

        public AstronomicalObject(string name, double radius, double weight, double temperature)
        {
            Name = name;
            Radius = radius;
            Weight = weight;
            Temperature = temperature;
        }
    }
}
