using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeEvo
{
    public class Snake
    {
        public int len = 1;
        public SnakePart head;
        public List<SnakePart> tail;
        public SnakePart vel;
        public Food food;
        public NeuralNet brain;
        float[] vision = new float[24];
        public float[] decision;
        public bool diedFromWall = false;
        public bool diedFromSelf = false;
        public bool diedFromTime = false;
        public int lifeTime = 0;
        public long fitness = 0;
        public int leftToLive;
        public int family;

        public int growCount = 0;
        public bool alive = true;
        public int leftTimeLive;
        public Snake(int leftTime)
        {
            int x = 24;
            int y = 24;
            family = 0;
            head = new SnakePart(x, y);
            vel = new SnakePart(1, 0);
            tail = new List<SnakePart>();
            tail.Add(new SnakePart(x-1 , y));
            tail.Add(new SnakePart(x-2 , y));
            tail.Add(new SnakePart(x-3 , y));
            len += 3;

            //spriječavanje stavljanja hrane u zmiju
            food = new Food();
            while (tail.Contains(new SnakePart(food.X, food.Y))) 
            {
                food = new Food();
            }

            brain = new NeuralNet(24, 18, 4);
            //brain = new NeuralNet(24, 30, 4);
            leftToLive = leftTime;
            leftTimeLive = leftTime;
        }

        public float[] LookInDirection(SnakePart direction)
        {
            float[] visionInDirection = new float[3];

            SnakePart position = new SnakePart(head.X, head.Y);
            bool foodIsFound = false;
            bool tailIsFound = false;
            float distance = 0;

            position.Add(direction);
            distance += 1;

            /////
          
            SnakePart tempHead = new SnakePart(head.X, head.Y);

            
            double distanceBefore = Math.Sqrt(Math.Pow(food.X - tempHead.X, 2) + Math.Pow(food.Y - tempHead.Y, 2));
            tempHead.Add(direction);
            double distanceAfter = Math.Sqrt(Math.Pow(food.X - tempHead.X, 2) + Math.Pow(food.Y - tempHead.Y, 2));

            if (distanceAfter < distanceBefore)
            {

                float temp = (float)(distanceBefore-distanceAfter);
                    visionInDirection[0] = temp;
               
            }
            
            /////


            while (!(position.X >= 50 || position.X < 0 || position.Y >= 50 || position.Y < 0))
            {
                /*
                if(!foodIsFound && position.X == food.X && position.Y == food.Y)
                {
                    visionInDirection[0] = 1;
                    foodIsFound = true;
                }*/

                
                if(!tailIsFound && IsOnTail(position.X, position.Y))
                {
                    visionInDirection[1] = 1 / distance;
                    tailIsFound = true;
                }

                position.Add(direction);
                distance += 1;



            }

            visionInDirection[2] = 1 / distance;
            return visionInDirection;
        }
        public void HighestFood()////////////////////////
        {
            float foodMax = 0;
            int indexMax = 0;
            for(int i =0; i<24; i= i + 3)
            {
                if(foodMax < vision[i])
                {
                    foodMax = vision[i];
                    indexMax = i;
                }
                vision[i] = 0;
                
            }
            vision[indexMax] = 1;
           
       }////////////////////////////////////////
        public bool IsOnTail(int x,int y)
        {
            for (int i = 0; i < tail.Count; i++)
            {
               

                if (x == tail[i].X && y == tail[i].Y)
                {

                    
                    return true;
                }
            }
            return false;
        }

        public void Look()
        {
            vision = new float[24];

            float[] tempValues = LookInDirection(new SnakePart(-1, 0));

            vision[0] = tempValues[0];

            vision[1] = tempValues[1];

            vision[2] = tempValues[2];

            

            tempValues = LookInDirection(new SnakePart(-1, -1));

            vision[3] = tempValues[0];

            vision[4] = tempValues[1];

            vision[5] = tempValues[2];

            

            tempValues = LookInDirection(new SnakePart(0, -1));

            vision[6] = tempValues[0];

            vision[7] = tempValues[1];

            vision[8] = tempValues[2];

            

            tempValues = LookInDirection(new SnakePart(1, -1));

            vision[9] = tempValues[0];

            vision[10] = tempValues[1];

            vision[11] = tempValues[2];

            

            tempValues = LookInDirection(new SnakePart(1, 0));

            vision[12] = tempValues[0];

            vision[13] = tempValues[1];

            vision[14] = tempValues[2];

            

            tempValues = LookInDirection(new SnakePart(1, 1));

            vision[15] = tempValues[0];

            vision[16] = tempValues[1];

            vision[17] = tempValues[2];

            

            tempValues = LookInDirection(new SnakePart(0, 1));

            vision[18] = tempValues[0];

            vision[19] = tempValues[1];

            vision[20] = tempValues[2];

           

            tempValues = LookInDirection(new SnakePart(-1, 1));

            vision[21] = tempValues[0];

            vision[22] = tempValues[1];

            vision[23] = tempValues[2];
        }
        public void SetVelocity()
        {
            decision = brain.Output(vision);

            float max = 0;
            int maxIndex = 0;
            for(int i= 0; i < decision.Length; i++)
            {
                if(max < decision[i])
                {
                    max = decision[i];
                    maxIndex = i;
                }
            }

            if(maxIndex == 0)
            {
               if (vel.X != 1 && vel.Y != 0){
                    vel.X = -1;
                    vel.Y = 0;
               }
            }
            else if(maxIndex == 1)
            {
               if (vel.X != 0 && vel.Y != 1) {
                    vel.X = 0;
                    vel.Y = -1;
               }
            }
            else if(maxIndex == 2)
            {
                if (vel.X != -1 && vel.Y != 0){
                    vel.X = 1;
                    vel.Y = 0;
                }
            }
            else
            {
               if (vel.X != 0 && vel.Y != -1) {
                    vel.X = 0;
                    vel.Y = 1;
                }
            }
            
        }
        public void Move()
        {
            lifeTime += 1;
            leftToLive -= 1;

            if (leftToLive < 0)
            {
                alive = false;
                diedFromTime = true;
            }
            if (GoingToDie(head.X + vel.X, head.Y + vel.Y))
            {
                alive = false;
            }

            if ((head.X + vel.X) == food.X && (head.Y + vel.Y) == food.Y)
            {
                Eat();
            }
            if (growCount > 0)
            {
                growCount--;
                Grow();
            }
            else
            {
                int count = tail.Count;
                for(int i = count -1; i > 0; i--)
                {
                    tail[i].X = tail[i - 1].X;
                    tail[i].Y = tail[i - 1].Y;
                }
                tail[0].X = head.X;
                tail[0].Y = head.Y;
            }
            head.Add(vel);
        }

       public Snake Clone(int leftTime)
        {
            Snake clone = new Snake(leftTime);
            clone.brain = brain.Clone();
            clone.alive = true;
            return clone;
        }
       
        public Snake Crossover(Snake partner)
        {
            Snake child = new Snake(leftTimeLive);
            child.brain = brain.Crossover(partner.brain);
            return child;
        }
        public void CalcFitness(bool elitism)
        {
            
            if (diedFromWall && elitism == false)
            {
                fitness = 1;
            }
            else
            {
                fitness = (long)Math.Floor(lifeTime * Math.Pow(len - 3, 2));
            }

            
            /*if(len < 10)
            {
                
                fitness = (long)Math.Floor(lifeTime * lifeTime * Math.Pow(2, len));
                
                

                     
            }
            else
            {
                fitness = lifeTime * lifeTime;
                fitness *= (long)Math.Floor(Math.Pow(2, 10));
                fitness *= (len - 9);
                


            }*/
        }
        public bool GoingToDie(int x, int y)
        {
            
            if(x >= 50 || x < 0 || y>= 50 || y < 0)
            {
                diedFromWall = true;
                return true;
            }
            if (IsOnTail(x, y)) {
                diedFromSelf = true;
                return true;
            }
            return false;
        }
        public void Grow()
        {
            tail.Insert(0,new SnakePart(head.X, head.Y));
            len += 1;
        }
        public void Eat()
        {
            food = new Food();
            while (tail.Contains(new SnakePart(food.X, food.Y)))
            {
                food = new Food();
            }

            leftToLive += leftTimeLive/2;
            growCount += 1;
        }
        public void Mutate(float mr)
        {
            brain.Mutate(mr);
        }

    }
}
