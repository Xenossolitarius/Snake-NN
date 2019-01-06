using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEvo
{
    public class Matrix
    {
        public int rows;
        public int cols;
        public float[,] matrix;

        public Matrix(int r, int c)
        {
            rows = r;
            cols = c;
            matrix = new float[rows, cols];
        }
        public Matrix(float [,] m)
        {
            matrix = m;
            rows = m.GetLength(0);
            cols = m.GetLength(1);
        }
      public  void Multiply(float n)
        {
            for(int i = 0; i <rows; i++)
            {
                for(int j = 0; j<cols; j++)
                {
                    matrix[i,j] *= n;
                }
            }
        }
        //mnozenje jednodim. vektora "Dot product in Matrix notation
       public Matrix Dot(Matrix n)
        {
            Matrix result = new Matrix(rows, n.cols);
            if(cols == n.rows)
            {
                for(int i = 0; i < rows; i++)
                {
                    for(int j = 0; j < n.cols; j++)
                    {
                        float sum = 0;
                        for (int k=0 ; k < cols ; k++)
                        {
                            sum += matrix[i, k] * n.matrix[k, j];
                        }
                        result.matrix[i, j] = sum;
                    }
                }
            }
            return result;
        }
       public void Randomize() 
        {
            int max = 1;
            int min = -1;
            for(int i= 0; i<rows; i++)
            {
                for(int j=0; j<cols; j++)
                {
                    
                    matrix[i, j] = (float)(Rnd.RandomDouble() * Math.Abs(max - min) + min);
        }
            }
        }
       public void Add(float n)
        {
            for(int i = 0; i <rows; i++)
            {
                for(int j = 0; j< cols; j++)
                {
                    matrix[i, j] += n;
                }
            }
        }
       public Matrix Add (Matrix n)
        {
            Matrix newMatrix = new Matrix(rows, cols);
            if(cols == n.cols && rows == n.rows)
            {
                for(int i = 0; i<rows; i++)
                {
                    for(int j=0; j<cols; j++)
                    {
                        newMatrix.matrix[i, j] = matrix[i, j] + n.matrix[i, j];
                    }
                }
            }
            return newMatrix;
        }
      public  Matrix Substract(Matrix n)
        {
            Matrix newMatrix = new Matrix(rows, cols);
            if (cols == n.cols && rows == n.rows)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        newMatrix.matrix[i, j] = matrix[i, j] - n.matrix[i, j];
                    }
                }
            }
            return newMatrix;
        }
       public Matrix Multiply(Matrix n)
        {
            Matrix newMatrix = new Matrix(rows, cols);
            if (cols == n.cols && rows == n.rows)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        newMatrix.matrix[i, j] = matrix[i, j] * n.matrix[i, j];
                    }
                }
            }
            return newMatrix;
        }
         public Matrix Transpose()
        {
            Matrix n = new Matrix(cols, rows);
            for(int i = 0; i<rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    n.matrix[j, i] = matrix[i, j];
                }
            }
            return n;
        }
        public Matrix SingleColumnMatrixFromArray(float[] arr)
        {
            Matrix n = new Matrix(arr.Length, 1);
            for(int i = 0; i < arr.Length; i++)
            {
                n.matrix[i, 0] = arr[i];
            }
            return n;
        }
        public void FromArray(float[] arr)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i,j] = arr[j + i * cols];
                }

            }
        }
       public float[] ToArray()
        {
            float[] arr = new float[rows * cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[j + i * cols] = matrix[i,j];
                }
            }
            return arr;
        }
        //još jedan red i popuni ga sa 1
       public Matrix AddBias()
        {
            Matrix n = new Matrix(rows + 1, 1);
            for (int i = 0; i < rows; i++)
            {
                n.matrix[i,0] = matrix[i,0];
            }
            n.matrix[rows,0] = 1;
            return n;
        }
        //prođi kroz aktivacijsku funkciju - sigmoid
       public Matrix Activate()
        {
            Matrix n = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    n.matrix[i,j] = Sigmoid(matrix[i,j]);
                }
            }
            return n;
        }
        //sigmoid ( ovo zamjeniti za neku drugu aktiv. funkc)
       public float Sigmoid(float x)
        {

            float y = 1 / (1 + (float)Math.Pow((float)Math.E, -x));

            return y;

        }
        //dobivena matrica nakon aktivacije
      public  Matrix SigmoidDerived()
        {
            Matrix n = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    n.matrix[i,j] = (matrix[i,j] * (1 - matrix[i,j]));
                }
            }
            return n;
        }
       public Matrix RemoveBottomLayer()
        {
            Matrix n = new Matrix(rows - 1, cols);
            for (int i = 0; i < n.rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    n.matrix[i,j] = matrix[i,j];
                }
            }
            return n;
        }

      public  void Mutate(float mutationRate)
        {
            
            double mean = 0; //parametriziranje
            double stdDev = 1; //parametriziranje
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                   
                    float rand = (float)Rnd.RandomDouble();

                    if (rand < mutationRate) //ako je izabran za mutaciju
                    {
                        //Gaussian rand - Box-Muller
                        double u1 = 1.0 - Rnd.RandomDouble(); //(0,1] random double
                        double u2 = 1.0 - Rnd.RandomDouble();
                        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                     Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                        double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)



                        matrix[i,j] += (float)randNormal / 5; //dodaj random vrijednost, +,-

                        //ispravi
                        if (matrix[i,j] > 1)
                        {
                            matrix[i,j] = 1;
                        }

                        if (matrix[i,j] < -1)
                        {
                            matrix[i,j] = -1;
                        }

                    }

                }

            }

        }
      public  Matrix Crossover(Matrix partner)
        {
            
            Matrix child = new Matrix(rows, cols);

            double tempRandC = Rnd.RandomDouble() * cols;
            double tempRandR = Rnd.RandomDouble() * rows;
            

            int randC = (int)Math.Floor(tempRandC);

            int randR = (int)Math.Floor(tempRandR);

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {

                    if ((i < randR) || (i == randR && j <= randC))  //ispod i poviše nasumične točke
                    { 

                        child.matrix[i,j] = matrix[i,j];  //prvi roditelj

                    }
                    else
                    { 

                        child.matrix[i,j] = partner.matrix[i,j]; //drugi roditelj

                    }

                }

            }

            return child;

        }
      public  Matrix Clone()
        {
            Matrix clone = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
            {

                for (int j = 0; j < cols; j++)
                {

                    clone.matrix[i,j] = matrix[i,j];

                }

            }

            return clone;
        }



    }
}
