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

        public int MaxCapacity => maxCapacity;


        public int Fuel => fuel;


        public void AddFuel(int num)
        {
            if (fuel + num >= maxCapacity) fuel = maxCapacity;
            else if (fuel < maxCapacity) fuel += num;
        }

        public void EatFuel(int num)
        {
            if (fuel > 0) fuel -= num;
        }
        //EngineType type;
        //public Engine(EngineType type)
        //{
        //    this.type = type;
        //}

    }
}
