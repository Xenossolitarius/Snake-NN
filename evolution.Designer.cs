namespace SnakeEvo
{
    partial class Evolution
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.startEvo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownEvo = new System.Windows.Forms.NumericUpDown();
            this.aliveLabel = new System.Windows.Forms.Label();
            this.currMaxLen = new System.Windows.Forms.Label();
            this.currMaxLenLabel = new System.Windows.Forms.Label();
            this.timeAliveLabel = new System.Windows.Forms.Label();
            this.generationLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mutationNumeric = new System.Windows.Forms.NumericUpDown();
            this.bestFintessLabel = new System.Windows.Forms.Label();
            this.lastFitnessLabel = new System.Windows.Forms.Label();
            this.leftTimeLabel = new System.Windows.Forms.Label();
            this.leftTimeNumeric = new System.Windows.Forms.NumericUpDown();
            this.diedTimeLabel = new System.Windows.Forms.Label();
            this.diedSelfLabel = new System.Windows.Forms.Label();
            this.diedWallLabel = new System.Windows.Forms.Label();
            this.highLenLabel = new System.Windows.Forms.Label();
            this.currLenLabel = new System.Windows.Forms.Label();
            this.previewLabelsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericParentRatio = new System.Windows.Forms.NumericUpDown();
            this.buttonRender = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.genSnakeLabel = new System.Windows.Forms.Label();
            this.fitSnakeLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.elitismCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEvo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTimeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParentRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pbCanvas.Location = new System.Drawing.Point(580, 75);
            this.pbCanvas.Margin = new System.Windows.Forms.Padding(4);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(400, 400);
            this.pbCanvas.TabIndex = 1;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // startEvo
            // 
            this.startEvo.Location = new System.Drawing.Point(51, 346);
            this.startEvo.Name = "startEvo";
            this.startEvo.Size = new System.Drawing.Size(167, 23);
            this.startEvo.TabIndex = 2;
            this.startEvo.Text = "Start Evolution";
            this.startEvo.UseVisualStyleBackColor = true;
            this.startEvo.Click += new System.EventHandler(this.startEvo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Population Size:";
            // 
            // numericUpDownEvo
            // 
            this.numericUpDownEvo.Location = new System.Drawing.Point(150, 60);
            this.numericUpDownEvo.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownEvo.Name = "numericUpDownEvo";
            this.numericUpDownEvo.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownEvo.TabIndex = 4;
            this.numericUpDownEvo.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // aliveLabel
            // 
            this.aliveLabel.AutoSize = true;
            this.aliveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aliveLabel.Location = new System.Drawing.Point(629, 503);
            this.aliveLabel.Name = "aliveLabel";
            this.aliveLabel.Size = new System.Drawing.Size(59, 20);
            this.aliveLabel.TabIndex = 6;
            this.aliveLabel.Text = "Alive: 0";
            // 
            // currMaxLen
            // 
            this.currMaxLen.AutoSize = true;
            this.currMaxLen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currMaxLen.Location = new System.Drawing.Point(629, 534);
            this.currMaxLen.Name = "currMaxLen";
            this.currMaxLen.Size = new System.Drawing.Size(121, 20);
            this.currMaxLen.TabIndex = 7;
            this.currMaxLen.Text = "Max Gen Len: 0";
            // 
            // currMaxLenLabel
            // 
            this.currMaxLenLabel.AutoSize = true;
            this.currMaxLenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currMaxLenLabel.Location = new System.Drawing.Point(790, 534);
            this.currMaxLenLabel.Name = "currMaxLenLabel";
            this.currMaxLenLabel.Size = new System.Drawing.Size(120, 20);
            this.currMaxLenLabel.TabIndex = 8;
            this.currMaxLenLabel.Text = "Curr Max Len: 0";
            // 
            // timeAliveLabel
            // 
            this.timeAliveLabel.AutoSize = true;
            this.timeAliveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeAliveLabel.Location = new System.Drawing.Point(790, 503);
            this.timeAliveLabel.Name = "timeAliveLabel";
            this.timeAliveLabel.Size = new System.Drawing.Size(97, 20);
            this.timeAliveLabel.TabIndex = 9;
            this.timeAliveLabel.Text = "Time Alive: 0";
            // 
            // generationLabel
            // 
            this.generationLabel.AutoSize = true;
            this.generationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generationLabel.Location = new System.Drawing.Point(706, 32);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(143, 26);
            this.generationLabel.TabIndex = 10;
            this.generationLabel.Text = "Generation: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Location = new System.Drawing.Point(44, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mutation Ratio:";
            // 
            // mutationNumeric
            // 
            this.mutationNumeric.DecimalPlaces = 3;
            this.mutationNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.mutationNumeric.Location = new System.Drawing.Point(150, 103);
            this.mutationNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.mutationNumeric.Name = "mutationNumeric";
            this.mutationNumeric.Size = new System.Drawing.Size(120, 20);
            this.mutationNumeric.TabIndex = 12;
            this.mutationNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.mutationNumeric.ValueChanged += new System.EventHandler(this.updateMutation);
            // 
            // bestFintessLabel
            // 
            this.bestFintessLabel.AutoSize = true;
            this.bestFintessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bestFintessLabel.Location = new System.Drawing.Point(274, 496);
            this.bestFintessLabel.Name = "bestFintessLabel";
            this.bestFintessLabel.Size = new System.Drawing.Size(178, 29);
            this.bestFintessLabel.TabIndex = 13;
            this.bestFintessLabel.Text = "High. Fitness: 0";
            // 
            // lastFitnessLabel
            // 
            this.lastFitnessLabel.AutoSize = true;
            this.lastFitnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastFitnessLabel.Location = new System.Drawing.Point(280, 534);
            this.lastFitnessLabel.Name = "lastFitnessLabel";
            this.lastFitnessLabel.Size = new System.Drawing.Size(172, 29);
            this.lastFitnessLabel.TabIndex = 14;
            this.lastFitnessLabel.Text = "Last. Fitness: 0";
            // 
            // leftTimeLabel
            // 
            this.leftTimeLabel.AutoSize = true;
            this.leftTimeLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.leftTimeLabel.Location = new System.Drawing.Point(44, 147);
            this.leftTimeLabel.Name = "leftTimeLabel";
            this.leftTimeLabel.Size = new System.Drawing.Size(72, 13);
            this.leftTimeLabel.TabIndex = 15;
            this.leftTimeLabel.Text = "Time To Live:";
            // 
            // leftTimeNumeric
            // 
            this.leftTimeNumeric.Location = new System.Drawing.Point(150, 145);
            this.leftTimeNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.leftTimeNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.leftTimeNumeric.Name = "leftTimeNumeric";
            this.leftTimeNumeric.Size = new System.Drawing.Size(120, 20);
            this.leftTimeNumeric.TabIndex = 16;
            this.leftTimeNumeric.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // diedTimeLabel
            // 
            this.diedTimeLabel.AutoSize = true;
            this.diedTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diedTimeLabel.Location = new System.Drawing.Point(376, 222);
            this.diedTimeLabel.Name = "diedTimeLabel";
            this.diedTimeLabel.Size = new System.Drawing.Size(138, 20);
            this.diedTimeLabel.TabIndex = 19;
            this.diedTimeLabel.Text = "Died From Time: 0";
            // 
            // diedSelfLabel
            // 
            this.diedSelfLabel.AutoSize = true;
            this.diedSelfLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diedSelfLabel.Location = new System.Drawing.Point(382, 253);
            this.diedSelfLabel.Name = "diedSelfLabel";
            this.diedSelfLabel.Size = new System.Drawing.Size(132, 20);
            this.diedSelfLabel.TabIndex = 20;
            this.diedSelfLabel.Text = "Died From Self: 0";
            // 
            // diedWallLabel
            // 
            this.diedWallLabel.AutoSize = true;
            this.diedWallLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diedWallLabel.Location = new System.Drawing.Point(380, 282);
            this.diedWallLabel.Name = "diedWallLabel";
            this.diedWallLabel.Size = new System.Drawing.Size(134, 20);
            this.diedWallLabel.TabIndex = 21;
            this.diedWallLabel.Text = "Died From Wall: 0";
            // 
            // highLenLabel
            // 
            this.highLenLabel.AutoSize = true;
            this.highLenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highLenLabel.Location = new System.Drawing.Point(280, 455);
            this.highLenLabel.Name = "highLenLabel";
            this.highLenLabel.Size = new System.Drawing.Size(173, 29);
            this.highLenLabel.TabIndex = 22;
            this.highLenLabel.Text = "High. Length: 0";
            // 
            // currLenLabel
            // 
            this.currLenLabel.AutoSize = true;
            this.currLenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currLenLabel.Location = new System.Drawing.Point(284, 416);
            this.currLenLabel.Name = "currLenLabel";
            this.currLenLabel.Size = new System.Drawing.Size(169, 29);
            this.currLenLabel.TabIndex = 23;
            this.currLenLabel.Text = "Curr. Length: 0";
            // 
            // previewLabelsButton
            // 
            this.previewLabelsButton.Location = new System.Drawing.Point(51, 452);
            this.previewLabelsButton.Name = "previewLabelsButton";
            this.previewLabelsButton.Size = new System.Drawing.Size(167, 23);
            this.previewLabelsButton.TabIndex = 24;
            this.previewLabelsButton.Text = "Stop Stats Preview";
            this.previewLabelsButton.UseVisualStyleBackColor = true;
            this.previewLabelsButton.Click += new System.EventHandler(this.previewLabelsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Location = new System.Drawing.Point(44, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Parent ratio:";
            // 
            // numericParentRatio
            // 
            this.numericParentRatio.DecimalPlaces = 3;
            this.numericParentRatio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.numericParentRatio.Location = new System.Drawing.Point(150, 185);
            this.numericParentRatio.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericParentRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericParentRatio.Name = "numericParentRatio";
            this.numericParentRatio.Size = new System.Drawing.Size(120, 20);
            this.numericParentRatio.TabIndex = 26;
            this.numericParentRatio.Value = new decimal(new int[] {
            15,
            0,
            0,
            131072});
            this.numericParentRatio.ValueChanged += new System.EventHandler(this.updateParent);
            // 
            // buttonRender
            // 
            this.buttonRender.Location = new System.Drawing.Point(51, 400);
            this.buttonRender.Name = "buttonRender";
            this.buttonRender.Size = new System.Drawing.Size(167, 23);
            this.buttonRender.TabIndex = 27;
            this.buttonRender.Text = "Stop Render";
            this.buttonRender.UseVisualStyleBackColor = true;
            this.buttonRender.Click += new System.EventHandler(this.buttonRender_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(381, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 26);
            this.label4.TabIndex = 28;
            this.label4.Text = "Best Snake";
            // 
            // genSnakeLabel
            // 
            this.genSnakeLabel.AutoSize = true;
            this.genSnakeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genSnakeLabel.Location = new System.Drawing.Point(376, 75);
            this.genSnakeLabel.Name = "genSnakeLabel";
            this.genSnakeLabel.Size = new System.Drawing.Size(57, 20);
            this.genSnakeLabel.TabIndex = 29;
            this.genSnakeLabel.Text = "Gen: 0";
            // 
            // fitSnakeLabel
            // 
            this.fitSnakeLabel.AutoSize = true;
            this.fitSnakeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fitSnakeLabel.Location = new System.Drawing.Point(376, 100);
            this.fitSnakeLabel.Name = "fitSnakeLabel";
            this.fitSnakeLabel.Size = new System.Drawing.Size(78, 20);
            this.fitSnakeLabel.TabIndex = 30;
            this.fitSnakeLabel.Text = "Fitness: 0";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(51, 503);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(167, 51);
            this.saveButton.TabIndex = 31;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // elitismCheckBox
            // 
            this.elitismCheckBox.AutoSize = true;
            this.elitismCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elitismCheckBox.Location = new System.Drawing.Point(92, 235);
            this.elitismCheckBox.Name = "elitismCheckBox";
            this.elitismCheckBox.Size = new System.Drawing.Size(74, 24);
            this.elitismCheckBox.TabIndex = 32;
            this.elitismCheckBox.Text = "Elitism";
            this.elitismCheckBox.UseVisualStyleBackColor = true;
            this.elitismCheckBox.CheckedChanged += new System.EventHandler(this.elitismCheckBox_CheckedChanged);
            // 
            // Evolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 581);
            this.Controls.Add(this.elitismCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fitSnakeLabel);
            this.Controls.Add(this.genSnakeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonRender);
            this.Controls.Add(this.numericParentRatio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.previewLabelsButton);
            this.Controls.Add(this.currLenLabel);
            this.Controls.Add(this.highLenLabel);
            this.Controls.Add(this.diedWallLabel);
            this.Controls.Add(this.diedSelfLabel);
            this.Controls.Add(this.diedTimeLabel);
            this.Controls.Add(this.leftTimeNumeric);
            this.Controls.Add(this.leftTimeLabel);
            this.Controls.Add(this.lastFitnessLabel);
            this.Controls.Add(this.bestFintessLabel);
            this.Controls.Add(this.mutationNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generationLabel);
            this.Controls.Add(this.timeAliveLabel);
            this.Controls.Add(this.currMaxLenLabel);
            this.Controls.Add(this.currMaxLen);
            this.Controls.Add(this.aliveLabel);
            this.Controls.Add(this.numericUpDownEvo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startEvo);
            this.Controls.Add(this.pbCanvas);
            this.Name = "Evolution";
            this.Text = "EVOlution";
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEvo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftTimeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericParentRatio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Button startEvo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownEvo;
        private System.Windows.Forms.Label aliveLabel;
        private System.Windows.Forms.Label currMaxLen;
        private System.Windows.Forms.Label currMaxLenLabel;
        private System.Windows.Forms.Label timeAliveLabel;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown mutationNumeric;
        private System.Windows.Forms.Label bestFintessLabel;
        private System.Windows.Forms.Label lastFitnessLabel;
        private System.Windows.Forms.Label leftTimeLabel;
        private System.Windows.Forms.NumericUpDown leftTimeNumeric;
        private System.Windows.Forms.Label diedTimeLabel;
        private System.Windows.Forms.Label diedSelfLabel;
        private System.Windows.Forms.Label diedWallLabel;
        private System.Windows.Forms.Label highLenLabel;
        private System.Windows.Forms.Label currLenLabel;
        private System.Windows.Forms.Button previewLabelsButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericParentRatio;
        private System.Windows.Forms.Button buttonRender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label genSnakeLabel;
        private System.Windows.Forms.Label fitSnakeLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox elitismCheckBox;
    }
}