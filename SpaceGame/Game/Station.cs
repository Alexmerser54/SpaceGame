using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game
{
    class Station
    {
        Point position;

        public Station(Point pos)
        {
            position = pos;
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
