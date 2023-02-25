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
    public partial class Userinfo : Form
    {
        public Userinfo()
        {
            InitializeComponent();
        }

        private void Userinfo_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;

            label1.Text = "User: " + Environment.UserName + "";
            label2.Text = "" + Environment.UserName + "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
