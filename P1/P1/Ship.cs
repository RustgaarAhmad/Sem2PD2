using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    internal class Ships
    {
        public string ShipName;
        public string ShipLocation;
        public Ships(string name, string location)
        {
            this.ShipName = name;
            this.ShipLocation = location;
        }

        public string GetShipPosition()
        {
            return ShipLocation;
        }
        public string GetShipName()
        {
            return ShipName;
        }
    }
}