using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiLibrary
{
    public class TaxiDriver : TaxiDriverBase
    {
        public TaxiDriver(string name, string startWorkTime, string endWorkTime, decimal hourlyPay) : base(name, startWorkTime, endWorkTime, hourlyPay)
        {
            SalaryCalculation();
        }
        protected override sealed decimal SalaryCalculation()
        {
            TimeSpan duration = DateTime.Parse(EndWorkTime).Subtract(DateTime.Parse(StartWorkTime));
            Salary += Convert.ToDecimal(duration.TotalHours) * HourlyPay;
            return Salary;
        }
    }
}
