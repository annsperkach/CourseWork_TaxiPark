using System;

namespace TaxiLibrary
{
    public abstract class ClientBase
    {
        public bool Registered { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public int IdCode { get; set; }
        public ClientBase()
        {
        }

        public ClientBase(string name, bool registered, double money)
        {
            Name = name;
            Money = money;
            Registered = registered;
        }
        protected abstract void RegisteredDiscount();
        public abstract void ChooseTrip(decimal distance, string data, string transport, string comfortClass, string paymentSelection);
        public abstract void Pay();
    }
}
