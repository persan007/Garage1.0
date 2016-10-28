using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private List<Vehicle> vehicle;
        private int maxVehicleInGarage;

        public Garage()
        {           
            vehicle = new List<Vehicle>();

            maxVehicleInGarage = 8;    
            vehicle.Add(new Car("Porche", 100, "AbC123", "blå", 4));
            vehicle.Add(new Boat("Segelbåt", 10, "ERT123", "vit", 0));
            vehicle.Add(new Buss(20, 4, "FGG123", "röd", 6));
            vehicle.Add(new Motorcycle(35, "mellan", "TRG344", "vit", 2));
            vehicle.Add(new Airplane(2, 4, "BNG444", "gul", 4));
            vehicle.Add(new Car("Volvo", 100, "TRE123", "vit", 4));                   
        }

        

        //Lägger till ett fordon i garaget
        public void addVehicle(List<Vehicle> newVehicle)
        {            
             vehicle.Add(newVehicle.First());                                       
        }

        //Kollar om garaget är fullt
        public bool checkIsGarageFull()
        {
            bool isGarageFull = false;

            if (vehicle.Count == maxVehicleInGarage)
                isGarageFull = true;
                
            return isGarageFull;
        }

        //Tar bort ett fordon i garaget
        public string removeVehicle(string regnr)
        {
            int i = 0;
            bool finns = false;
            string answer = "";
            int removeNr = 0;

            foreach (Vehicle s in vehicle)
            {               
                if(regnr.ToUpper() == s.Regnr.ToUpper())
                {
                    removeNr = i;
                    finns = true;
                    answer = "Fordonet med registreringsnr " + regnr + " har lämnat garaget";
                }
                i++;    
            }

            if (finns == false)
                answer = "Det finns inget fordon med det registreringnumret i garaget";
            else
                vehicle.RemoveAt(removeNr);

            return answer;
        }

        //Kollar antalet fordon i garaget
        public int numberOfVehicle()
        {
            return vehicle.Count();
        }

        //Kollar antal fordon av en viss typ
        public List<string> numberOfSpecialVehicle(int nr)
        {           
            List<string> typ = new List<string>();
            string typs;

            foreach (Vehicle s in vehicle)
            {
                typs = s.GetType().ToString();
  
                if (typs == "Garage_1._0.Car" & nr == 1)
                    typ.Add(s.ToString());
                if (typs == "Garage_1._0.Boat" & nr == 2)
                    typ.Add(s.ToString());
                if (typs == "Garage_1._0.Buss" & nr == 3)
                    typ.Add(s.ToString());
                if (typs == "Garage_1._0.Airplane" & nr == 4)
                    typ.Add(s.ToString());
                if (typs == "Garage_1._0.Motorcycle" & nr == 5)
                    typ.Add(s.ToString());
            }                            
            return typ;            
        }
        
        //Sökning på regnr
        public string searchForRegnr(string regnr)
        {
            string feedback = "";            

            IEnumerable<Vehicle> query = from s in vehicle
                                         where s.Regnr.ToUpper() == regnr.ToUpper()
                                         select s;
            foreach (Vehicle s in query)
                feedback = s.ToString();

            if (feedback == "")
                feedback = "tyvärr så finns inte regnr: " + regnr + " i garaget";
            return feedback;
        }
        
        //Sökning på färg
        public List<string> searchForColour(string colour)
        {
            List<string> feedback = new List<string>();

            IEnumerable<Vehicle> query = from s in vehicle
                                         where s.Colour.ToUpper() == colour.ToUpper()
                                         select s;
            foreach (Vehicle s in query)
                feedback.Add(s.ToString());

            if (feedback.Count == 0)
                feedback.Add("Det finns inget fordon med färgen: " + colour + " i garaget");
            return feedback;
        }

        //Sökning antal hjul
        public List<string> searchNrOfWheels(string nrOfWheels)
        {
            List<string> feedback = new List<string>();

            IEnumerable<Vehicle> query = from s in vehicle
                                         where s.NumberOfWheels == int.Parse(nrOfWheels)
                                         select s;
            foreach (Vehicle s in query)
                feedback.Add(s.ToString());

            if (feedback.Count == 0)
                feedback.Add("Det finns inget fordon med: " + nrOfWheels + " st hjul i garaget");
            return feedback;
        }

        //Antal fordon som finns i garaget
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in vehicle)
            {
                yield return t;
            }            
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /*Antal fordon som finns i garaget
        public List<string> VehicleInGarage()
        {
            List<string> answer = new List<string>();

            IEnumerable<Vehicle> query = from s in vehicle
                                         orderby s.NumberOfWheels
                                         select s;

            foreach (Vehicle s in query)
                answer.Add(s.ToString());
            return answer;
        }*/
    }
}

