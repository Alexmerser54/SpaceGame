using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game
{
    class Player
    {
        Point pos;
        int[,] postion;
        int fuel;
        Engine[] engines;
        int engineCount;

        public Player(Point pos, int fuel, Engine[] engines)
        {
            this.pos = pos;
            this.fuel = fuel;
            this.engines = engines;
            this.engineCount = engines.Length;
        }

        public Point Position
        {
            get
            {
                return pos;
            }
        }

        public void Move(int x, int y)
        {
            bool canMove = false;

            foreach (var engine in engines)
            {
                if (engine.Fuel > 0)
                {
                    canMove = true;
                    engine.EatFuel();
                    break;
                }
            }

            if (canMove)
            {
                this.pos.X = x;
                this.pos.Y = y;
            }
            

        }

        public void refuelEngine(Type type)
        {
            foreach (var engine in engines)
            {
                if (engine.GetType() == type)
                {
                    engine.AddFuel();
                }
            }
        }

        public int Fuel
        {
            get
            {
                return fuel;
            }
        }

        public int EnginesCount
        {
            get
            {
                return engineCount;
            }
        }

        public void AddFuel(int num)
        {
            fuel += num;
        }

        public void RemoveFuel(int num)
        {
            fuel -= num;
        }
       
        public Engine[] GetEngines()
        {
            return engines;
        }

    }
}
