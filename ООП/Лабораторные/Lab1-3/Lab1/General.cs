using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    sealed class General : IComponent 
    {
        public string Title { get; set; } = "General";
        public int Armor { get; set; } = 150;
        public string Gun { get; private set; } = "Deagle";

        private static readonly Lazy<General> Lazy = new Lazy<General>(() => new General());
        private General() { }
        public static General GetInstance()
        {
            return Lazy.Value;
        }
        public void Gen()
        {
            Console.WriteLine($"General: armor - {Armor}, gun - {Gun}");
        }
        public void Draw()
        {
            Console.WriteLine(Title);
        }
        public IComponent Find(string title)
        {
            return Title == title ? this : null;
        }

        /*--------------------------------------------------*/

        ICommand command;
        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressRun()
        {
            if (command != null && (command is RunCommand))
                command.Execute();
        }
        public void PressFireGun()
        {
            if (command != null && (command is FireGunCommand))
                command.Execute();
        }
    }
}
