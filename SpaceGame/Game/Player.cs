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
        int maxFuel;

        public Player(Point pos, int maxFuel, Engine[] engines)
        {
            this.pos = pos;
            this.maxFuel = maxFuel;
            this.engines = engines;
            this.engineCount = engines.Length;
            fuel = 0;
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

        public void Teleport(Point pos)
        {
            this.pos = pos;
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

        public void AddFuel()
        {
            if (fuel < maxFuel) fuel++;
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
