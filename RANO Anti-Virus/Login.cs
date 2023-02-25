using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        //round corner (ddl's)
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse); // height of ellipse

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
                notifyIcon1.BalloonTipText = ("Goodbye. See you soon " + Environment.UserName + "");
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (dialogResult == DialogResult.No)
            {
                //nothing
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

            notifyIcon1.BalloonTipText = ("RANO Anti-Virus has been minimized");
            notifyIcon1.ShowBalloonTip(1000);
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
            MessageBox.Show("WARNING! This is software is still in BETA so do not use as main Anti-Virus.", "RANO Anti-Virus", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Location = Screen.AllScreens[0].WorkingArea.Location;

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));//round corners
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
