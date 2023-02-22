using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace RANO_Anti_Virus
{
    public partial class Form1 : Form
    {
        
        //bools
        bool sidebarExpand;
        bool homeCollapsed;

        public Form1()
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
        

        private void SideBar_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                flowLayoutPanel1.Width -= 10;
                if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    SideBar.Stop();
                }
            }
            else
            {
                flowLayoutPanel1.Width += 10;
                if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    SideBar.Stop();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SideBar.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "RANO Anti-Virus";
            
        }

        private void stopandstart_Tick(object sender, EventArgs e)
        {
            if(homeCollapsed)
            {
                homecontainer.Height += 10;
                if(homecontainer.Height == homecontainer.MaximumSize.Height)
                {
                    homeCollapsed= false;
                    stopandstart.Stop();
                }

            }
            else
            {
                homecontainer.Height -= 10;
                if (homecontainer.Height == homecontainer.MinimumSize.Height)
                {
                    homeCollapsed = true;
                    stopandstart.Stop();
                }
            }
        }

        private string getMyIPAddress()
        {
            String Address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                Address = stream.ReadToEnd();
            }
            int first = Address.IndexOf("Address: ") + 9;
            int last = Address.IndexOf("</body>");
            Address = Address.Substring(first, last - first);
            return Address;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = (getMyIPAddress());
            notifyIcon1.ShowBalloonTip(1000);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCkP2YjZfvZIfArYbAUyRLsg");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon...");
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkSlateGray;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Navy;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            stopandstart.Start();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scanning now Please wait....", "Scanning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var scanner = new AntiVirus.Scanner();
            var result = scanner.ScanAndClean(textBox1.Text);
            MessageBox.Show("" + result);

            label8.Text = "Last virus scan " + DateTime.Now.ToLongDateString();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            var username = System.Environment.GetEnvironmentVariable("USERNAME");
            System.IO.Directory.Delete("C:\\Users\\" + username + "\\AppData\\Local\\Temp", true);
            MessageBox.Show("System cleaned.", "Cleaned", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form f = new About();
            DialogResult res = f.ShowDialog();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Anti-Virus up to date.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
