using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P3
{
    internal class Stats
    {
        string name;
        float damage;
        string descryption;
        double penetration;
        double cost;
        double heal;

        public Stats(string name, float damage, double penetration, double cost, double heal, string descryption)
        {
            this.name = name;
            this.damage = damage;
            this.penetration = penetration;
            this.cost = cost;
            this.heal = heal;
            this.descryption = descryption;
        }
        public string getName()
        {
            return name;
        }
        public float getDamage()
        {
            return damage;
        }
        public double getPenetration()
        {
            return penetration;
        }
        public double getCost()
        {
            return cost;
        }
        public double getHeal()
        {
            return heal;
        }
        public string getDescryption()
        {
            return descryption;
        }


    }
}
