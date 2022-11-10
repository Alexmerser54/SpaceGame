using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game
{
    class Planet
    {
        Point position;

        public Planet(Point pos)
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
