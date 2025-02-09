
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Ships> ships = new List<Ships>();
            char x = ' ';

            while (x != '5')
            {
                Console.Clear();
                x = menu();
                if (x == '1')
                {
                    ships.Add(AddShip());
                }
                else if (x == '2')
                {
                    Console.WriteLine("Enter ship Serial Number :");
                    string ShipName = Console.ReadLine();
                    for (int i = 0; i < ships.Count; i++)
                    {
                        if (ShipName == ships[i].ShipName)
                        {
                            Console.WriteLine(ships[i].ShipLocation);
                        }
                    }

                    Console.WriteLine("Press any key to continue!");
                    Console.ReadKey();
                }
                else if (x == '3')
                {
                    string SerialNum = ViewSerialNum(ships);
                    if (SerialNum == "Not Found")
                    {
                        Console.WriteLine("Ship Not Found !!!");
                    }
                    else
                    {
                        Console.WriteLine($"The Ship Serial Number is : {SerialNum}");
                    }
                    Console.ReadKey();
                }
                else if (x == '4')
                {
                    changePosition(ships);
                }
            }


        }

        static char menu()
        {
            char menuVar = '1';
            do
            {
                if (menuVar != '1' && menuVar != '2' && menuVar != '3' && menuVar != '4' && menuVar != '5')
                {
                    Console.WriteLine("Select From the menu!");
                }
                Console.WriteLine("** SHIP MANAGEMENT SYSTEM **");
                Console.WriteLine("1. Add Ship");
                Console.WriteLine("2. View Ship Position");
                Console.WriteLine("3. View Ship Serial Number");
                Console.WriteLine("4. Change Ship Position");
                Console.WriteLine("5. Exit");
                menuVar = char.Parse(Console.ReadLine());
            } while (menuVar != '1' && menuVar != '2' && menuVar != '3' && menuVar != '4' && menuVar != '5');
            return menuVar;
        }
        public static Ships AddShip()
        {
            string ShipName, ShipLocation;
            string degree, minute, direction;

            Console.WriteLine("Enter Ship Serial Number :");
            ShipName = Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude:");
            Console.WriteLine("Enter Latitude Degree:");
            degree = Console.ReadLine();
            Console.WriteLine("Enter Latitude’s Minute:");
            minute = Console.ReadLine();
            Console.WriteLine("Enter Latitude’s Direction:");
            direction = Console.ReadLine();

            ShipLocation = degree + "^" + minute + "'" + direction + ' ';
            Console.WriteLine(" ");
            Console.WriteLine("Enter Ship Longitude:");
            Console.WriteLine("Enter Longitude Degree:");
            degree = Console.ReadLine();
            Console.WriteLine("Enter Longitude’s Minute:");
            minute = Console.ReadLine();
            Console.WriteLine("Enter Longitude’s Direction:");
            direction = Console.ReadLine();
            ShipLocation += " And" + degree + "^" + minute + "'" + direction;
            Ships ship = new Ships(ShipName, ShipLocation);
            return ship;
        }

        public static string ViewSerialNum(List<Ships> ships)
        {
            Console.Clear();
            string latitude, longitude;
            Console.WriteLine("Enter Ship Latitude : ");
            latitude = Console.ReadLine();
            Console.WriteLine("Enter Ship Longitude : ");
            longitude = Console.ReadLine();
            bool isFound = false;
            foreach (Ships obj in ships)
            {
                if (latitude + "  And" + longitude == obj.ShipLocation)
                {
                    isFound = true;
                    return obj.ShipName;
                }
            }
            if (!isFound)
            {
                return "Not Found";

            }
            return "";
        }

        public static void changePosition(List<Ships> ships)
        {
            string ShipName, ShipLocation;
            string degree, minute, direction;

            Console.WriteLine("Enter Ship Serial Number :");
            ShipName = Console.ReadLine();
            bool isFound = false;
            int i = 0;
            foreach (Ships obj in ships)
            {
                if (obj.ShipName == ShipName)
                {
                    isFound = true;
                    Console.WriteLine("Enter Ship Latitude:");
                    Console.WriteLine("Enter Latitude Degree:");
                    degree = Console.ReadLine();
                    Console.WriteLine("Enter Latitude’s Minute:");
                    minute = Console.ReadLine();
                    Console.WriteLine("Enter Latitude’s Direction:");
                    direction = Console.ReadLine();

                    ShipLocation = degree + "^" + minute + "'" + direction + ' ';
                    Console.WriteLine(" ");
                    Console.WriteLine("Enter Ship Longitude:");
                    Console.WriteLine("Enter Longitude Degree:");
                    degree = Console.ReadLine();
                    Console.WriteLine("Enter Longitude’s Minute:");
                    minute = Console.ReadLine();
                    Console.WriteLine("Enter Longitude’s Direction:");
                    direction = Console.ReadLine();
                    ShipLocation += " And" + degree + "^" + minute + "'" + direction;
                    ships[i].ShipLocation = ShipLocation;
                }
                i++;
            }
            if (!isFound)
            {
                Console.WriteLine("Ship Not Found !!!");
            }
            Console.ReadKey();
        }
    }
}
