using System;
using System.Collections.Generic;
using System.Text;

namespace HYDAC
{
    public class Menu
    {
        private GuestList guestList;

        public void ShowMenu()
        {
            List<Guest> guestList = new GuestList().GetGuests();

            Console.WriteLine("Gæsteliste");
            Console.WriteLine();

            if (guestList.Count() == 0)
            {
                Console.WriteLine("Ingen gæster på nuværrende tidspunkt.");
                Console.WriteLine();
            } else
            {
                foreach(Guest guest in guestList)
                {
                    if (guest.AssignedEmployee != null)
                    {
                        Console.WriteLine("Gæster");
                        Console.WriteLine($"{guest.Id} | {guest.Name} | {guest.CompanyName} | {guest.Date} | {guest.ArrivalTime} | {guest.AssignedEmployee}");
                    } else
                    {
                        Console.WriteLine("Mangler ansvalig medarbejder");
                        Console.WriteLine($"{guest.Id} | {guest.Name} | {guest.CompanyName} | {guest.Date} | {guest.ArrivalTime}");
                    }
                }
            }

            Console.WriteLine("---");

            Console.WriteLine("ALT + N: Ny gæst | ALT + O: Luk program");

            ConsoleKeyInfo input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.N:
                    if(input.Modifiers.HasFlag(ConsoleModifiers.Alt))
                    {
                        Console.WriteLine("Add new guest");
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

                        AddNewGuest(name, coName, date, time);
                    }
                    break;
            }

        }

        public void SelectOption(int option)
        {

        }
        public void AddNewGuest(string name, string companyName, DateTime date, DateTime arrivalTime)
        {
            Guest guest = new Guest(name, companyName, date, arrivalTime);
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
