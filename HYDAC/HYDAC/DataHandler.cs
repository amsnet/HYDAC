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

        public Guest[] InitGuests()
        {
            if (File.Exists(dataFileName) && File.ReadAllText(dataFileName) != "")
            {
                return LoadGuests();
            } else
            {
                return null;
            }
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

        
        public Guest[] LoadGuests()
        {
            string input;
            string[] rawGuestArray;
            using (StreamReader sr = new StreamReader(dataFileName))
            {
                input = sr.ReadLine();
                rawGuestArray = input.Split("*", StringSplitOptions.RemoveEmptyEntries);
            }

            int guestCount = rawGuestArray.Count();

            Guest[] guests = new Guest[guestCount];

            for (int i = 0; i < guestCount; i++)
            {
                string[] splitGuests = rawGuestArray[i].Split(";");
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
