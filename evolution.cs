using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeEvo
{
    public partial class Evolution : Form
    {
        Population population;
        Snake bestSnake;
        int populationSize;
        float globalMutationRate;
        long bestFitness;
        long lastFitness;
        Timer gameLoop = new Timer();
        Timer snakeLoop = new Timer();
        bool startSim = false;
        bool previewLabels = true;
        int timeAlive = 0;
        int leftTime = 0;
        int gameSpeed = 0;
        int currLength = 0;
        int bestGen = 0;
        public int maxLength = 0;
        int diedFromWall = 0;
        int diedFromSelf = 0;
        int diedFromTime = 0;
        int tempGen = 0;
        float parentRatio;
        bool renderStart = true;
        bool Elitism = false;
        

        public Evolution()
        {
            InitializeComponent();
            globalMutationRate = (float)mutationNumeric.Value;
            gameSpeed = 15;
            gameLoop.Tick += new EventHandler(UpdateScreen);
            snakeLoop.Tick += new EventHandler(UpdatePopulation);
            gameLoop.Interval = 1000 / 60;
            snakeLoop.Interval = 1000 / gameSpeed;
            gameLoop.Start();
            snakeLoop.Start();
            saveButton.Enabled = false;
            



        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            if(startSim == true)
                Draw(e.Graphics);
        }
        private void UpdateScreen(object sender, EventArgs e)
        {
            if (renderStart)
            {
                pbCanvas.Invalidate();
            }
        }
            private void Draw(Graphics canvas)
        {
            SnakePart currentPart;
            Color body;
            Color head;
            for (int i = 0; i < population.snakes.Length; i++)
            {
                if (population.snakes[i].alive == true)
                {

                    canvas.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(population.snakes[i].food.X * 8, population.snakes[i].food.Y * 8, 8, 8));
                    if(population.snakes[i].family == 0)
                    {
                        body = Color.Black;
                        head = Color.Red;

                    }else if(population.snakes[i].family == 1){
                        body = Color.Blue;
                        head = Color.White;
                    }
                    else
                    {
                        body = Color.White;
                        head = Color.Red;
                    }
                    for (int j = 0; j < population.snakes[i].tail.Count; j++)
                    {
                        //Color snake_color = i == 0 ? Color.Red : Color.Black;
                        currentPart = population.snakes[i].tail[j];
                        canvas.FillRectangle(new SolidBrush(body), new Rectangle(currentPart.X * 8, currentPart.Y * 8, 8, 8));
                    }
                    canvas.FillRectangle(new SolidBrush(head), new Rectangle(population.snakes[i].head.X * 8, population.snakes[i].head.Y * 8, 8, 8));
                }
            }

        }
        private void StartEvolution()
        {

            populationSize = (int)numericUpDownEvo.Value;
            population = new Population(populationSize,leftTime);
        }
        private void UpdatePopulation(object sender, EventArgs e)
        {
            
                if (startSim == true)
                {



                    population.UpdateAlive();

                    if (previewLabels)
                    {
                        PreviewLabels();
                    }

                    if (population.Done())
                    {
                        population.CalcFitness(Elitism);
                        for (int i = 0; i < population.snakes.Length; i++)
                        {

                            if (population.snakes[i].diedFromWall == true)
                            {
                                diedFromWall++;
                            }
                            else if (population.snakes[i].diedFromTime == true)
                            {
                                diedFromTime++;
                            }
                            else if (population.snakes[i].diedFromSelf == true)
                            {
                                diedFromSelf++;
                            }

                            if (currLength < population.snakes[i].len)
                            {
                                currLength = population.snakes[i].len;
                            }


                            if (lastFitness < population.snakes[i].fitness)
                            {
                                lastFitness = population.snakes[i].fitness;
                                if (lastFitness >= bestFitness)
                                {
                                    bestSnake = population.snakes[i];
                                    genSnakeLabel.Text = "Gen: " + population.gen;
                                    bestGen = population.gen;
                                }
                            }

                        }
                        if (lastFitness > bestFitness)
                        {
                            bestFitness = lastFitness;
                        }
                        if (maxLength < currLength)
                        {
                            maxLength = currLength;
                        }

                        if (Elitism)
                        {
                            population.NaturalSelectionImproved(globalMutationRate, parentRatio);
                        }
                        else
                        {
                            population.NaturalSelection(globalMutationRate);
                        }
                    
                       
                    
                        
                      
                        WriteLabels();
                        ResetTemps();
                        

                    }


                }
           

        }
          

        private void WriteLabels()
        {
            tempGen = population.gen + 1;
            highLenLabel.Text = "High. Length: " + maxLength;
            currLenLabel.Text = "Curr. Length: " + currLength;
            diedSelfLabel.Text = "Died From Self: " + diedFromSelf;
            diedWallLabel.Text = "Died From Wall: " + diedFromWall;
            diedTimeLabel.Text = "Died From Time: " + diedFromTime;
            lastFitnessLabel.Text = "Last. Fitness: " + lastFitness;
            bestFintessLabel.Text = "High. Fitness: " + bestFitness;
            generationLabel.Text = "Generation: " + population.gen;
            fitSnakeLabel.Text = "Fitness: " + bestSnake.fitness;
            


        }
        private void PreviewLabels()
        {
            int lenAlive = 0;
            int lenAll = 0;

            timeAlive++;
            timeAliveLabel.Text = "Time Alive: " + timeAlive;

            aliveLabel.Text = "Alive: " + population.StillAlive(out lenAlive, out lenAll);
            currMaxLen.Text = "Max Gen Len: " + lenAll;
            currMaxLenLabel.Text = "Curr Max Len: " + lenAlive;
        }
        private void ResetTemps()
        {
            timeAlive = 0;
            diedFromWall = 0;
            diedFromSelf = 0;
            diedFromTime = 0;
            currLength = 0;
            lastFitness = 0;
            tempGen = 0;
        }
 
        
        private void startEvo_Click(object sender, EventArgs e)
        {
            if (startSim == false)
            {

                leftTime = (int)leftTimeNumeric.Value;
                parentRatio = (float)numericParentRatio.Value;
                globalMutationRate = (float)mutationNumeric.Value;
                bestSnake = new Snake(leftTime);
                startEvo.Text = "Stop Evolution";
                StartEvolution();
                startSim = true;
                timeAlive = 0;
                bestFitness = 0;
                lastFitness = 0;
                maxLength = 0;
                generationLabel.Text = "Generation: 1";
                

            }
            else
            {
                startSim = false;
                startEvo.Text = "Start Evolution";
                timeAlive = 0;
                maxLength = 0;
                if(generationLabel.Text != "Generation: 1")
                    saveButton.Enabled = true;
                

            }

        }

        private void previewLabelsButton_Click(object sender, EventArgs e)
        {
            if(previewLabels == true)
            {
                previewLabels = false;
                previewLabelsButton.Text = "Start Stats Preview";
            }
            else
            {
                previewLabels = true;
                previewLabelsButton.Text = "Stop Stats Preview";

            }
        }

        private void buttonRender_Click(object sender, EventArgs e)
        {
            if(renderStart == true)
            {
                buttonRender.Text = "Start Render";
                renderStart = false;

                snakeLoop.Interval = 1;
            }
            else
            {
                renderStart = true;
                buttonRender.Text = "Stop Render";
                snakeLoop.Interval = 1000 / gameSpeed;
               
            }
        }

        private void updateMutation(object sender, EventArgs e)
        {
            globalMutationRate = (float)mutationNumeric.Value; ;
        }

        private void updateParent(object sender, EventArgs e)
        {
            parentRatio = (float)numericParentRatio.Value;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            snakeSerial tempSnake = new snakeSerial();

            
            
                       

                        tempSnake.whiRows = bestSnake.brain.whi.matrix.GetLength(0);
                        tempSnake.whiCols = bestSnake.brain.whi.matrix.GetLength(1);

                        tempSnake.whhRows = bestSnake.brain.whh.matrix.GetLength(0);
                        tempSnake.whhCols = bestSnake.brain.whh.matrix.GetLength(1);

                        tempSnake.wohRows = bestSnake.brain.woh.matrix.GetLength(0);
                        tempSnake.wohCols = bestSnake.brain.woh.matrix.GetLength(1);
                      
            tempSnake.gen = bestGen;
            tempSnake.fitness = bestSnake.fitness;
            tempSnake.lifeTime = leftTime;


            tempSnake.whi = ArrayConvert.MultiToSingle(bestSnake.brain.whi.matrix,tempSnake.whiRows,tempSnake.whiCols);
            tempSnake.whh = ArrayConvert.MultiToSingle(bestSnake.brain.whh.matrix, tempSnake.whhRows, tempSnake.whhCols);
            tempSnake.woh = ArrayConvert.MultiToSingle(bestSnake.brain.woh.matrix, tempSnake.wohRows, tempSnake.wohCols);


            saveButton.Enabled = false;

            var writer = new System.Xml.Serialization.XmlSerializer(typeof(snakeSerial));
            var wfile = new System.IO.StreamWriter(@"c:\temp\SnakeGen"+bestGen+"Fit"+bestSnake.fitness+".xml");
            writer.Serialize(wfile, tempSnake);
            wfile.Close();
            MessageBox.Show("Snake saved!");

            



          
        }

        private void elitismCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           if( elitismCheckBox.Checked != true)
            {
                Elitism = false;
                
            }
            else
            {
                Elitism = true;
                
            }
        }
    }
}
