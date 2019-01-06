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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

       

        private void evolution_Click(object sender, EventArgs e)
        {
            (new Evolution()).ShowDialog();
        }

        private void about_Click(object sender, EventArgs e)
        {
            (new gameForm()).ShowDialog();
        }

        private void aiAssist_Click(object sender, EventArgs e)
        {
            (new showcase()).ShowDialog();
        }
    }
}
