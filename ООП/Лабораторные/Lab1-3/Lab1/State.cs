using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface ISoldierState
    {
        void Jumping(Soldiers soldier);
        void Standing(Soldiers soldier);
        void Lying(Soldiers soldier);
    }

    class JumpingState : ISoldierState
    {
        public void Jumping(Soldiers soldier)
        {
            Console.WriteLine("Cant jump in jumping state");
        }
        public void Standing(Soldiers soldier)
        {
            Console.WriteLine("Soldier stand");
            soldier.State = new StandingState();
        }
        public void Lying(Soldiers soldier)
        {
            Console.WriteLine("Cant lie down in jumping state");
        }
    }
    class StandingState : ISoldierState
    {
        public void Jumping(Soldiers soldier)
        {
            Console.WriteLine("Soldier jump");
            soldier.State = new JumpingState();
        }
        public void Standing(Soldiers soldier)
        {
            Console.WriteLine("Cant stand in standing state");
        }
        public void Lying(Soldiers soldier)
        {
            Console.WriteLine("Soldier lie");
            soldier.State = new LyingState();
        }
    }
    class LyingState : ISoldierState
    {
        public void Jumping(Soldiers soldier)
        {
            Console.WriteLine("Cant jump in lying state");
        }
        public void Standing(Soldiers soldier)
        {
            Console.WriteLine("Soldier stand");
            soldier.State = new StandingState();
        }
        public void Lying(Soldiers soldier)
        {
            Console.WriteLine("Cant lie in lying state");
        }
    }
}
