using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface ICommand
    {
        void Execute();
    };

    class RunCommand : ICommand
    {
        Soldiers Soldier;
        public RunCommand(Soldiers soldier)
        {
            Soldier = soldier;
        }
        public void Execute()
        {
            Soldier.Run();
        }
    }
    class FireGunCommand : ICommand
    {
        Soldiers Soldier;
        public FireGunCommand(Soldiers soldier)
        {
            Soldier = soldier;
        }
        public void Execute()
        {
            Soldier.FireGun();
        }
    }
}
