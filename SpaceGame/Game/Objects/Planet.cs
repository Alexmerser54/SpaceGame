using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game.Objects
{
    class Planet : GameObject
    {
        Oil[] oils;

        public Planet(Point pos, Oil[] oils) : base(pos)
        {
            this.oils = oils;
        }

        public Oil[] Oils => oils;
    }
}
