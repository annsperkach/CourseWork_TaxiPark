using System;

namespace TaxiLibrary
{
    public abstract class TaxiDriverBase
    {
        public decimal Salary { get; set; }
        public decimal HourlyPay { get; set; }
        public string Name { get; set; } = "";
        public string StartWorkTime { get; set; }
        public string EndWorkTime { get; set; }

        protected abstract decimal SalaryCalculation();
        public TaxiDriverBase()
        {
        }
        public TaxiDriverBase(string name, string startWorkTime, string endWorkTime, decimal hourlyPay)
        {
            HourlyPay = hourlyPay;
            Name = name;
            StartWorkTime = startWorkTime;
            EndWorkTime = endWorkTime;
        }

        public override string ToString()
        {
            return string.Format("Name of the Taxidriver: {0},Working hours:{1} - {2}, Salary: {3}", Name, StartWorkTime, EndWorkTime, Salary);
        }
    }
}
