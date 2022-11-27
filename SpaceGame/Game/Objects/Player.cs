using SpaceGame.Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game.Objects
{
    class Player: GameObject
    {
        int fuel;
        Engine[] engines;
        int engineCount;
        int maxFuel;
        int fuelPerTurn;

        public Player(Point pos, int maxFuel, Engine[] engines, int fuelPerTurn): base(pos)
        {
            this.maxFuel = maxFuel;
            this.engines = engines;
            this.engineCount = engines.Length;
            this.fuelPerTurn = fuelPerTurn;
            fuel = 0;
        }


        public void Move(Point newPos)
        {
            Point coordsToMove;

            bool canMove = false;

            foreach (var engine in engines)
            {
                if (engine.Fuel > 0)
                {
                    canMove = true;
                    break;
                }
            }

            if (!canMove) return;

            int tempX;
            int tempY;

            if (newPos.X > position.X)
            {
                tempX = position.X + 1;
            }
            else if (newPos.X < position.X)
            {
                tempX = position.X - 1;
            }
            else
            {
                tempX = position.X;
            }

            if (newPos.Y > position.Y)
            {
                tempY = position.Y + 1;
            }
            else if (newPos.Y < position.Y)
            {
                tempY = position.Y - 1;
            }
            else
            {
                tempY = position.Y;
            }


            foreach (var engine in engines)
            {
                if (engine.Fuel > 0)
                {
                    engine.EatFuel(fuelPerTurn);
                    break;
                }
            }

            position = new Point(tempX, tempY);


        }

        public void Teleport(Point pos)
        {
            this.position = pos;
        }

        public void refuelEngine(Type type, int num)
        {
            foreach (var engine in engines)
            {
                if (engine.GetType() == type)
                {
                    engine.AddFuel(num);
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
