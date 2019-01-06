using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEvo
{
    public class Food
    {

        
        public int X { get; set; }
        public int Y { get; set; }

        public Food()
        {
            X = Rnd.RandomNumber(0, 50);
            Y = Rnd.RandomNumber(0, 50);
        }
        public Food(int x, int y)
        {
            X = x;
            Y = y;
        }
       
    
    }
}
