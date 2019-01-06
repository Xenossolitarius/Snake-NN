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
    public partial class gameForm : Form
    {
        bool buttonPressed = false;
        int score = 0;
        bool gameover = true;
        Timer gameLoop = new Timer();
        Timer snakeLoop = new Timer();
        Snake oneSnake = new Snake(10);
        
        public gameForm()
        {
            InitializeComponent();
            gameLoop.Tick += new EventHandler(Update);
            snakeLoop.Tick += new EventHandler(UpdateSnake);
            gameLoop.Interval = 1000 / 60;
            snakeLoop.Interval = 1000/10;
            gameLoop.Start();
            snakeLoop.Start();
           
        }

        private void formGame_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void formGame_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            //Graphics canvas = e.Graphics;
            Draw(e.Graphics);
        }

        private void StartGame()
        {
            gameover = false;
           
            score = 0;
            
            
        }

        private void Update(object sender, EventArgs e)
        {
            if (gameover)
            {
                if (Input.Press(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (Input.Press(Keys.Left))
                {
                    if(oneSnake.vel.X == 0 && (oneSnake.vel.Y == 1 || oneSnake.vel.Y == -1))
                    {
                        oneSnake.vel.X = -1;
                        oneSnake.vel.Y = 0;
                    }
                    
                }
                else if (Input.Press(Keys.Right))
                {
                    if (oneSnake.vel.X == 0 && (oneSnake.vel.Y == 1 || oneSnake.vel.Y == -1))
                    {
                        oneSnake.vel.X = 1;
                        oneSnake.vel.Y = 0;
                    }
                }
                else if (Input.Press(Keys.Up))
                {
                    if ((oneSnake.vel.X == 1 || oneSnake.vel.X == -1) && oneSnake.vel.Y == 0)
                    {
                        oneSnake.vel.X = 0;
                        oneSnake.vel.Y = -1;
                    }
                }
                else if (Input.Press(Keys.Down))
                {
                    if ((oneSnake.vel.X == 1 || oneSnake.vel.X == -1) && oneSnake.vel.Y == 0)
                    {
                        oneSnake.vel.X = 0;
                        oneSnake.vel.Y = 1;
                    }
                }
            }
            pbCanvas.Invalidate();
        }
        private void UpdateSnake(object sender, EventArgs e)
        {
            if (buttonPressed == true && gameover == false)
            {

                if (oneSnake.GoingToDie(oneSnake.head.X + oneSnake.vel.X, oneSnake.head.Y + oneSnake.vel.Y))
                {
                    GameOver();
                }

                if ((oneSnake.head.X + oneSnake.vel.X) == oneSnake.food.X && (oneSnake.head.Y + oneSnake.vel.Y) == oneSnake.food.Y)
                {
                    oneSnake.Eat();
                    score++;
                    scoreLabel.Text = "Score: " + score;
                }
                if (oneSnake.growCount > 0)
                {
                    oneSnake.growCount--;
                    oneSnake.Grow();
                }
                else
                {
                    int count = oneSnake.tail.Count;
                    for (int i = count - 1; i > 0; i--)
                    {
                        oneSnake.tail[i].X = oneSnake.tail[i - 1].X;
                        oneSnake.tail[i].Y = oneSnake.tail[i - 1].Y;
                    }
                    oneSnake.tail[0].X = oneSnake.head.X;
                    oneSnake.tail[0].Y = oneSnake.head.Y;
                }
                oneSnake.head.Add(oneSnake.vel);

            }
           
        } 
        private void Draw(Graphics canvas)
        {
            Font font = this.Font;
            if (!buttonPressed)
            {
                SizeF message = canvas.MeasureString("Press Enter to Start a New Game", font);
                canvas.DrawString("Press Enter to Start a New Game", font, Brushes.White, new PointF(200 - message.Width / 2, 160));
                message = canvas.MeasureString("Snake EVO", font);
                canvas.DrawString("Snake EVO", font, Brushes.White, new PointF(200 - message.Width / 2, 180));
                message = canvas.MeasureString("Završni rad", font);
                canvas.DrawString("Završni rad", font, Brushes.White, new PointF(200 - message.Width / 2, 200));
                message = canvas.MeasureString("Student: Ivan Pešić", font);
                canvas.DrawString("Student: Ivan Pešić", font, Brushes.White, new PointF(200 - message.Width / 2, 220));


            }
            else
            {

                if (gameover)
                {
                    SizeF message = canvas.MeasureString("Game Over", font);
                    canvas.DrawString("Game Over", font, Brushes.White, new PointF(200 - message.Width / 2, 120));
                    message = canvas.MeasureString("Final Score " + score.ToString(), font);
                    canvas.DrawString("Final Score " + score.ToString(), font, Brushes.White, new PointF(200 - message.Width / 2, 140));
                    message = canvas.MeasureString("Press Enter to Start a New Game", font);
                    canvas.DrawString("Press Enter to Start a New Game", font, Brushes.White, new PointF(200 - message.Width / 2, 160));
                }
                else
                {
                   
                    canvas.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(oneSnake.food.X * 8, oneSnake.food.Y * 8, 8, 8));
                    for (int i = 0; i < oneSnake.tail.Count; i++)
                    {
                        SnakePart currentPart = oneSnake.tail[i];
                        canvas.FillRectangle(new SolidBrush(Color.Black), new Rectangle(currentPart.X * 8, currentPart.Y * 8, 8, 8));
                    }
                    canvas.FillRectangle(new SolidBrush(Color.Red), new Rectangle(oneSnake.head.X * 8, oneSnake.head.Y * 8, 8, 8));
                    

                }
            }
        }

        private void GameOver()
        {
            gameover = true;
            gameStartButton.Enabled = true;
            oneSnake = new Snake(100);
        }

    
        private void gameStartButton_Click(object sender, EventArgs e)
        {
            gameStartButton.Enabled = false;
            Focus();
            gameover = false;
            buttonPressed = true;
            oneSnake = new Snake(100);
            StartGame();
            scoreLabel.Text = "Score: " + score.ToString();

        }
    }
}
