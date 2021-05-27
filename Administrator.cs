using System;
using System.Collections.Generic;

namespace TaxiLibrary
{
    public class Administrator
    {
        List<TaxiDriver> taxists = new List<TaxiDriver>();
        List<Client> clients = new List<Client>();
        public string Name { get; set; }
        public Administrator(string name)
        {
            Name = name;
            taxists = new List<TaxiDriver>
            {
                new TaxiDriver("Vasya Pupkin","10:00 AM","8:00 PM",7.1m),
                new TaxiDriver("Pavel Durov","6:00 AM","3:00 PM",11.3m),
                new TaxiDriver("Alex Kucher","12:00 AM","2:00 PM",14.2m),
                new TaxiDriver("Alex Popovich","6:00 AM","7:00 PM",16.65m),
                new TaxiDriver("Christian Adams","7:30 AM","1:00 PM",6m)
            };
        }
        public void ClientService(Client client)
        {
            client.Pay();
            client.IdCode = GetIDCode(client.Name);
            clients.Add(client);
        }
        private static int GetIDCode(string value)
        {
            int result = 0;
            for (int i = 0; i < value.Length; i++)
                result += value[i] * 31 ^ value.Length - (i + 1);
            return result;
        }

        public void GetClientsId()
        {
            foreach (var clnts in clients)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(clnts);
                Console.ResetColor();
            }
        }
        public void GetInfoTaxists()
        {
            foreach (var tax in taxists)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(tax);
                Console.ResetColor();
            }
        }
    }
}
