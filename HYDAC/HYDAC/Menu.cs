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
                        if (guest.AssignedEmployee != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{guest.Id} | {guest.Name} | {guest.CompanyName} | {guest.Date} | {guest.ArrivalTime} | {guest.AssignedEmployee}");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("--- Mangler ansvalig medarbejder");
                            Console.WriteLine();
                            Console.WriteLine($"{guest.Id} | {guest.Name} | {guest.CompanyName} | {guest.Date} | {guest.ArrivalTime}");
                        }
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

            Console.WriteLine($"{name}, {coName}, {date}, {time}");

            Guest guest = new Guest(name, coName, date, time);
            guestList.AddGuest(guest);
        }
        public void AssignEmployeeToGuest(int guestId, string employeeName)
        {
            Guest guest = guestList.GetGuest(guestId);
            EmployeeRep employee = new EmployeeRep();
            employee.Name = employeeName;
            guest.AssignEmployee(employee);
        }
    }
}
