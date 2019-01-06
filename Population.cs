using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeEvo
{
    class Population
    {
        public Snake[] snakes;
        public int gen = 1;
        long globalBestFitness = 0;
        public int currentBest = 4;
        int leftTimeLive;

        public Snake globalBestSnake;

        int populationID;

        public Population(int size,int leftTime)
        {
            snakes = new Snake[size];
            for(int i = 0; i < size; i++)
            {
                snakes[i] = new Snake(leftTime);
            }
            populationID = Rnd.RandomNumber(0, 10000);
            leftTimeLive = leftTime;
        }

        public void UpdateAlive()
        {
            for (int i = 0; i < snakes.Length; i++)
            {
                if (snakes[i].alive)
                {
                    snakes[i].Look();
                    snakes[i].HighestFood();//
                    snakes[i].SetVelocity();
                    snakes[i].Move();

                }
            }
           
        }
        public bool Done()
        {
            for(int i=0; i <snakes.Length; i++)
            {
                if (snakes[i].alive)
                {
                    return false;
                }
            }
            return true;
        }
        public int StillAlive(out int lenAlive, out int lenAll)
        {
            int sum = 0;
            lenAlive = 0;
            lenAll = 0;
            for (int i = 0; i < snakes.Length; i++)
            {
                if (snakes[i].alive)
                {
                    sum++;
                    if (lenAlive < snakes[i].len)
                    {
                        lenAlive = snakes[i].len;
                    }
                }
                
                    if (lenAll < snakes[i].len)
                    {
                        lenAll = snakes[i].len;
                    }
                
            }
            return sum;

        }
        public void CalcFitness(bool elitism)
        {
            for(int i = 0; i < snakes.Length; i++)
            {
                snakes[i].CalcFitness(elitism);
            }
        }
        public void Mutate(float mr)
        {
            for ( int i = 1; i <snakes.Length; i++)
            {
                snakes[i].Mutate(mr);
            }
        }
        public Snake SelectSnake()
        {
            long fitnessSum = 0;
            for( int i=0; i<snakes.Length; i++)
            {
                fitnessSum += snakes[i].fitness;
            }

            
            long rand = (long)Math.Floor(Rnd.RandomDouble() * fitnessSum);
            long runningSum = 0;
            for(int i = 0; i < snakes.Length; i++)
            {
                runningSum += snakes[i].fitness;
                if(runningSum > rand)
                {
                    return snakes[i];
                }
            }
            return snakes[0];

        }
        public Snake SelectParent (Snake[] parents)
        {
            return parents[Rnd.RandomNumber(0,parents.Length)];
        }
       
    
        public void SetBestSnake()
        {
            long max = 0;
            int maxIndex = 0;
            for (int i=0; i < snakes.Length; i++)
            {
                if(snakes[i].fitness > max)
                {
                    max = snakes[i].fitness;
                    maxIndex = i;
                }
            }
            if(max > globalBestFitness)
            {
                globalBestFitness = max;
                globalBestSnake = snakes[maxIndex].Clone(leftTimeLive);
            }
          
        }
        public void NaturalSelectionImproved(float mr , float percentOld)
        {
            
            int j = 0;
            long fitnessPivot;
            int parents = (int)(snakes.Length * percentOld);
            int children = snakes.Length - parents;
            long[] fitnessArray = new long[snakes.Length];

            for (int i = 0; i < snakes.Length; i++)
            {
                fitnessArray[i] = snakes[i].fitness;
            }
            Array.Sort(fitnessArray);
            Array.Reverse(fitnessArray);
            fitnessPivot = fitnessArray[parents];

            Snake[] newSnakes = new Snake[snakes.Length];
            Snake[] parentsSnakes = new Snake[parents];
            Snake[] childrenSnakes = new Snake[children];
            
            for (int i = 0; i < snakes.Length; i++)
            {
                if(snakes[i].fitness >= fitnessPivot)
                {
                    //snakes[i].Mutate(mr);
                    parentsSnakes[j] = snakes[i];
                    j++;
                    if( j == parentsSnakes.Length) {
                        break;
                    }
                }

            }

            for (int i = 0; i < childrenSnakes.Length; i++)
            {
                Snake parent1 = SelectSnake();
                Snake parent2 = SelectSnake();

                Snake child = parent1.Crossover(parent2);
                child.Mutate(mr);
                child.family = 1;
                childrenSnakes[i] = child;
            }

            SetBestSnake();
            newSnakes[0] = globalBestSnake.Clone(leftTimeLive);
            j = 0;
            for (int i = 0; i < snakes.Length; i++)
            {
                if (i >= parentsSnakes.Length)
                {
                    newSnakes[i] = childrenSnakes[j];
                    j++;
                }
                else
                {
                    newSnakes[i] = parentsSnakes[i].Clone(leftTimeLive);
                }
               
            }

            
            newSnakes[0] = globalBestSnake.Clone(leftTimeLive);
            newSnakes[0].family = 2;
            newSnakes[1] = globalBestSnake.Clone(leftTimeLive);
            newSnakes[1].Mutate(mr);
            newSnakes[1].family = 2;
            snakes = newSnakes;
            gen += 1;
            currentBest = 4;

        }

        public void NaturalSelection(float mr)
        {
            Snake[] newSnakes = new Snake[snakes.Length];
            SetBestSnake();
            newSnakes[0] = globalBestSnake.Clone(leftTimeLive);
            for( int i = 1; i < newSnakes.Length; i++)
            {
                Snake parent1 = SelectSnake();
                Snake parent2 = SelectSnake();

                Snake child = parent1.Crossover(parent2);
                child.Mutate(mr);
                newSnakes[i] = child;
            }
            snakes = newSnakes;
            gen += 1;
            currentBest = 4;
        }
       
        
    }
}
