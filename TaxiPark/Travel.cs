using System;
using System.Collections.Generic;

namespace TaxiLibrary
{
    public class Travel
    {
        public delegate void InfoDayHandler();
        public event InfoDayHandler Notify;
        readonly public List<Travel> trips = new List<Travel>();
        public double Sum { get; set; } = 50;
        public string Data { get; set; }
        public decimal Distance { get; set; }
        public string ComfortClass { get; set; }
        public string PaymentSelection { get; set; }
        public string Transport { get; set; }
        public Travel()
        {
        }

        public Travel(string data, string transport, string comfortClass, string paymentSelection, decimal distance)
        {
            Transport = transport;
            Data = data;
            Distance = distance;
            PaymentSelection = paymentSelection;
            ComfortClass = comfortClass;
        }

        public void BonusWeekDiscount()
        {
            if (Data == "Wednesday")
            {
                Notify += delegate
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Today is Wednesday.You get a 30% discount");
                    Console.ResetColor();
                };
                Notify?.Invoke();
                Sum -= Sum * 0.3;
            }
            if (Distance > 1000)
                Sum += 50d;

            if (Data == "Sunday" || Data == "Saturday" || Data == "Friday")
            {
                Sum += Sum * 0.3;
                Notify += delegate
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Sorry, in this week's day the price has increased by 30%");
                    Console.ResetColor();
                };
                Notify?.Invoke();
            }
        }
    }
}
