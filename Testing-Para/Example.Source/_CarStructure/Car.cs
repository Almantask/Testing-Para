using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Source._CarStructure
{
    // Variation 2.2
    public class Car
    {
        private object Engine { get; }
        private object Body { get; }
        private object[] Tires { get; }
        public Color color { get; }

        public Car(object engine, object body, object[] tires, Color color)
        {
            // Null checks
            Engine = engine;
            Body = body;
            this.color = color;
            // Tire count check
            Tires = tires;
        }
    }
}
