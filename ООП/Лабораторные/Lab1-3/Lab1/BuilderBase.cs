using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IBuilderBase
    {
        BuilderBase BuildTrainingCamp();
        BuilderBase BuildCanteen();
        BuilderBase BuildToilet();
        BuilderBase BuildRestRoom();
        BuilderBase GetResult();
    }
    class BuilderBase : IBuilderBase, IComponent
    {
        public string Title { get; set; } = "Military Base";
        public int Square { get; private set; } = 100;
        public BuilderBase BuildTrainingCamp()
        {
            Square += 20;
            Console.WriteLine("Training camp is built");
            return this;
        }
        public BuilderBase BuildCanteen()
        {
            Square += 10;
            Console.WriteLine("Canteen is built");
            return this;
        }
        public BuilderBase BuildToilet()
        {
            Square += 5;
            Console.WriteLine("Toilet is built");
            return this;
        }
        public BuilderBase BuildRestRoom()
        {
            Square += 7;
            Console.WriteLine("Rest room is built");
            return this;
        }
        public BuilderBase GetResult()
        {
            return this;
        }

        public void Draw()
        {
            Console.WriteLine(Title);
        }
        public IComponent Find(string title)
        {
            return Title == title ? this : null;
        }
    }
}
