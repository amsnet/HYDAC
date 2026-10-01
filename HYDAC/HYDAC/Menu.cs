using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HYDAC
{
    public class Menu
    {
        private bool runProgram = true;
        private GuestList guestList;
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
            guestList = new GuestList();
            dataHandler = new DataHandler("GuestList.txt");
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


                if (guests.Length == 0)
                {
                    Console.WriteLine("Ingen gæster på nuværrende tidspunkt.");
                }
                else
                {
                    Console.WriteLine("Gæster");
                    Console.WriteLine();
                    foreach (Guest guest in guests)
                    {
                        Console.WriteLine($"{guest.Id} | {guest.Name} | {guest.CompanyName} | {guest.Date} | {guest.ArrivalTime} | {guest.AssignedEmployee.Name}");
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

                Console.Clear();
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
                        return false;
                    case ConsoleKey.O:
                        runProgram = false;
                        return false;
                    case ConsoleKey.S:
                        dataHandler.SaveGuestList(guestList.List);
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
            Console.Write("Dato for besøg: ");
            DateOnly date = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Ankomsttid: ");
            TimeOnly time = TimeOnly.Parse(Console.ReadLine());
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
            int count = employeeList.Count();

            for(int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}: {employeeList[i].Name}");
            }

            int input = -1;

            while (input > count || input < 0)
            {
                input = int.Parse(Console.ReadLine()) - 1;
            }

            return employeeList[input];
        }


        
    }
}
