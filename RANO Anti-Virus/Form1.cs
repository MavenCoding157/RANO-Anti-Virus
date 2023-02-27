using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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

        //move form
        int mov;
        int movX;
        int movY;

        string CurrentVersion = "0.3";
        private ContextMenu m_menu;

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

        public Form1()
        {
            InitializeComponent();
            m_menuLoad();//loads menu sys tray
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the RANO Anti-Virus?", "RANO Anti Virus", MessageBoxButtons.YesNo);
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

            Location = Screen.AllScreens[0].WorkingArea.Location;

            notifyIcon1.BalloonTipText = ("Welcome " + Environment.UserName + " to the RANO Anti-Virus");
            notifyIcon1.ShowBalloonTip(1000);

            label9.Text = "User: " + Environment.UserName + "";

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));//round corners

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
            Form f = new Links();
            DialogResult res = f.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form f = new System_Information();
            DialogResult res = f.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkSlateGray;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
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
            MessageBox.Show("If there is an error just press ok \nThe tool has worked just a slight bug in the code.");
            var username = System.Environment.GetEnvironmentVariable("USERNAME");
            System.IO.Directory.Delete("C:\\Users\\" + username + "\\AppData\\Local\\Temp", true);
            MessageBox.Show("System cleaned.", "Cleaned", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form f = new About();
            DialogResult res = f.ShowDialog();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string version = client.DownloadString("https://raw.githubusercontent.com/MavenCoding157/RANO-Anti-Virus/main/Version.txt");
            if (version.Contains(CurrentVersion))
            {
                MessageBox.Show("RANO Anti-Virus is up to date", "Update", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please update to a newer version.", "Update", MessageBoxButtons.OK);
                System.Diagnostics.Process.Start("https://github.com/MavenCoding157/RANO-Anti-Virus");
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_mouseMove(object sender, MouseEventArgs e)
        {
            if(mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUP(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.SendToBack();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RANO Anti-Virus is a basic Anti-Virus made with c# by MavenCoding157. This project is still currently in BETA \nso expect frequent updates.", "About", MessageBoxButtons.OK);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            Form f = new Encryption();
            DialogResult res = f.ShowDialog();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Form f = new Userinfo();
            DialogResult res = f.ShowDialog();
        }
        private void m_menuLoad()
        {
            m_menu = new ContextMenu();
            m_menu.MenuItems.Add(0,
                new MenuItem("Show", new System.EventHandler(Show_Click)));
            m_menu.MenuItems.Add(1,
                new MenuItem("Exit", new System.EventHandler(Exit_Click)));
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon1.ContextMenu = m_menu;
        }
        protected void Exit_Click(Object sender, System.EventArgs e)
        {
            Close();
        }
        protected void Show_Click(Object sender, System.EventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            using (FileDialog fileDialog = new OpenFileDialog())
            {
                if (DialogResult.OK == fileDialog.ShowDialog())
                {
                    string filename = fileDialog.FileName;

                    textBox1.Text = fileDialog.FileName;
                }
            }
        }
    }
}
