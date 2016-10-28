using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    class Program
    {      
        static void Main(string[] args)
        {
            int choice = 1;
            Garage<Vehicle> garage = new Garage<Vehicle>();
            Console.ForegroundColor = ConsoleColor.Green;            
            
            while (choice != 0)
            {
                Console.WriteLine(" GARAGET");
                Console.WriteLine("---------");
                Console.WriteLine("1) Parkera fordon");
                Console.WriteLine("2) Hämta ut fordon");
                Console.WriteLine("3) Fordon i garaget");
                Console.WriteLine("4) Typ av fordon i garaget");
                Console.WriteLine("5) Sök efter fordon i garaget");
                Console.WriteLine("0) Avsluta");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if(choice < 6 & choice >= 0)
                    {
                        TheChoice(choice, garage);
                    }
                    else
                    {
                        Console.WriteLine("Det måste vara ett nummer mellan 0 - 5");
                        Console.WriteLine();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Du måste välja ett nummer");
                    Console.WriteLine();
                }                
            }
            Console.ReadKey();
        }


        static public void TheChoice(int choice,Garage<Vehicle> garage)
        {
            List<Vehicle> vehicles = new List<Vehicle>();           
            List<string> answer = new List<string>();                        
            
            switch (choice)
            {
                case 1 ://Parkera fordon¨- Lägga till fordon
                    bool garageFull = garage.checkIsGarageFull();

                    if (garageFull == true)
                        Console.WriteLine("Tyvärr garaget är fullt - återkom senare");
                    else
                    {
                        garage.addVehicle(parking());
                        Console.WriteLine("Nu är fordonet parkerat");
                    }                    
                    break;
                case 2 ://Köra ut fordon - Ta bort fordon
                    foreach (Vehicle s in garage)
                        Console.WriteLine(s);
                    Console.WriteLine(); 
                    Console.WriteLine("Ange registreringsnumret på fordonet som ska köra ut");
                    Console.WriteLine(garage.removeVehicle(Console.ReadLine()));                    
                    break;
                case 3://Fordon i garaget
                    Console.WriteLine("Det finns " + garage.numberOfVehicle() + " st fordon i garaget");
                    Console.WriteLine();
                    foreach (Vehicle s in garage)                    
                        Console.WriteLine(s);                                                        
                    break;
                case 4://Se vilken typ av fordon i garaget
                    string TheChoice = "7";
                    while (int.Parse(TheChoice) < 0 || int.Parse(TheChoice) > 5)
                    {
                        Console.WriteLine("Vilken typ av fordon vill du se i garaget?");
                        Console.WriteLine("1) Bil 2) Båt 3) Buss 4) Flygplan 5) Motorcykel");
                        TheChoice = Console.ReadLine();
                        if(int.Parse(TheChoice) > 5)
                            Console.WriteLine("Ange ett nummer mellan 1-5");
                    }
                    List<string> typ = new List<string>();
                    typ = garage.numberOfSpecialVehicle(int.Parse(TheChoice));

                    Console.WriteLine("Det finns " + typ.Count + " st forden av denna typ i garaget:");
                    foreach (string s in typ)
                        Console.WriteLine(s);
                    break;
                case 5://Sök efter fordon i garaget
                    TheChoice = "7";
                    while (int.Parse(TheChoice) < 0 || int.Parse(TheChoice) > 3)
                    {
                        Console.WriteLine("Vad vill du söka efter i garaget?");
                        Console.WriteLine("1) Regnr 2) Färg 3) Antal hjul");
                        TheChoice = Console.ReadLine(); if (int.Parse(TheChoice) > 5)
                            Console.WriteLine("Ange ett nummer mellan 1-3");
                    }
                    if(TheChoice == "1")
                    {
                        Console.WriteLine("Ange registreringnummer");
                        Console.WriteLine(garage.searchForRegnr(Console.ReadLine()));                        
                    }
                    else if (TheChoice == "2")
                    {
                        Console.WriteLine("Ange färg på fordonet");
                        typ = garage.searchForColour(Console.ReadLine());
                        foreach (string s in typ)
                            Console.WriteLine(s);                       
                    }
                    else if (TheChoice == "3")
                    {
                        Console.WriteLine("Ange antal hjul");
                        typ = garage.searchNrOfWheels(Console.ReadLine());
                        foreach (string s in typ)
                            Console.WriteLine(s);
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine();
        }

        static void writeAnswer(List<string> answer)
        {
            foreach (var item in answer)
                Console.WriteLine(item);
            Console.WriteLine();
	    }

        static List<Vehicle> parking()
        {
            string TheChoice = "7";
            List<Vehicle> vehicle = new List<Vehicle>();

            while (int.Parse(TheChoice) < 0 || int.Parse(TheChoice) > 5)
            {
                Console.WriteLine("Vilken typ av fordon vill du parkera?");
                Console.WriteLine("1) Bil 2) Båt 3) Buss 4) Flygplan 5) Motorcykel");
                TheChoice = Console.ReadLine();
            }
            string reg = "0";
            
            while(reg.Length != 6)
            {
                Console.WriteLine("Ange registreringsnumret");
                reg = Console.ReadLine();
                if (reg.Length != 6)
                    Console.WriteLine("Ej giltigt registreringsnummer");
            }

            Console.WriteLine("Ange färg på fordonet");
            string colour = Console.ReadLine();

            string wheels = "600";
            while (int.Parse(wheels) < 0 || int.Parse(wheels) > 500)
            {
                Console.WriteLine("Ange antal hjul");
                wheels = Console.ReadLine();
            }

            switch (TheChoice)
            {
                case "1": Console.WriteLine("Ange bilmärket");
                        string label = Console.ReadLine();
                        string speed = "600";
                        while (int.Parse(speed) < 0 || int.Parse(speed) > 500)
                        {
                            Console.WriteLine("Ange högsta hastigheten");
                            speed = Console.ReadLine();
                        }
                        vehicle.Add(new Car(label, int.Parse(speed), reg, colour, int.Parse(wheels)));
                        break;
                case "2": Console.WriteLine("Ange vilken typ av båt det är");
                        string model = Console.ReadLine();
                        string passenger = "10000";
                        while (int.Parse(passenger) < 0 || int.Parse(passenger) > 500)
                        {
                            Console.WriteLine("Ange antal passangerare");
                            passenger = Console.ReadLine();
                        }
                        vehicle.Add(new Boat(model, int.Parse(passenger), reg, colour, int.Parse(wheels)));
                        break;
                case "3": string lenght = "100";
                        while (int.Parse(lenght) < 0 || int.Parse(lenght) > 50)
                        {
                            Console.WriteLine("Ange längden på bussen");
                            lenght = Console.ReadLine();
                        }
                        string height = "100";
                        while (int.Parse(height) < 0 || int.Parse(height) > 50)
                        {
                            Console.WriteLine("Ange höjden på bussen");
                            height = Console.ReadLine();
                        }
                        vehicle.Add(new Buss(int.Parse(lenght), int.Parse(height), reg, colour, int.Parse(wheels)));
                        break;
                case "4": string wings = "100";
                        while (int.Parse(wings) < 0 || int.Parse(wings) > 50)
                        {
                            Console.WriteLine("Antal vingar");
                            wings = Console.ReadLine();
                        }
                        string propeller = "100";
                        while (int.Parse(propeller) < 0 || int.Parse(propeller) > 50)
                        {
                            Console.WriteLine("Ange antalet propellrar");
                            propeller = Console.ReadLine();
                        }
                        vehicle.Add(new Airplane(int.Parse(wings), int.Parse(propeller), reg, colour, int.Parse(wheels)));
                        break;
                case "5": string effect = "10000";
                        while (int.Parse(effect) < 0 || int.Parse(effect) > 1000)
                        {
                            Console.WriteLine("Ange motorcykelns effekt");
                            effect = Console.ReadLine();
                        }
                        Console.WriteLine("Ange vilken typ av motorcykel");
                        string mcTyp = Console.ReadLine();
                        vehicle.Add(new Motorcycle(int.Parse(effect), mcTyp, reg, colour, int.Parse(wheels)));
                        break;
                default:
                        break;
            }
            return vehicle;
        }
		 
    }

}

 
