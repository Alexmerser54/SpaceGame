using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game.Objects
{
    class Star: GameObject
    {
        int energyRadius;
        int destroyRadius;
        int power;
        int size;

        public Star(Point pos, int energyRadius, int destroyRadius, int power, int size): base(pos)
        {
            this.energyRadius = energyRadius;
            this.destroyRadius = destroyRadius;
            this.power = power;
            this.size = size;
        }

        public int Power
        {
            get
            {
                return power;
            }
        }

        public int EnergyRadius
        {
            get
            {
                return energyRadius;
            }
        }

        public int Size => size;

        public int DestroyRadius
        {
            get
            {
                return destroyRadius;
            }
        }


    }
}
