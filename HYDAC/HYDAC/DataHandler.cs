using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
