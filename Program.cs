using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TaxiLibrary;

namespace TaxiPark
{
    class Program
    {
        static void Main(string[] args)
        {
            Interface.Start();
        }

        public static class Interface
        {
            static Administrator cab;
            static Interface() { cab = new Administrator("TaxiDrive"); }

            public static void Start()
            {
                bool flag = true;
                int choice;
                bool Exist = false;
                string ConsoleLine = string.Empty;
                double money;
                decimal distance;
                string day = "";
                string car = "";
                string comfortclass = "";
                string paymentselection = "";
                List<string> seecars = new List<string>() { "Volkswagen", "Ford", "Honda", "Toyota", "Ferrari" };
                List<string> seecomfort = new List<string>() { "Standart Class", "Premium Class", "Business Class", "Minibuses" };
                List<string> seepayment = new List<string>() { "Cash", "Card", "Google Pay", "Apple Pay" };
                Console.ForegroundColor = ConsoleColor.White;
                menu();
                Console.WriteLine("Hello! Thanks for choosing our taxi!");
                while (flag)
                {
                    try
                    {
                        //введення числа, щоб розуміти що робити далі
                        if (!Int32.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new ArgumentException("Wrong info. try again.");
                            Console.ResetColor();
                        }
                        if (choice == 0)
                        {
                            Client client = new Client();
                            Console.WriteLine("Input your Nickname:");
                            ConsoleLine = Console.ReadLine();
                            client.Name = ConsoleLine;

                            Console.WriteLine("Press Y/y if you're a registered client,otherwise press N/n");
                            while (true)
                            {
                                ConsoleLine = Console.ReadLine();
                                if (ConsoleLine.ToUpper() == "N") { Exist = false; break; }
                                else if (ConsoleLine.ToUpper() == "Y") { Exist = true; break; }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("It seems that you enter something wrong");
                                Console.ResetColor();
                            }
                            client.Registered = Exist;
                            Console.WriteLine("Then please, put your money on your card");
                            Console.WriteLine("Enter the amount of money:");
                            while (true)
                            {
                                ConsoleLine = Console.ReadLine();
                                if ((double.TryParse(ConsoleLine, out money)) && money > 50)
                                {
                                    money = Convert.ToDouble(ConsoleLine);
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You enter an inappropriate data or you put money less than 50 UAH.Try again");
                                Console.ResetColor();
                            }
                            client.Money = money;

                            Console.WriteLine("\nWrite the distance:");
                            while (true)
                            {
                                ConsoleLine = Console.ReadLine();
                                if ((decimal.TryParse(ConsoleLine, out distance)) && distance > 500)
                                {
                                    distance = Convert.ToDecimal(ConsoleLine);
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You enter inappropriate data or you put less than 500 m.Try again");
                                Console.ResetColor();
                            }
                            Console.WriteLine("Choose the day of the week:");
                            while (true)
                            {
                                ConsoleLine = Console.ReadLine();
                                ConsoleLine = ConsoleLine.Substring(0, ConsoleLine.Length).Replace(ConsoleLine.ElementAt(0), Char.ToUpper(ConsoleLine.ElementAt(0)));
                                if (ConsoleLine == "Monday" || ConsoleLine == "Tuesday" || ConsoleLine == "Wednesday" || ConsoleLine == "Thursday" || ConsoleLine == "Friday" || ConsoleLine == "Saturday" || ConsoleLine == "Sunday")
                                {
                                    day = ConsoleLine;
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Enter the day of the week.Try again. Example: Tuesday, wednesday, etc...");
                                Console.ResetColor();
                            }
                            Console.WriteLine("Then you have to choose a car.Press any number from 1-5:");

                            for (int i = 0; i < seecars.Count; i++)
                            {
                                Console.WriteLine((i + 1) + " - " + seecars[i]);
                            }

                            while (true)
                            {
                                int i = 0;
                                try
                                {
                                    i = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Not a number");
                                    Console.ResetColor();
                                }
                                if (i >= 1 && i <= 5)
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            car = "Volkswagen";
                                            break;
                                        case 2:
                                            car = "Ford";
                                            break;
                                        case 3:
                                            car = "Honda";
                                            break;
                                        case 4:
                                            car = "Toyota";
                                            break;
                                        case 5:
                                            car = "Ferrari";
                                            break;

                                    }
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You enter inappropriate data.Try again");
                                Console.ResetColor();
                            }

                            Console.WriteLine("Then you have to choose a comfort class .Press any number from 1-4:");
                            for (int i = 0; i < seecomfort.Count; i++)
                            {
                                Console.WriteLine((i + 1) + " - " + seecomfort[i]);
                            }
                            while (true)
                            {
                                int i = 0;
                                try
                                {
                                    i = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Not a number");
                                    Console.ResetColor();
                                }
                                if (i >= 1 && i <= 4)
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            comfortclass = "Standart Class";
                                            break;
                                        case 2:
                                            comfortclass = "Premium Class";
                                            break;
                                        case 3:
                                            comfortclass = "Business Class";
                                            break;
                                        case 4:
                                            comfortclass = "Minibuses";
                                            break;
                                    }
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You enter inappropriate data.Try again");
                                Console.ResetColor();
                            }

                            Console.WriteLine("How do you want to pay for the trip? Press any number from 1-4:");
                            for (int i = 0; i < seepayment.Count; i++)
                            {
                                Console.WriteLine((i + 1) + " - " + seepayment[i]);
                            }
                            while (true)
                            {
                                int i = 0;
                                try
                                {
                                    i = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Not a number");
                                    Console.ResetColor();
                                }
                                if (i >= 1 && i <= 4)
                                {
                                    switch (i)
                                    {
                                        case 1:
                                            paymentselection = "Cash";
                                            break;
                                        case 2:
                                            paymentselection = "Card";
                                            break;
                                        case 3:
                                            paymentselection = "Google Pay";
                                            break;
                                        case 4:
                                            paymentselection = "Apple Pay";
                                            break;
                                    }
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You enter inappropriate data.Try again");
                                Console.ResetColor();
                            }
                            Thread.Sleep(900);
                            client.ChooseTrip(distance, day, car, comfortclass, paymentselection);
                            cab.ClientService(client);
                            cab.GetClientsId();
                            menu();
                        }
                        else if (choice == 1)
                        {
                            Console.Clear();
                            menu();
                        }
                        else if (choice == 2)
                        {
                            menu();
                        }
                        else if (choice == 3)
                        {
                            cab.GetInfoTaxists();
                            Console.WriteLine();
                        }
                        else if (choice == 4)
                        {
                            cab.GetClientsId();
                        }
                        else if (choice == 5)
                        {
                            flag = false;
                        }
                        else if (choice == 6)
                        {
                            Console.WriteLine("The list of Cars:");
                            for (int i = 0; i < seecars.Count; i++)
                            {
                                Console.WriteLine((i + 1) + " - " + seecars[i]);
                            }
                        }
                        else if (choice == 7)
                        {
                            Console.WriteLine("The list of Comfort Classes:");
                            for (int i = 0; i < seecomfort.Count; i++)
                            {
                                Console.WriteLine((i + 1) + " - " + seecomfort[i]);
                            }
                        }
                        else if (choice == 8)
                        {
                            Console.WriteLine("The list of the Payment Selection:");
                            for (int i = 0; i < seepayment.Count; i++)
                            {
                                Console.WriteLine((i + 1) + " - " + seepayment[i]);
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong info. Try again");
                            Console.ResetColor();
                        }

                    }
                    catch (ArgumentException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong info. Try again.");
                        Console.ResetColor();
                    }
                }
            }
            static public void menu()
            {
                Console.WriteLine("Choose the option:");
                Console.WriteLine("0 - Order the trip!");
                Console.WriteLine("1 - Clear the console");
                Console.WriteLine("2 - Show the menu");
                Console.WriteLine("3 - Show the Salary and Working time of the taxidrivers");
                Console.WriteLine("4 - Show the list of clients");
                Console.WriteLine("5 - Stop the program");
                Console.WriteLine("6 - Show the list of Cars");
                Console.WriteLine("7 - Show the list of the Comfort Classes");
                Console.WriteLine("8 - Show the list of Payment selection");
            }
        }
    }
}
