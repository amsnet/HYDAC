using System;

namespace HYDAC
{
    public class Guest
    {

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

        private DateOnly date;
        public DateOnly Date
        {
            set { date = value; }
            get { return date; }
        }

        private TimeOnly arrivalTime;
        public TimeOnly ArrivalTime
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

        public Guest(string name, string companyName, DateOnly date, TimeOnly arrivalTime, EmployeeRep employee)
        {
            Name = name;
            CompanyName = companyName;
            Date = date;
            ArrivalTime = arrivalTime;
            AssignedEmployee = employee;   
        }


        public string MakeTitle()
        {
            return $"{name};{companyName};{date};{arrivalTime};{assignedEmployee.Name}";
        }
    }
}