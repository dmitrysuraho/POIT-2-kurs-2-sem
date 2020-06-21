using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Memento
    {
        public int Patrons { get; private set; }

        public Memento(int patrons)
        {
            Patrons = patrons;
        }
    }
    class Restorer
    {
        public Stack<Memento> restorer { get; private set; }
        public Restorer()
        {
            restorer = new Stack<Memento>();
        }
    }
}
