using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game
{
    abstract class Engine
    {
        protected int maxCapacity;
        protected int fuelPerTurn;
        protected int fuel;

        public int MaxCapacity
        {
            get
            {
                return maxCapacity;
            }
        }

        public int Fuel
        {
            get
            {
                return fuel;
            }
        }


        public void AddFuel()
        {
            if (fuel < maxCapacity) fuel++;
        }

        public void EatFuel()
        {
            if (fuel > 0) fuel--;
        }
        //EngineType type;
        //public Engine(EngineType type)
        //{
        //    this.type = type;
        //}

    }
}
