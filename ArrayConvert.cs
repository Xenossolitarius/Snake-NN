using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEvo
{
   static public class ArrayConvert
    {
       public static float[,] SingleToMulti(float[] array,int width,int height)
        {
            int index = 0;
            
            float[,] multi = new float[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    multi[x, y] = array[index];
                    index++;
                }
            }
            return multi;
        }


       
       public static float[] MultiToSingle(float[,] array,int width, int height)
                {
                    int index = 0;
                    float[] single = new float[width * height];
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            single[index] = array[x, y];
                            index++;
                        }
                    }
                    return single;
                }
            }
}
