using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface ISoldierFactory
    {
        IGun CreateGun();
        IArmor CreateArmor();
    }
    class Shooter : ISoldierFactory
    {
        public IGun CreateGun()
        {
            return new AK47();
        }
        public IArmor CreateArmor()
        {
            return new BodyArmorAndHelmet();
        }
    }
    class Medic : ISoldierFactory
    {
        public IGun CreateGun()
        {
            return new Shotgun();
        }
        public IArmor CreateArmor()
        {
            return new BodyArmor();
        }
    }
}
