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

        protected virtual void RegisteredDiscount()
        {
            Console.WriteLine($"The order came from {Name} ");
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
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nDistance:{distance}\nYour price is:{trip.Sum}\nYour Comfort Class is:{comfortClass}\nYour car is:{transport}\nPayment Selection is:{paymentSelection}\nDay:{data}");
                Console.ResetColor();
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
            Console.WriteLine($"{Name},you paid {trip.Sum}.Now you have {Money} on your bill");
            Console.ResetColor();
        }
    }
}
