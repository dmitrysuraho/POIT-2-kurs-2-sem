using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface ITarget
    {
        void X(int x);
        void Y(int y);
        void Z(int z);
    }

    class Adapter : ITarget
    {
        private readonly Soldiers adaptee;
        public Adapter(Soldiers adaptee)
        {
            this.adaptee = adaptee;
        }

        public void X(int x)
        {
            if(adaptee.Gun() == 150)
            {
                Console.WriteLine($"Медик передвинулся на {x} по X");
            }
            else if (adaptee.Gun() == 90)
            {
                Console.WriteLine($"Стрелок передвинулся на {x} по X");
            }
        }
        public void Y(int y)
        {
            if (adaptee.Gun() == 150)
            {
                Console.WriteLine($"Медик передвинулся на {y} по Y");
            }
            else if (adaptee.Gun() == 90)
            {
                Console.WriteLine($"Стрелок передвинулся на {y} по Y");
            }
        }
        public void Z(int z)
        {
            if (adaptee.Gun() == 150)
            {
                Console.WriteLine($"Медик передвинулся на {z} по Z");
            }
            else if (adaptee.Gun() == 90)
            {
                Console.WriteLine($"Стрелок передвинулся на {z} по Z");
            }
        }
    }
}
