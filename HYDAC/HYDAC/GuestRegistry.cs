using System;
using System.Collections;

namespace HYDAC
{
    public class GuestRegistry
    {
        private Guest[] list;
        public Guest[] List
        {
            set
            {
                list = value;
                listSize = list.Length;
            }
        }
        private int listSize;

        public GuestRegistry()
        {
            listSize = 0;
            list = new Guest[listSize];
        }

        public void AddGuest(Guest guest)
        {

            listSize++;

            Guest[] tempArray = new Guest[listSize];

            for (int i = 0; i < listSize - 1; i++)
            {
                tempArray[i] = list[i];
            }

            tempArray[listSize - 1] = guest;

            list = tempArray;
        }

        public Guest[] GetGuests()
        {
            return list;
        }

        public Guest GetGuest(int id)
        {
            foreach (Guest guest in list)
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