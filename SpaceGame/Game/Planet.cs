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
        Oil[] oils;

        public Planet(Point pos, Oil[] oils)
        {
            position = pos;
            this.oils = oils;
        }

        public Oil[] Oils
        {
            get
            {
                return oils;
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
