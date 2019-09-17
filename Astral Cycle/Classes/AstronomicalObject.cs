using Microsoft.Xna.Framework;
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
        //Насчет пересчета позиции:
        //1. Вариант поставить все на Event и создать метод на подобии OnPositionChanged()
        //2. Создать метод ChangePosition(Point newPosition) и вызывать его при смене позиции
        public Point Position { get; set; }

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

        //Position можно исключить из конструктора, но тогда стартовой точкой все объекты должны иметь (0,0)
        public AstronomicalObject(string name, double radius, double weight, double temperature, Point position)
        {
            Name = name;
            Radius = radius;
            Weight = weight;
            Temperature = temperature;
            Position = position;
        }
    }
}
