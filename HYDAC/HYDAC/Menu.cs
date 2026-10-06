using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HYDAC
{
    public class Menu
    {
        private bool runProgram = true;
        private GuestRegistry guestList;
        private EmployeeRep[] employeeList =
        {
            new EmployeeRep("Daniel R."),
            new EmployeeRep("Daniel"),
            new EmployeeRep("Rene Hansen"),
            new EmployeeRep("Kasper"),
            new EmployeeRep("Jesper Salih")
        };

        DataHandler dataHandler;

        public Menu()
        {
            dataHandler = new DataHandler("GuestList.txt");
            guestList = new GuestRegistry();           
            guestList.List = dataHandler.InitGuests();
        }

        public void ShowMenu()
        {
            Guest[] guests = guestList.GetGuests();
            while (runProgram == true)
            {
                guests = guestList.GetGuests();

                Console.WriteLine("Gæsteliste");
                Console.WriteLine();
                Console.WriteLine("---");
                Console.WriteLine();

                if (guests == null || guests.Length == 0)
                {
                    Console.WriteLine("Ingen gæster på nuværrende tidspunkt.");
                }
                else
                {
                    Console.WriteLine("Gæst  |  Firma  |  Dato   |   Ankomstid  |  Ansvarlig");
                    foreach (Guest guest in guests)
                    {
                        Console.WriteLine($"{guest.Name} | {guest.CompanyName} | {guest.Date} | {guest.ArrivalTime} | {guest.AssignedEmployee.Name}");
                    }
                }

                Console.WriteLine();

                Console.WriteLine("---");

                Console.WriteLine();

                Console.WriteLine("ALT + N: Ny gæst | ALT + S: Gem gæsteliste | ALT + O: Luk program");

                for (bool requestSelection = true; requestSelection;)
                {
                    requestSelection = SelectOption(Console.ReadKey(true));
                }

                
            }
        }

        public bool SelectOption(ConsoleKeyInfo input)
        {
            if(input.Modifiers.HasFlag(ConsoleModifiers.Alt))
            {
                switch (input.Key)
                {
                    case ConsoleKey.N:
                        Console.Clear();
                        AddNewGuest();
                        Console.Clear();
                        return false;
                    case ConsoleKey.O:
                        runProgram = false;
                        Console.Clear();
                        return false;
                    case ConsoleKey.S:
                        dataHandler.SaveGuestList(guestList.GetGuests());
                        Console.Clear();
                        Console.Write("Gæsteliste er gemt! - ");
                        return false;
                  
                }
            }
            return true;
        }
        public void AddNewGuest()
        {
            Console.WriteLine();
            Console.WriteLine("Tilføj ny gæst");
            Console.WriteLine();
            Console.Write("Navn: ");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Firmanavn: ");
            string coName = Console.ReadLine();

            Console.WriteLine();
            DateOnly date = new DateOnly(2025, 1, 1);
            for (bool validInput = false; !validInput;)
            {
                Console.Write("Dato for besøg: ");
                if (DateOnly.TryParse(Console.ReadLine(), out date))
                {
                    validInput = true;
                } else
                {
                    Console.WriteLine("Ugyldig dato");
                }
            }

            Console.WriteLine();
            TimeOnly time = new TimeOnly(00,00,00);
            for (bool validInput = false; !validInput;)
            {
                Console.Write("Ankomsttid: ");
                if (TimeOnly.TryParse(Console.ReadLine(), out time))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Ugyldig tidspunkt");
                }
            }

            Console.WriteLine();
            Console.Write("Ansvarlig medarbejder: ");
            Console.WriteLine();
            EmployeeRep employee = AssignEmployeeToGuest();

            Console.WriteLine($"{name}, {coName}, {date}, {time}, {employee.Name}");

            Guest guest = new Guest(name, coName, date, time, employee);
            guestList.AddGuest(guest);
           
        }
        public EmployeeRep AssignEmployeeToGuest()
        {
            int count = employeeList.Length;

            for(int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}: {employeeList[i].Name}");
            }

            int input = 0;

            for(bool validIinput = false; !validIinput;)
            {
                if (int.TryParse(Console.ReadLine(), out input) && input <= count && input > 0)
                {
                    input -= 1;
                    validIinput = true;
                }
                else
                {
                    Console.WriteLine("Ugyldigt valg.");
                }
            }

            return employeeList[input];
        }


        
    }
}
