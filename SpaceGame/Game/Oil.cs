using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game
{
    class Oil
    {
        int value;
        Point position;
        bool isEmpty;
        public Oil(int value, Point position)
        {
            this.value = value;
            this.position = position;
        }
        
        public void DrawOil()
        {
            if (value > 0) value--;
            else isEmpty = true;
        }

        public Point Position
        {
            get
            {
                return position;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return isEmpty;
            }
        }

        public int Value
        {
            get
            {
                return Value;
            }
        }
        
    }
}
