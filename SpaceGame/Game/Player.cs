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

        public Player(Point pos)
        {
            this.pos = pos;
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
            this.pos.X = x;
            this.pos.Y = y;
        }
        

    }
}
