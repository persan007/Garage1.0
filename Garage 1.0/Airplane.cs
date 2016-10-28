using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    class Airplane:Vehicle
    {
        public int NumberOfWings { get; set; }
        public int NumberOfPropeller { get; set; }

        public Airplane(int numberOfWings, int numberOfPropeller, string regnr, string colour, int numberOfWheel)
        {
            NumberOfWings = numberOfWings;
            NumberOfPropeller = numberOfPropeller;
            Regnr = regnr;
            Colour = colour;
            NumberOfWheels = numberOfWheel;           
        }

        public override string ToString()
        {
            return ("Flygplan:  " + " Regnr:" + this.Regnr + ", Färg:" + this.Colour + ", Hjul:" + this.NumberOfWheels + ", Vingar:" + this.NumberOfWings + " Propellrar:" + this.NumberOfPropeller);
        }

    }
}
