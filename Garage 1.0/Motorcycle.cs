using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    class Motorcycle:Vehicle
    {
        public int MotorEffect { get; set; }
        public string Kind { get; set; }

        public Motorcycle(int motorEffect, string kind, string regnr, string colour, int numberOfWheel)
        {
            MotorEffect = motorEffect;
            Kind = kind;
            Regnr = regnr;
            Colour = colour;
            NumberOfWheels = numberOfWheel;           
        }

        public override string ToString()
        {
            return ("Motorcykel:" + " Regnr:" + this.Regnr + ", Färg:" + this.Colour + ", Hjul:" + this.NumberOfWheels + ", Motoreffekt:" + this.MotorEffect + ", Typ:" + this.Kind);
        }
    }
}
