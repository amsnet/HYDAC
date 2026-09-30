using System;
using System.Collections;

namespace HYDAC
{
    public class GuestList
    {
        private List<Guest> guestList;

        public GuestList()
        {
            guestList = new List<Guest>();
        }

        public void AddGuest(Guest guest)
        {
            guestList.Add(guest);
        }

        public List<Guest> GetGuests()
        {
            return guestList;
        }

        public Guest GetGuest(int id)
        {
            foreach (Guest guest in guestList)
            {
                if (guest.Id == id)
                {
                    return guest;
                }
            }
            return null;
        }
    }
}