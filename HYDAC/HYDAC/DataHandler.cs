using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
namespace HYDAC
{
    public class DataHandler
    {
        private string dataFileName;
        public string DataFileName
        {
            get { return dataFileName; }
        }

        public DataHandler(string dataFileName)
        {
            this.dataFileName = dataFileName;
        }

        public void SaveGuestList(Guest[] guestList)
        {
            using (StreamWriter sw = new StreamWriter(dataFileName))
            {
                foreach (Guest person in guestList)
                {
                    sw.Write(person.MakeTitle() + "*");
                }
            }
        }

        
        public Guest[] LoadGuest()
        {
            string input;
            string[] rawGeustArray;
            using (StreamReader sr = new StreamReader(dataFileName))
            {
                input = sr.ReadLine();
                rawGeustArray = input.Split("*");
            }
            int guestCount = rawGeustArray.Count();
            Guest[] guests = new Guest[guestCount];

            for (int i = 0; i < guestCount; i++)
            {
                string[] splitGuests = rawGeustArray[i].Split(";");
                if (splitGuests.Length==5)
                {
                    string name = splitGuests[0];
                    string coName = splitGuests[1];
                    DateOnly date = DateOnly.Parse(splitGuests[2]);
                    TimeOnly time = TimeOnly.Parse(splitGuests[3]);
                    EmployeeRep employee = new EmployeeRep(splitGuests[4]);
                    guests[i] = new Guest(name, coName, date, time, employee);
                }
            }
            return guests; 



        }

    }
}
