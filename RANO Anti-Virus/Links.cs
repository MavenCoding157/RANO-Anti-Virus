using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RANO_Anti_Virus
{
    public partial class Links : Form
    {
        public Links()
        {
            InitializeComponent();
        }

        private void Links_Load(object sender, EventArgs e)
        {
            label2.Text = "Hello, '" + Environment.UserName + "'";
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/@TheXboxParty");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon...");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon...");
        }
    }
}
