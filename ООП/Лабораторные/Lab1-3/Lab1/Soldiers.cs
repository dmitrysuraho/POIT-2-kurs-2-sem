using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Soldiers
    {
        private IGun gun;
        private IArmor armor;
        public Soldiers(ISoldierFactory factory)
        {
            gun = factory.CreateGun();
            armor = factory.CreateArmor();
        }
        public int Gun()
        {
            return gun.Shot();
        }
        public int Armor()
        {
            return armor.ArmorAmount();
        }

        /*--------------------------------------*/

        public void Run()
        {
            Console.WriteLine("Soldier started running");
        }
        public void FireGun()
        {
            Console.WriteLine("Soldier started shooting");
        }

        /*--------------------------------------*/

        public ISoldierState State { get; set; }

        public Soldiers(ISoldierState ws, ISoldierFactory factory)
        {
            State = ws;
            gun = factory.CreateGun();
            armor = factory.CreateArmor();
        }

        public void Jumping()
        {
            State.Jumping(this);
        }
        public void Standing()
        {
            State.Standing(this);
        }
        public void Lying()
        {
            State.Lying(this);
        }

        /*-------------------------------------------*/

        private int patrons = 5;
        public void Shoot()
        {
            if (patrons > 0)
            {
                patrons--;
                Console.WriteLine($"Shooting. {patrons} patrons");
            }
            else
                Console.WriteLine("There are no patrons");
        }

        public Memento SaveState()
        {
            Console.WriteLine($"Save the game. {patrons} patrons");
            return new Memento(patrons);
        }

        public void RestoreState(Memento memento)
        {
            patrons = memento.Patrons;
            Console.WriteLine($"Restore the game. {patrons} patrons");
        }
    }
}
