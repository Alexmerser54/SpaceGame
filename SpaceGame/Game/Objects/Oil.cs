using SpaceGame.Game.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Game.Objects
{
    class Oil: GameObject
    {
        int value;
        bool isEmpty;
        public Oil(int value, Point position): base(position)
        {
            this.value = value;
        }
        
        public void DrawOil()
        {
            if (value > 0) value--;
            else isEmpty = true;
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
