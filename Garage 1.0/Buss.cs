using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    class Buss:Vehicle
    {
        public int Length { get; set; }
        public int Height { get; set; }

        public Buss(int lenght, int height, string regnr, string colour, int numberOfWheel)
        {
            Length = lenght;
            Height = height;
            Regnr = regnr;
            Colour = colour;
            NumberOfWheels = numberOfWheel;           
        }

        public override string ToString()
        {
            return ("Buss:      " + " Regnr:" + this.Regnr + ", Färg:" + this.Colour + ", Hjul:" + this.NumberOfWheels + ", Längd:" + this.Length + ", Höjd:" + this.Height);
        }
    }
}
