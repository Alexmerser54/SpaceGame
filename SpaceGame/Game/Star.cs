using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game
{
    class Star
    {
        Point position;
        int radius;
        int power;

        public Star(Point pos, int radius, int power)
        {
            position = pos;
            this.radius = radius;
            this.power = power;
        }

        public int Power
        {
            get
            {
                return power;
            }
        }

        public int Radius
        {
            get
            {
                return radius;
            }
        }

        public Point Position
        {
            get
            {
                return position;
            }
        }

    }
}
