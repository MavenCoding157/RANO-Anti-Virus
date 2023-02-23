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
    public partial class Login : Form
    {
        //move form
        int mov;
        int movX;
        int movY;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the RANO Anti-Virus?", "See you soon", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //nothing
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = textBox1.Text;
            pass = textBox2.Text;
            if(user=="admin"&& pass=="admin")
            {
                MessageBox.Show("Login successful. Redirecting now...");
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password. Try again.", "Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            MessageBox.Show("WARNING! This is software is still in BETA so do not use as main Anti-Virus. \nAlso make sure to run this software with admin permissions.", "RANO Anti-Virus", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Location = Screen.AllScreens[0].WorkingArea.Location;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUP(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
