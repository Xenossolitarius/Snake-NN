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
    public partial class showcase : Form
    {
        Snake testSnake;
        Snake startSnake;
        Timer gameLoop = new Timer();
        Timer snakeLoop = new Timer();
        int gameSpeed;
        bool gameStarted = false;
        public showcase()
        {
            InitializeComponent();
            gameSpeed = 10;
            gameLoop.Tick += new EventHandler(UpdateScreen);
            snakeLoop.Tick += new EventHandler(UpdateSnake);
            gameLoop.Interval = 1000 / 60;
            snakeLoop.Interval = 1000 / gameSpeed;
            gameLoop.Start();
            snakeLoop.Start();
            startButton.Enabled = false;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            snakeSerial tempEkans;
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Load Snake";
            fdlg.InitialDirectory = @"c:\temp\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                String fileName = fdlg.FileName;
                // MessageBox.Show(fileName);
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(snakeSerial));
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                tempEkans = (snakeSerial)reader.Deserialize(file);
                file.Close();
                MessageBox.Show("Snake read!");

                testSnake = new Snake(tempEkans.lifeTime);

                testSnake.fitness = tempEkans.fitness;

                testSnake.brain.whi.matrix = ArrayConvert.SingleToMulti(tempEkans.whi, tempEkans.whiRows, tempEkans.whiCols);
                testSnake.brain.whh.matrix = ArrayConvert.SingleToMulti(tempEkans.whh, tempEkans.whhRows, tempEkans.whhCols);
                testSnake.brain.woh.matrix = ArrayConvert.SingleToMulti(tempEkans.woh, tempEkans.wohRows, tempEkans.wohCols);
                startButton.Enabled = true;
            }




        }

        private void UpdateSnake(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                startSnake.Look();
                startSnake.SetVelocity();
                startSnake.Move();

                scoreLabel.Text = "Score: " + (startSnake.len-4) * 10;

                if (startSnake.diedFromWall == true || startSnake.diedFromSelf == true)
                {
                    gameStarted = false;
                    startButton.Text = "Restart";
                }
            }
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
                pbCanvas.Invalidate();
        }
        private void Draw(Graphics canvas)
        {

            canvas.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(startSnake.food.X * 8, startSnake.food.Y * 8, 8, 8));
            for (int i = 0; i < startSnake.tail.Count; i++)
            {
                //Color snake_color = i == 0 ? Color.Red : Color.Black;
                SnakePart currentPart = startSnake.tail[i];
                canvas.FillRectangle(new SolidBrush(Color.Black), new Rectangle(currentPart.X * 8, currentPart.Y * 8, 8, 8));
            }
            canvas.FillRectangle(new SolidBrush(Color.Red), new Rectangle(startSnake.head.X * 8, startSnake.head.Y * 8, 8, 8));

        }

            private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (gameStarted == true)
                Draw(e.Graphics);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                gameStarted = true;
                startButton.Text = "Stop";
                startSnake = new Snake(testSnake.lifeTime);
                startSnake = testSnake.Clone(testSnake.lifeTime);
                startSnake.leftToLive = testSnake.leftTimeLive;
                startSnake.leftTimeLive = testSnake.leftTimeLive;
                startSnake.alive = true;
                

            }
            else
            {
                gameStarted = false;
                startButton.Text = "Start";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            gameSpeed = (int)numericUpDown1.Value;
            snakeLoop.Interval = 1000 / gameSpeed;

        }
    }
}
