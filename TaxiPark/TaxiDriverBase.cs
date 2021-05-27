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

        public TaxiDriverBase(string name, string startWorkTime, string endWorkTime, decimal hourlyPay)
        {
            HourlyPay = hourlyPay;
            Name = name;
            StartWorkTime = startWorkTime;
            EndWorkTime = endWorkTime;
        }
    }
}
