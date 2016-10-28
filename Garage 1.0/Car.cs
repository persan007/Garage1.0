using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    class Car:Vehicle
    {
        public string Label { get; set; }
        public int KmHour { get; set; }

        public Car(string label, int kmHour, string regnr, string colour, int numberOfWheel)
        {
            Label = label;
            KmHour = kmHour;
            Regnr = regnr;
            Colour = colour;
            NumberOfWheels = numberOfWheel;           
        }

        public override string ToString()
        {
            return ("Bil:       " + " Regnr:" + this.Regnr + ", Färg:" + this.Colour + ", Hjul:" + this.NumberOfWheels + ", Märke:" + this.Label + ", Hastighet:" + this.KmHour + "k/h");
        }
    }
}
