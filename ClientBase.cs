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

        public abstract void ChooseTrip(decimal distance, string data, string transport, string comfortClass, string paymentSelection);
        public override string ToString() { return string.Format("Name: {0}, Id: {1}", Name, IdCode); }
        public abstract void Pay();
    }
}
