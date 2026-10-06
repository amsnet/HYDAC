using Microsoft.VisualStudio.TestTools.UnitTesting;
using HYDAC;

namespace HYDACTests
{
    [TestClass]
    public class GuestRegistryTests
    {
        [TestMethod]
        public void AddGuest_AddsGuestToRegistry()
        {
            // Arrange
            GuestRegistry registry = new GuestRegistry();

            Guest guest = new Guest(
                "Ben",
                "Benson Co.",
                new DateOnly(2026, 10, 2),
                new TimeOnly(10, 30),
                new EmployeeRep("Daniel")
            );

            // Act
            registry.AddGuest(guest);

            // Assert
            Guest[] guests = registry.GetGuests();

            Assert.AreEqual(1, guests.Length);
            Assert.AreSame(guest, guests[0]);
        }
    }
}