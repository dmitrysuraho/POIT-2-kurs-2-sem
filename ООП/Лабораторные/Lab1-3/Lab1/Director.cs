using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Director
    {
        private readonly BuilderBase Builder;
        public Director(BuilderBase builder)
        {
            Builder = builder;
        }
        public BuilderBase BuildBase()
        {
            return Builder.BuildTrainingCamp()
                          .BuildCanteen().BuildToilet().BuildRestRoom().GetResult();
        }

        public BuilderBase BuildBaseNew()
        {
            return Builder.BuildToilet().BuildRestRoom().GetResult();
        }
    }
}
