using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game.Objects
{
    class NuclearEngine : Engine
    {
        public NuclearEngine()
        {
            this.fuel = this.maxCapacity = 1500;
        }
    }
}
