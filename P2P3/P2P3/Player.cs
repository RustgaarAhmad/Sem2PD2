using P2P3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P3
{
    internal class Player
    {
        double hp;
        double Maxhp;
        double energy;
        double MaxEnergy;
        double armour;
        string name;
        List<Stats> LearnedSkills = new List<Stats>();

        public Player(string name, double health, double energy, double armor)
        {
            this.name = name;
            this.hp = health;
            this.Maxhp = health;
            this.energy = energy;
            this.MaxEnergy = energy;
            this.armour = armor;
            this.LearnedSkills = new List<Stats>();
        }


        public void UpdateHealth(double amount)
        {
            this.hp += amount;
            if (this.hp > this.Maxhp)
                this.hp = this.Maxhp;
            else if (this.hp < 0)
                this.hp = 0;
        }

        public void UpdateEnergy(double amount)
        {
            this.energy += amount;

            if (this.energy > this.MaxEnergy)
                this.energy = this.MaxEnergy;
            else if (this.energy < 0)
                this.energy = 0;
        }

        public void UpdateArmor(double amount)
        {
            this.armour += amount;

            if (this.armour < 0)
                this.armour = 0;

        }

        public void UpdateName(string NewName)
        {
            this.name = NewName;
        }
        public void learnSkills(Stats skill)
        {
            LearnedSkills.Add(skill);
        }
        public string attack(Player target, string skillName)
        {
            Stats CurrentSkill = null;

            foreach (var skill in LearnedSkills)
            {
                if (skill.getName() == skillName)
                {
                    CurrentSkill = skill;
                    break;
                }
            }

            if (CurrentSkill == null)
            {
                return $"{this.name} has not learned {skillName}!";
            }

            if (this.energy < CurrentSkill.getCost())
            {
                return $"{this.name} attempted to use {skillName}, but didn't have enough energy!";
            }

            this.UpdateEnergy(-CurrentSkill.getCost());

            double effectiveArmour = Math.Max(0, target.armour - CurrentSkill.getPenetration());
            double damage = CurrentSkill.getDamage() * (100 - effectiveArmour) / 100.00;
            target.UpdateHealth(-damage);

            string statement = $"{this.name} used {CurrentSkill.getName()}, {CurrentSkill.getDescryption()}, against {target.name}, doing {damage:F2} damage!";

            if (CurrentSkill.getHeal() > 0)
            {
                double healAmount = CurrentSkill.getHeal();
                this.UpdateHealth(healAmount);
                statement += $" {this.name} healed for {healAmount} health!";
            }

            if (target.hp <= 0)
            {
                statement += $" {target.name} died.";
            }
            else
            {
                double targetHealthPercentage = (target.Maxhp > 0) ? (target.hp / target.Maxhp) * 100 : 0; // ✅ Prevent division by zero
                statement += $" {target.name} is at {targetHealthPercentage:F2}% health.";
            }

            return statement;
        }

    }
}
