using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Decorator : IGun
    {
        protected readonly IGun gun;
        public Decorator(IGun gun)
        {
            this.gun = gun;
        }

        public virtual int Shot()
        {
            return gun.Shot();
        }
    }

    class NewGun : Decorator
    {
        public NewGun(IGun gun) : base(gun)
        { }

        public override int Shot()
        {
            Console.WriteLine("Shooting from gun");
            return base.Shot();
        }
    }
}
