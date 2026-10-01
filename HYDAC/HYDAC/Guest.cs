using System;

namespace HYDAC
{
    public class Guest
    {
        private int id;
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        private string name;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        private string companyName;
        public string CompanyName
        {
            set { companyName = value; }
            get { return companyName; }
        }

        private DateTime date;
        public DateTime Date
        {
            set { date = value; }
            get { return date; }
        }

        private DateTime arrivalTime;
        public DateTime ArrivalTime
        {
            set { arrivalTime = value; }
            get { return arrivalTime; }
        }

        private EmployeeRep assignedEmployee;
        public EmployeeRep AssignedEmployee
        {
            set { assignedEmployee = value; }
            get { return assignedEmployee; }
        }

        public Guest(string name, string companyName, DateTime date, DateTime arrivalTime, EmployeeRep employee)
        {
            Name = name;
            CompanyName = companyName;
            Date = date;
            ArrivalTime = arrivalTime;
            AssignedEmployee = employee;

            
        }

        public void AssignEmployee(EmployeeRep employee)
        {
            assignedEmployee = employee;
        }
    }
}