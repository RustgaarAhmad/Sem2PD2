using P2P3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player alice = new Player("Alice", 110.00, 50.00, 10.00);
            Player bob = new Player("Bob", 100, 60, 20);

            Stats fireball = new Stats("Fireball", 23, 1.2, 5, 15, "A fiery magical attack");
            Stats superbeam = new Stats("Superbeam", 200, 50, 50, 75, "An overpowered attack, pls nerf");

            alice.learnSkills(fireball);
            bob.learnSkills(superbeam);

            Console.WriteLine(alice.attack(bob, "Fireball"));


            Console.WriteLine(bob.attack(alice, "Superbeam"));

            Console.ReadKey();
        }
    }
}
