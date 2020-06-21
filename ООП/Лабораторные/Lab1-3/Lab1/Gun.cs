using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IGun
    {
        int Shot();
    }
    class AK47 : IGun
    {
        public int Damage { get; private set; } = 90;
        public int Shot()
        {
            return Damage;
        }
    }
    class Shotgun : IGun
    {
        public int Damage { get; private set; } = 150;
        public int Shot()
        {
            return Damage;
        }
    }
}
