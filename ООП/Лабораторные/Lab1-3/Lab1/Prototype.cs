using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface Prototype
    {
        object Clone();
        object DeepClone();
    }

    class Soldier : Prototype
    {
        public int Health { get; set; }
        public Ammunition Ammunition { get; set; }
        public Soldier(int health, string gun, int armorAmount)
        {
            Health = health;
            Ammunition = new Ammunition(gun, armorAmount);
        }
        public object Clone()
        {
            return (Soldier)MemberwiseClone();
        }
        public object DeepClone()
        {
            Soldier Soldier = (Soldier)MemberwiseClone();
            Soldier.Ammunition = new Ammunition(Ammunition.Gun, Ammunition.ArmorAmount);
            return Soldier;
        }
    }

    class Ammunition
    {
        public string Gun { get; set; }
        public int ArmorAmount { get; set; }
        public Ammunition(string gun, int armorAmount)
        {
            Gun = gun;
            ArmorAmount = armorAmount;
        }
    }
}
