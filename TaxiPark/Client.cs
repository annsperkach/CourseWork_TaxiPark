using System;

namespace TaxiLibrary
{
    public delegate void EventHandler();
    public class Client : ClientBase
    {
        public event EventHandler MoneyChange;
        public Travel trip = new Travel();
        public event Action Notify;
        public Client()
        {
        }

        public Client(string name, bool registered, double money) : base(name, registered, money)
        {
            if (registered) trip.Sum -= trip.Sum * 0.20;
        }

        protected override void RegisteredDiscount()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (Registered) Console.WriteLine($" {Name} you are a registered client,so we've prepared you a special 20% discount :)");
            Notify?.Invoke();
            Console.ResetColor();
        }
        public override void ChooseTrip(decimal distance, string data, string transport, string comfortClass, string paymentSelection)
        {
            trip.Distance = distance;
            trip.Data = data;
            trip.Transport = transport;
            trip.ComfortClass = comfortClass;
            trip.PaymentSelection = paymentSelection;
            RegisteredDiscount();
            if (!trip.trips.Contains(trip))
            {
                trip.trips.Add(trip);
            }

            foreach (Travel trip in trip.trips)
            {
                trip.BonusWeekDiscount();
            }
        }

        public override void Pay()
        {
            if (Money <= trip.Sum)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Name},you don't have enough money");
                Console.ResetColor();
            }
            else
            {
                Money -= trip.Sum;
                MoneyChange += Client_MoneyChange;
                MoneyChange?.Invoke();
            }
        }
        private void Client_MoneyChange()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0}, you paid {1}, Now you have {2} on your bill", Name, trip.Sum, Money);
            Console.ResetColor();
        }
        public override string ToString() { return string.Format("Name: {0}, Id: {1}", Name, IdCode); }
    }
}
