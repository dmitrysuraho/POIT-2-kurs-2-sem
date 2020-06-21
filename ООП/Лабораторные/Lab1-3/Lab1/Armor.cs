using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IArmor
    {
        int ArmorAmount();
    }
    class BodyArmor : IArmor
    {
        public int Armor { get; set; } = 70;
        public int ArmorAmount()
        {
            return Armor;
        }
    }
    class BodyArmorAndHelmet : IArmor
    {
        public int Armor { get; set; } = 100;
        public int ArmorAmount()
        {
            return Armor;
        }
    }
}
