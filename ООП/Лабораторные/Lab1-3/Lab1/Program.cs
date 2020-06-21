using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Soldiers Soldier1 = new Soldiers(new Medic());
            //Console.WriteLine($"Damage: {Soldier1.Gun()}");
            //Console.WriteLine($"Armor amount: {Soldier1.Armor()}");
            //Soldiers Soldier2 = new Soldiers(new Shooter());
            //Console.WriteLine($"Damage: {Soldier2.Gun()}");
            //Console.WriteLine($"Armor amount: {Soldier2.Armor()}");
            //Console.WriteLine();

            //General General = General.GetInstance();
            //General.Gen();
            //Console.WriteLine();

            //BuilderBase Base1 = new BuilderBase();
            //Director Director1 = new Director(Base1);
            //Director1.BuildBase();
            //Console.WriteLine(Base1.Square);
            //BuilderBase Base2 = new BuilderBase();
            //Director Director2 = new Director(Base2);
            //Director2.BuildBaseNew();
            //Console.WriteLine(Base2.Square);
            //Console.WriteLine();

            //Soldier Soldier = new Soldier(100, "AK47", 70);
            //Soldier CloneSoldier1 = (Soldier)Soldier.Clone();
            //Soldier CloneSoldier2 = (Soldier)Soldier.DeepClone();
            //Console.WriteLine($"Soldier: {Soldier.Health} {Soldier.Ammunition.Gun} {Soldier.Ammunition.ArmorAmount}");
            //Console.WriteLine($"CloneSoldier1: {CloneSoldier1.Health} {CloneSoldier1.Ammunition.Gun} {CloneSoldier1.Ammunition.ArmorAmount}");
            //Console.WriteLine($"CloneSoldier2: {CloneSoldier2.Health} {CloneSoldier2.Ammunition.Gun} {CloneSoldier2.Ammunition.ArmorAmount}");
            //Soldier.Health = 22;
            //Soldier.Ammunition.ArmorAmount = 33;
            //Soldier.Ammunition.Gun = "M4A1";
            //Console.WriteLine($"Soldier: {Soldier.Health} {Soldier.Ammunition.Gun} {Soldier.Ammunition.ArmorAmount}");
            //Console.WriteLine($"CloneSoldier1: {CloneSoldier1.Health} {CloneSoldier1.Ammunition.Gun} {CloneSoldier1.Ammunition.ArmorAmount}");
            //Console.WriteLine($"CloneSoldier2: {CloneSoldier2.Health} {CloneSoldier2.Ammunition.Gun} {CloneSoldier2.Ammunition.ArmorAmount}");
            //Console.WriteLine();

            ///*----------------------------------------------------------------------------------------------------------------------------------------------*/

            //Soldiers soldier1 = new Soldiers(new Medic());
            //Soldiers soldier2 = new Soldiers(new Shooter());
            //Adapter adapter1 = new Adapter(soldier1);
            //Adapter adapter2 = new Adapter(soldier2);
            //adapter1.X(1);
            //adapter1.Y(11);
            //adapter1.Z(111);
            //adapter2.X(2);
            //adapter2.Y(22);
            //adapter2.Z(222);
            //Console.WriteLine();

            //IGun gun1 = new AK47();
            //Console.WriteLine($"Damage: {gun1.Shot()}");
            //IGun gun2 = new NewGun(gun1);
            //Console.WriteLine(gun2.Shot());
            //Console.WriteLine();

            //var city = new Map { Title = "New city" };
            //city.AddComponent(Base1);
            //city.AddComponent(General);
            //city.Draw();
            //Console.WriteLine();
            //var find1 = city.Find("General");
            //find1.Draw();
            //Console.WriteLine();

            /*----------------------------------------------------------------------------------------------------------------------------------------------*/

            General general = General.GetInstance();
            Soldiers soldier1 = new Soldiers(new Medic());
            general.SetCommand(new RunCommand(soldier1));
            general.PressRun();
            general.SetCommand(new FireGunCommand(soldier1));
            general.PressFireGun();
            Console.WriteLine();

            Soldiers soldier2 = new Soldiers(new StandingState(), new Shooter());
            soldier2.Standing();
            soldier2.Jumping();
            soldier2.Lying();
            soldier2.Standing();
            soldier2.Lying();
            soldier2.Jumping();
            Console.WriteLine();

            Soldiers soldier3 = new Soldiers(new Shooter());
            soldier3.Shoot();
            Restorer restorer = new Restorer();
            restorer.restorer.Push(soldier3.SaveState());
            soldier3.Shoot();
            soldier3.RestoreState(restorer.restorer.Pop());
        }
    }
}
