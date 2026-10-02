using Microsoft.VisualStudio.TestTools.UnitTesting;
using HYDAC;

namespace HYDACTests
{
    [TestClass]
    public class GuestRegistryTests
    {
        [TestMethod]
        public void AddGuest()
        {
            // #### ARRANGE ####
            GuestRegistry guestRegistry = new GuestRegistry();

            EmployeeRep employee = new EmployeeRep("Daniel");

            Guest guest = new Guest(
                "Alexander",
                "Netli",
                new DateOnly(2026, 10, 2),
                new TimeOnly(10, 30),
                employee
            );

            // #### ACT ####
            guestRegistry.AddGuest(guest);

            // #### ASSERT ####
            Guest[] guests = guestRegistry.GetGuests();

            Assert.AreEqual(1, guests.Length);
            Assert.AreEqual("Alexander", guests[0].Name);
            Assert.AreEqual("Netli", guests[0].CompanyName);
            Assert.AreEqual(new DateOnly(2026, 10, 2), guests[0].Date);
            Assert.AreEqual(new TimeOnly(10, 30), guests[0].ArrivalTime);
            Assert.AreEqual("Daniel", guests[0].AssignedEmployee.Name);
        }


        [TestMethod]
        public void AddManyGuests()
        {
            // #### ARRANGE ####
            GuestRegistry guestRegistry = new GuestRegistry();

            EmployeeRep employee1 = new EmployeeRep("Daniel");
            EmployeeRep employee2 = new EmployeeRep("Kasper");

            Guest guest1 = new Guest(
                "Alexander",
                "Netli",
                new DateOnly(2026, 10, 2),
                new TimeOnly(10, 30),
                employee1
            );

            Guest guest2 = new Guest(
                "Peter",
                "HYDAC",
                new DateOnly(2026, 10, 3),
                new TimeOnly(12, 0),
                employee2
            );

            // #### ACT ####
            guestRegistry.AddGuest(guest1);
            guestRegistry.AddGuest(guest2);

            // #### ASSERT ####
            Guest[] guests = guestRegistry.GetGuests();

            Assert.AreEqual(2, guests.Length);

            Assert.AreEqual("Alexander", guests[0].Name);
            Assert.AreEqual("Daniel", guests[0].AssignedEmployee.Name);

            Assert.AreEqual("Peter", guests[1].Name);
            Assert.AreEqual("Kasper", guests[1].AssignedEmployee.Name);
        }


        [TestMethod]
        public void AddGuestWithCorrectEmployee()
        {
            // #### ARRANGE ####
            GuestRegistry guestRegistry = new GuestRegistry();

            EmployeeRep employee = new EmployeeRep("Daniel");

            Guest guest = new Guest(
                "Alexander",
                "Netli",
                new DateOnly(2026, 10, 2),
                new TimeOnly(10, 30),
                employee
            );

            // #### ACT ####
            guestRegistry.AddGuest(guest);

            // #### ASSERT ####
            Guest[] guests = guestRegistry.GetGuests();

            Assert.AreEqual("Daniel", guests[0].AssignedEmployee.Name);
        }


        [TestMethod]
        public void AddNullGuest()
        {
            // #### ARRANGE ####
            GuestRegistry guestRegistry = new GuestRegistry();

            // #### ACT ####
            guestRegistry.AddGuest(null);

            // #### ASSERT ####
            Guest[] guests = guestRegistry.GetGuests();

            Assert.AreEqual(0, guests.Length);
        }


        [TestMethod]
        public void AddGuestInvalidEmployeeNumber()
        {
            // #### ARRANGE ####
            Menu menu = new Menu();

            string input =
                "Alexander\n" +
                "Netli\n" +
                "02-10-2026\n" +
                "10:30\n" +
                "6\n" +       // Invalid
                "2\n";        // Valid

            Console.SetIn(new StringReader(input));

            // #### ACT ####
            menu.AddNewGuest();

            // #### ASSERT ####
            Guest[] guests = menu.GetGuestRegistry().GetGuests();

            Assert.AreEqual(1, guests.Length);
            Assert.AreEqual("Daniel", guests[0].AssignedEmployee.Name);
        }


        [TestMethod]
        public void AddGuestNegativeEmployeeNumber()
        {
            // #### ARRANGE ####
            Menu menu = new Menu();

            string input =
                "Alexander\n" +
                "Netli\n" +
                "02-10-2026\n" +
                "10:30\n" +
                "-1\n" +      // Invalid
                "1\n";        // Valid

            Console.SetIn(new StringReader(input));

            // #### ACT ####
            menu.AddNewGuest();

            // #### ASSERT ####
            Guest[] guests = menu.GetGuestRegistry().GetGuests();

            Assert.AreEqual(1, guests.Length);
            Assert.AreEqual("Daniel R.", guests[0].AssignedEmployee.Name);
        }


        [TestMethod]
        public void AddGuestInvalidEmployeeText()
        {
            // #### ARRANGE ####
            Menu menu = new Menu();

            string input =
                "Alexander\n" +
                "Netli\n" +
                "02-10-2026\n" +
                "10:30\n" +
                "abc\n" +     // Invalid
                "3\n";        // Valid

            Console.SetIn(new StringReader(input));

            // #### ACT ####
            menu.AddNewGuest();

            // #### ASSERT ####
            Guest[] guests = menu.GetGuestRegistry().GetGuests();

            Assert.AreEqual(1, guests.Length);
            Assert.AreEqual("Rene Hansen", guests[0].AssignedEmployee.Name);
        }


        [TestMethod]
        public void AddGuestInvalidDate()
        {
            // #### ARRANGE ####
            Menu menu = new Menu();

            string input =
                "Alexander\n" +
                "Netli\n" +
                "30-02-2026\n" +   // Invalid
                "02-10-2026\n" +   // Valid
                "10:30\n" +
                "1\n";

            Console.SetIn(new StringReader(input));

            // #### ACT ####
            menu.AddNewGuest();

            // #### ASSERT ####
            Guest[] guests = menu.GetGuestRegistry().GetGuests();

            Assert.AreEqual(1, guests.Length);
            Assert.AreEqual(new DateOnly(2026, 10, 2), guests[0].Date);
        }


        [TestMethod]
        public void AddGuestInvalidTime()
        {
            // #### ARRANGE ####
            Menu menu = new Menu();

            string input =
                "Alexander\n" +
                "Netli\n" +
                "02-10-2026\n" +
                "25:70\n" +       // Invalid
                "10:30\n" +       // Valid
                "1\n";

            Console.SetIn(new StringReader(input));

            // #### ACT ####
            menu.AddNewGuest();

            // #### ASSERT ####
            Guest[] guests = menu.GetGuestRegistry().GetGuests();

            Assert.AreEqual(1, guests.Length);
            Assert.AreEqual(new TimeOnly(10, 30), guests[0].ArrivalTime);
        }
    }
}