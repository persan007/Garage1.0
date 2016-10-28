using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    class Boat:Vehicle
    {
        public string Typ { get; set; }
        public int MaxNumberOfPassengers { get; set; }

        public Boat(string typ, int maxNumberOfPassenger, string regnr, string colour, int numberOfWheel)
        {
            Typ = typ;
            MaxNumberOfPassengers = maxNumberOfPassenger;
            Regnr = regnr;
            Colour = colour;
            NumberOfWheels = numberOfWheel;           
        }

        public override string ToString()
        {
            return ("Båt:       " + " Regnr:" + this.Regnr + ", Färg:" + this.Colour + ", Hjul:" + this.NumberOfWheels + ", Modell:" + this.Typ + ", Passagerare:" + this.MaxNumberOfPassengers);
        }
    }

    
}
