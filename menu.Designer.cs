namespace SnakeEvo
{
    partial class menu
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
            this.evolution = new System.Windows.Forms.Button();
            this.showcase = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // evolution
            // 
            this.evolution.Location = new System.Drawing.Point(129, 39);
            this.evolution.Name = "evolution";
            this.evolution.Size = new System.Drawing.Size(125, 41);
            this.evolution.TabIndex = 0;
            this.evolution.Text = "Evolution";
            this.evolution.UseVisualStyleBackColor = true;
            this.evolution.Click += new System.EventHandler(this.evolution_Click);
            // 
            // showcase
            // 
            this.showcase.Location = new System.Drawing.Point(129, 112);
            this.showcase.Name = "showcase";
            this.showcase.Size = new System.Drawing.Size(125, 41);
            this.showcase.TabIndex = 1;
            this.showcase.Text = "Showcase";
            this.showcase.UseVisualStyleBackColor = true;
            this.showcase.Click += new System.EventHandler(this.aiAssist_Click);
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(127, 187);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(125, 41);
            this.about.TabIndex = 2;
            this.about.Text = "About";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 360);
            this.Controls.Add(this.about);
            this.Controls.Add(this.showcase);
            this.Controls.Add(this.evolution);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "menu";
            this.Text = "SnakeEvo by Ivan Pešić";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button evolution;
        private System.Windows.Forms.Button showcase;
        private System.Windows.Forms.Button about;
    }
}