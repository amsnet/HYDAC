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

        public Menu()
        {
            guestList = new GuestList();
        }

        public void ShowMenu()
        {
            List<Guest> guests = guestList.GetGuests();

            while (runProgram)
            {
                Console.WriteLine("Gæsteliste");
                Console.WriteLine("---");
                Console.WriteLine();


                if (guests.Count == 0)
                {
                    Console.WriteLine("Ingen gæster på nuværrende tidspunkt.");
                }
                else
                {
                    Console.WriteLine("Gæster");
                    foreach (Guest guest in guests)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"{guest.Id} | {guest.Name} | {guest.CompanyName} | {guest.Date} | {guest.ArrivalTime} | {guest.AssignedEmployee.Name}");
                    }
                }

                Console.WriteLine();

                Console.WriteLine("---");

                Console.WriteLine();

                Console.WriteLine("ALT + N: Ny gæst | ALT + O: Luk program");

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
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Ankomsttid: ");
            DateTime time = DateTime.Parse(Console.ReadLine());
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
